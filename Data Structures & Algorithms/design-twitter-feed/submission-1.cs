public class Twitter {

    private int count; // Global counter to track tweet order
    private Dictionary<int, List<(int, int)>> tweetMap; // Maps userId -> list of (count, tweetId)
    private Dictionary<int, HashSet<int>> followMap;    // Maps userId -> set of followees

    // Constructor: initialize the data structures
    public Twitter() {
        count = 0;
        tweetMap = new Dictionary<int, List<(int, int)>>();
        followMap = new Dictionary<int, HashSet<int>>();
    }
    
    // Post a tweet by a user
    public void PostTweet(int userId, int tweetId) {
        if (!tweetMap.ContainsKey(userId)) {
            tweetMap[userId] = new List<(int, int)>();
        }
        // Add tweet with current count
        tweetMap[userId].Add((count, tweetId));

        // Keep only the latest 10 tweets per user
        if (tweetMap[userId].Count > 10) {
            tweetMap[userId].RemoveAt(0);
        }
        count--; // Decrement counter to maintain reverse chronological order
    }
    
    // Get the 10 most recent tweets in the user's news feed
    public List<int> GetNewsFeed(int userId) {
        var res = new List<int>();

        // Ensure user follows themselves
        if (!followMap.ContainsKey(userId)) {
            followMap[userId] = new HashSet<int>();
        }
        followMap[userId].Add(userId);

        // Min-heap to store tweets based on timestamp
        var minHeap = new PriorityQueue<(int, int, int, int), int>();

        if (followMap[userId].Count >= 10) {
            // Use max-heap for large number of followees
            var maxHeap = new PriorityQueue<(int, int, int, int), int>();
            foreach (var fId in followMap[userId]) {
                if (tweetMap.ContainsKey(fId)) {
                    var tweets = tweetMap[fId];
                    int idx = tweets.Count - 1;
                    var (c, tId) = tweets[idx];
                    maxHeap.Enqueue((-c, tId, fId, idx - 1), -c); // Push latest tweet
                    if (maxHeap.Count > 10) {
                        maxHeap.Dequeue(); // Keep only top 10
                    }
                }
            }
            while (maxHeap.Count > 0) {
                var item = maxHeap.Dequeue();
                var negCount = item.Item1;
                var tId = item.Item2;
                var fId = item.Item3;
                var idx = item.Item4;
                int originalCount = -negCount;
                minHeap.Enqueue((originalCount, tId, fId, idx), originalCount);
            }
        } else {
            // For fewer followees, directly use minHeap
            foreach (var fId in followMap[userId]) {
                if (tweetMap.ContainsKey(fId)) {
                    var tweets = tweetMap[fId];
                    int idx = tweets.Count - 1;
                    var (c, tId) = tweets[idx];
                    minHeap.Enqueue((c, tId, fId, idx - 1), c);
                }
            }
        }

        // Extract up to 10 most recent tweets
        while (minHeap.Count > 0 && res.Count < 10) {
            var (c, tId, fId, idx) = minHeap.Dequeue();
            res.Add(tId);
            if (idx >= 0) {
                var (olderCount, olderTid) = tweetMap[fId][idx];
                minHeap.Enqueue((olderCount, olderTid, fId, idx - 1), olderCount);
            }
        }

        return res;
    }
    
    // Follower follows a followee
    public void Follow(int followerId, int followeeId) {
        if (!followMap.ContainsKey(followerId)) {
            followMap[followerId] = new HashSet<int>();
        }
        followMap[followerId].Add(followeeId);
    }
    
    // Follower unfollows a followee
    public void Unfollow(int followerId, int followeeId) {
        if (followMap.ContainsKey(followerId)) {
            followMap[followerId].Remove(followeeId);
        }
    }
}
