public class Solution {
    public int MinDistance(string word1, string word2) {

        int m = word1.Length, n = word2.Length;

        // Always make word2 the shorter string so dp[] is as small as possible
        if (m < n) {
            string temp = word1; word1 = word2; word2 = temp;
            m = word1.Length; n = word2.Length;
        }

        // dp[j] = edit distance between:
        //   word1[i:] and word2[j:]
        int[] dp = new int[n + 1];

        // Base case: converting word2[j:] to empty string requires (n - j) deletions
        for (int j = 0; j <= n; j++) {
            dp[j] = n - j;
        }

        // Fill DP from bottom‑right to top‑left
        for (int i = m - 1; i >= 0; i--) {

            // nextDp represents dp[j] from the previous row (dp[i+1][j])
            int nextDp = dp[n];

            // dp[n] = cost of converting word1[i:] to empty string → (m - i) deletions
            dp[n] = m - i;

            for (int j = n - 1; j >= 0; j--) {

                // temp stores old dp[j] before overwriting it
                // This becomes dp[i+1][j] for the next iteration
                int temp = dp[j];

                if (word1[i] == word2[j]) {
                    // Characters match → no operation needed
                    // dp[i][j] = dp[i+1][j+1]
                    dp[j] = nextDp;
                } else {
                    // Characters differ → consider:
                    //   dp[j]     = delete from word1
                    //   dp[j+1]   = insert into word1
                    //   nextDp    = replace
                    dp[j] = 1 + Math.Min(dp[j], Math.Min(dp[j + 1], nextDp));
                }

                // Move diagonal reference forward
                nextDp = temp;
            }
        }

        // dp[0] = edit distance between full word1 and full word2
        return dp[0];
    }
}
