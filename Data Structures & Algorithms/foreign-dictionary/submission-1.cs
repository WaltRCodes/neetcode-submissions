public class Solution {
    // adj: adjacency list representing ordering constraints between characters
    // visited: tracks DFS state (true = currently in recursion stack, false = fully processed)
    // result: stores characters in topologically sorted order
    private Dictionary<char, HashSet<char>> adj;
    private Dictionary<char, bool> visited;
    private List<char> result;

    public string foreignDictionary(string[] words) {

        // Initialize adjacency list with all unique characters
        adj = new Dictionary<char, HashSet<char>>();
        foreach (var word in words) {
            foreach (var c in word) {
                if (!adj.ContainsKey(c)) {
                    adj[c] = new HashSet<char>();
                }
            }
        }

        // Build directed edges based on the first differing character between adjacent words
        for (int i = 0; i < words.Length - 1; i++) {
            var w1 = words[i];
            var w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);

            // Invalid case: longer word comes before its prefix (e.g., "abc" before "ab")
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen)) {
                return "";
            }

            // Find the first differing character and create a directed edge
            for (int j = 0; j < minLen; j++) {
                if (w1[j] != w2[j]) {
                    adj[w1[j]].Add(w2[j]);
                    break; // Only the first difference matters
                }
            }
        }

        // Prepare for DFS-based topological sort
        visited = new Dictionary<char, bool>();
        result = new List<char>();

        // Run DFS on every character to detect cycles and build ordering
        foreach (var c in adj.Keys) {
            if (dfs(c)) {
                return ""; // Cycle detected → invalid ordering
            }
        }

        // Reverse to get correct topological order
        result.Reverse();

        // Build final string
        var sb = new StringBuilder();
        foreach (var c in result) {
            sb.Append(c);
        }
        return sb.ToString();
    }

    // DFS returns true if a cycle is detected
    private bool dfs(char ch) {

        // If we've seen this node before:
        //   true  → currently in recursion stack → cycle
        //   false → already processed → no cycle
        if (visited.ContainsKey(ch)) {
            return visited[ch];
        }

        // Mark as currently exploring
        visited[ch] = true;

        // Visit all neighbors
        foreach (var next in adj[ch]) {
            if (dfs(next)) {
                return true; // Cycle found
            }
        }

        // Mark as fully processed
        visited[ch] = false;

        // Add to topological order
        result.Add(ch);

        return false;
    }
}
