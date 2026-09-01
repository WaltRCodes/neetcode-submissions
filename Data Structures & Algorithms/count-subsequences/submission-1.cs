public class Solution {
    public int NumDistinct(string s, string t) {

        int m = s.Length, n = t.Length;

        // dp[j] = number of ways s[i:] can form t[j:]
        // We only keep one row of DP at a time.
        int[] dp = new int[n + 1];

        // Base case: empty t ("") can always be formed in exactly 1 way
        dp[n] = 1;

        // Iterate s from right → left
        for (int i = m - 1; i >= 0; i--) {

            // prev represents dp[j+1] from the previous iteration of j
            // For j == n, dp[n] is always 1 (empty t)
            int prev = 1;

            // Iterate t from right → left
            for (int j = n - 1; j >= 0; j--) {

                // Start with the number of ways without matching s[i]
                int res = dp[j];

                // If characters match, add the number of ways to match the rest
                if (s[i] == t[j]) {
                    res += prev;   // prev = dp[j+1] from previous row
                }

                // Update prev for next iteration (store old dp[j])
                prev = dp[j];

                // Write new result into dp[j]
                dp[j] = res;
            }
        }

        // dp[0] = number of ways s can form t
        return dp[0];
    }
}
