public class Twitter {

    private int count;
    private Dictionary<int, List<(int, int)>> tweetMap;
    private Dictionary<int, HashSet<int>> followMap;

    public Twitter() {
        count = 0;
        tweetMap = new Dictionary<int, List<(int, int)>>();
        followMap = new Dictionary<int, HashSet<int>>();
    }
    
    public void PostTweet(int userId, int tweetId) {
        if (!tweetMap.ContainsKey(userId)){
            tweetMap[userId] = new List<(int, int)>();
        }
        tweetMap[userId].Add((count, tweetId));
        if (tweetMap[userId].Count > 10){
            tweetMap[userId].RemoveAt(0);
        }
        count--;
    }
    
    public List<int> GetNewsFeed(int userId) {
        var res = new List<int>();
        if (!followMap.ContainsKey(userId)){
            followMap[userId] = new HashSet<int>();
        }
        followMap[userId].Add(userId);
        var minHeap = new PriorityQueue<(int, int, int, int), int>();
        if (followMap[userId].Count >= 10){
            var maxHeap = new PriorityQueue<(int, int, int, int),int>();
            foreach (var fId in followMap[userId]){
                if (tweetMap.ContainsKey(fId)){
                    var tweets = tweetMap[fId];
                    int idx = tweets.Count - 1;
                    var (c, tId) = tweets[idx];
                    maxHeap.Enqueue((-c, tId, fId, idx -1),-c);
                    if (maxHeap.Count > 10){
                        maxHeap.Dequeue();
                    }
                }
            }
            while (maxHeap.Count > 0){
                var item = maxHeap.Dequeue();
                var negCount = item.Item1;
                var tId = item.Item2;
                var fId = item.Item3;
                var idx = item.Item4;

                int originalCount = - negCount;
                minHeap.Enqueue((originalCount,tId,fId,idx),originalCount);
            }
        } else {
            foreach (var fId in followMap[userId]){
                if (tweetMap.ContainsKey(fId)){
                    var tweets = tweetMap[fId];
                    int idx = tweets.Count - 1;
                    var (c, tId) = tweets[idx];
                    minHeap.Enqueue((c, tId, fId, idx - 1), c);
                }
            }
        }
        while (minHeap.Count > 0 && res.Count < 10){
            var (c, tId, fId, idx) = minHeap.Dequeue();
            res.Add(tId);
            if (idx >= 0){
                var (olderCount, olderTid) = tweetMap[fId][idx];
                minHeap.Enqueue((olderCount, olderTid, fId, idx -1), olderCount);
            }
        }
        return res;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!followMap.ContainsKey(followerId)){
            followMap[followerId] = new HashSet<int>();
        }
        followMap[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (followMap.ContainsKey(followerId)){
            followMap[followerId].Remove(followeeId);
        }
    }
}
