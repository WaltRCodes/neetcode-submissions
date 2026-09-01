public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {

        // dp[i] = true if substring s[i:] can be segmented into words from the dictionary
        bool[] dp = new bool[s.Length + 1];

        // Base case: empty string can always be segmented
        dp[s.Length] = true;

        // Fill dp from right → left
        for (int i = s.Length - 1; i >= 0; i--) {

            // Try every word in the dictionary
            foreach (string w in wordDict) {

                // Check if the word fits starting at index i
                if (i + w.Length <= s.Length &&
                    s.Substring(i, w.Length) == w) {

                    // If the remainder of the string can be segmented,
                    // then s[i:] can also be segmented
                    dp[i] = dp[i + w.Length];
                }

                // If dp[i] is true, no need to check more words
                if (dp[i]) {
                    break;
                }
            }
        }

        // dp[0] tells us whether the entire string can be segmented
        return dp[0];
    }
}
