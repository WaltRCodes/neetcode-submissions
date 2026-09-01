public class Solution {

    // Main function to return all palindrome partitions of s
    public List<List<string>> Partition(string s) {
        int n = s.Length;

        // Precompute palindrome substrings using DP
        bool[,] dp = new bool[n, n]; // dp[i,j] = true if s[i..j] is a palindrome

        // l = length of substring
        for (int l = 1; l <= n; l++) {
            for (int i = 0; i <= n - l; i++) {
                int j = i + l - 1;
                // A substring is palindrome if endpoints match and inner substring is palindrome
                dp[i, j] = (s[i] == s[j] && (i + 1 > j - 1 || dp[i + 1, j - 1]));
            }
        }

        // Use DFS/backtracking to generate all partitions using dp table
        return Dfs(s, dp, 0);
    }

    // DFS helper function to generate partitions starting from index i
    private List<List<string>> Dfs(string s, bool[,] dp, int i) {
        // Base case: reached end of string, return empty partition
        if (i >= s.Length) {
            return new List<List<string>> { new List<string>() };
        }

        var ret = new List<List<string>>();

        // Try every possible end index for a palindrome starting at i
        for (int j = i; j < s.Length; j++) {
            if (dp[i, j]) { // If s[i..j] is a palindrome
                var nxt = Dfs(s, dp, j + 1); // Recursively partition remaining string
                foreach (var part in nxt) {
                    var cur = new List<string> { s.Substring(i, j - i + 1) }; // Current palindrome
                    cur.AddRange(part); // Append partitions of remaining string
                    ret.Add(cur);
                }
            }
        }

        return ret;
    }
}
