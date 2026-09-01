public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {

        // If the endWord is not in the dictionary, no transformation is possible
        if (!wordList.Contains(endWord)){
            return 0;
        }

        // Map each generic pattern (e.g., h*t, *ot) to all words matching it
        Dictionary<string, List<string>> nei = new Dictionary<string, List<string>>();

        // Include the beginWord in the list so it participates in pattern mapping
        wordList.Add(beginWord);

        // Build adjacency patterns for each word
        foreach (string word in wordList) {
            for (int j = 0; j < word.Length; j++) {
                // Create a pattern by replacing one character with '*'
                string pattern = word.Substring(0, j) + "*" + word.Substring(j + 1);

                // Add the word to the list of words matching this pattern
                if (!nei.ContainsKey(pattern)){
                    nei[pattern] = new List<string>();
                }
                nei[pattern].Add(word);
            }
        }

        // Track visited words to avoid cycles
        HashSet<string> visit = new HashSet<string>();

        // BFS queue starting from beginWord
        Queue<string> q = new Queue<string>();
        q.Enqueue(beginWord);

        int res = 1; // Ladder length starts at 1 (beginWord itself)

        // Standard BFS
        while (q.Count > 0) {
            int size = q.Count;

            // Process all nodes at the current BFS level
            for (int i = 0; i < size; i++){
                string word = q.Dequeue();

                // If we reached the target, return the number of steps
                if (word == endWord) {
                    return res;
                }

                // Generate all patterns for the current word
                for (int j = 0; j < word.Length; j++){
                    string pattern = word.Substring(0, j) + "*" + word.Substring(j + 1);

                    // Explore all neighbors that match this pattern
                    if (nei.ContainsKey(pattern)) {
                        foreach (string neiWord in nei[pattern]){
                            if (!visit.Contains(neiWord)){
                                visit.Add(neiWord);
                                q.Enqueue(neiWord);
                            }
                        }
                    }
                }
            }

            // Increase ladder length after finishing a BFS level
            res++;
        }

        // If BFS ends without finding endWord, no transformation exists
        return 0;
    }
}
