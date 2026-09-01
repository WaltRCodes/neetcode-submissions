public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {

        // Always make text1 the longer string.
        // This keeps the DP array as small as possible.
        if (text1.Length < text2.Length) {
            string temp = text1;
            text1 = text2;
            text2 = temp;
        }

        // dp[j] = LCS length for text1[i:] and text2[j:]
        // We only store one row of DP at a time.
        int[] dp = new int[text2.Length + 1];

        // Iterate text1 from right → left
        for (int i = text1.Length - 1; i >= 0; i--) {

            // prev = dp[j+1] from the previous iteration of j
            // This represents the diagonal value dp[i+1][j+1]
            int prev = 0;

            // Iterate text2 from right → left
            for (int j = text2.Length - 1; j >= 0; j--) {

                // temp stores the old dp[j] before we overwrite it
                // This becomes the next "prev" (diagonal) value
                int temp = dp[j];

                if (text1[i] == text2[j]) {
                    // Characters match → take diagonal + 1
                    dp[j] = 1 + prev;
                } else {
                    // Characters don't match → take max(right, down)
                    dp[j] = Math.Max(dp[j], dp[j + 1]);
                }

                // Move diagonal reference forward
                prev = temp;
            }
        }

        // dp[0] now holds LCS(text1, text2)
        return dp[0];
    }
}
