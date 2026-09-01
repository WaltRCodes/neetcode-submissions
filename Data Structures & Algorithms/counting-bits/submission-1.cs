public class Solution {
    public int[] CountBits(int n) {

        // dp[i] will store the number of 1‑bits in the binary representation of i
        int[] dp = new int[n + 1];

        // Start from 1 because dp[0] is already 0
        for (int i = 1; i <= n; i++) {

            // i >> 1   → i divided by 2 (drops the last bit)
            // i & 1    → 1 if the last bit is 1, otherwise 0
            //
            // Example:
            //   i = 13 (1101)
            //   i >> 1 = 6 (110)
            //   i & 1 = 1
            //
            // So dp[13] = dp[6] + 1
            dp[i] = dp[i >> 1] + (i & 1);
        }

        return dp;
    }
}
