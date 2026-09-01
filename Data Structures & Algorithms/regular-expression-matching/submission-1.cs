public class Solution {
    public bool IsMatch(string s, string p) {

        // dp[j] = whether s[i:] matches p[j:]
        bool[] dp = new bool[p.Length + 1];

        // Base case: empty string matches empty pattern
        dp[p.Length] = true;

        // Iterate s from end → start
        for (int i = s.Length; i >= 0; i--) {

            // dp1 represents dp[j+1] from the previous iteration of j
            bool dp1 = dp[p.Length];

            // dp[p.Length] = true only when s[i:] is empty
            dp[p.Length] = (i == s.Length);

            // Iterate p from end → start
            for (int j = p.Length - 1; j >= 0; j--) {

                // Check if characters match (or pattern has '.')
                bool match = i < s.Length && (s[i] == p[j] || p[j] == '.');

                bool res = false;

                // Case 1: Next pattern char is '*'
                if (j + 1 < p.Length && p[j + 1] == '*') {

                    // Option A: Skip "x*" entirely → dp[j+2]
                    res = dp[j + 2];

                    // Option B: Use '*' to match current char → dp[j]
                    if (match) {
                        res |= dp[j];
                    }
                }
                // Case 2: Normal character or '.'
                else if (match) {
                    // Move diagonally → dp[i+1][j+1]
                    res = dp1;
                }

                // Update dp1 (diagonal) before overwriting dp[j]
                dp1 = dp[j];

                // Store result for dp[i][j]
                dp[j] = res;
            }
        }

        // dp[0] = does s[0:] match p[0:]
        return dp[0];
    }
}
