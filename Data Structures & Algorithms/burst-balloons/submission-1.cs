public class Solution {
    public int MaxCoins(int[] nums) {

        int n = nums.Length;

        // Create a new array with padding:
        // newNums = [1, nums[0], nums[1], ..., nums[n-1], 1]
        // Padding with 1s simplifies boundary handling.
        int[] newNums = new int[n + 2];
        newNums[0] = newNums[n + 1] = 1;
        for (int i = 0; i < n; i++) {
            newNums[i + 1] = nums[i];
        }

        // dp[l, r] = maximum coins obtainable by bursting balloons
        // ONLY in the interval [l, r] (inclusive)
        int[,] dp = new int[n + 2, n + 2];

        // We fill the DP table by increasing interval length.
        // l goes from n → 1 so that smaller intervals are solved first.
        for (int l = n; l >= 1; l--) {
            for (int r = l; r <= n; r++) {

                // Try every balloon i in [l, r] as the *last* balloon to burst
                for (int i = l; i <= r; i++) {

                    // Coins gained from bursting balloon i last:
                    // newNums[l-1] and newNums[r+1] are the neighbors after all others in [l,r] are gone
                    int coins = newNums[l - 1] * newNums[i] * newNums[r + 1];

                    // Add coins from subintervals:
                    // dp[l, i-1] = best coins from left side
                    // dp[i+1, r] = best coins from right side
                    coins += dp[l, i - 1] + dp[i + 1, r];

                    // Maximize dp[l, r]
                    dp[l, r] = Math.Max(dp[l, r], coins);
                }
            }
        }

        // The answer is the best result for the full interval [1, n]
        return dp[1, n];
    }
}
