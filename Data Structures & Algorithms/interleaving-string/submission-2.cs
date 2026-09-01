public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {

        int m = s1.Length, n = s2.Length;

        // Length mismatch → impossible
        if (m + n != s3.Length)
            return false;

        // dp[j] = whether s1[0..i) and s2[0..j) can form s3[0..i+j)
        bool[] dp = new bool[n + 1];

        // Initialize first row (i = 0)
        dp[0] = true;
        for (int j = 1; j <= n; j++) {
            dp[j] = dp[j - 1] && s2[j - 1] == s3[j - 1];
        }

        // Fill the DP table row by row
        for (int i = 1; i <= m; i++) {

            // First column (j = 0)
            dp[0] = dp[0] && s1[i - 1] == s3[i - 1];

            for (int j = 1; j <= n; j++) {

                bool fromS1 = dp[j] && s1[i - 1] == s3[i + j - 1];
                bool fromS2 = dp[j - 1] && s2[j - 1] == s3[i + j - 1];

                dp[j] = fromS1 || fromS2;
            }
        }

        return dp[n];
    }
}
