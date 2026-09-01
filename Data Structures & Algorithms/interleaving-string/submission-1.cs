public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {

        int m = s1.Length, n = s2.Length;

        // If lengths don't add up, interleaving is impossible
        if (m + n != s3.Length) return false;

        // Always make s2 the longer string so dp[] is as small as possible
        if (n < m) {
            var temp = s1; s1 = s2; s2 = temp;
            int tempLen = m; m = n; n = tempLen;
        }

        // dp[j] = whether s1[i:] and s2[j:] can form s3[i+j:]
        bool[] dp = new bool[n + 1];

        // Base case: both strings empty → valid interleave
        dp[n] = true;

        // Iterate from bottom‑right of the DP table toward top‑left
        for (int i = m; i >= 0; i--) {

            // nextDp represents dp[j+1] from the previous iteration of j
            // When i == m, s1 is exhausted, so nextDp starts as true only at j == n
            bool nextDp = (i == m ? true : false);

            for (int j = n; j >= 0; j--) {

                // Start with the diagonal or right value depending on boundaries
                bool res = (j < n ? false : nextDp);

                // Option 1: take from s1 if characters match and dp[j] was true
                if (i < m && s1[i] == s3[i + j] && dp[j]) {
                    res = true;
                }

                // Option 2: take from s2 if characters match and nextDp was true
                if (j < n && s2[j] == s3[i + j] && nextDp) {
                    res = true;
                }

                // Update dp[j] for this (i, j)
                dp[j] = res;

                // Move nextDp leftward (nextDp becomes dp[j])
                nextDp = dp[j];
            }
        }

        // dp[0] tells whether s1[0:] + s2[0:] can form s3
        return dp[0];
    }
}
