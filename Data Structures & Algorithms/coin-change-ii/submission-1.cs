public class Solution {
    public int Change(int amount, int[] coins) {

        // dp[a] = number of ways to make amount 'a'
        int[] dp = new int[amount + 1];

        // Base case: there is exactly 1 way to make amount 0 — choose no coins
        dp[0] = 1;

        // Process coins one at a time (outer loop ensures combinations, not permutations)
        for (int i = coins.Length - 1; i >= 0; i--) {

            // For each coin, update all reachable amounts
            for (int a = 1; a <= amount; a++) {

                // If the coin can contribute to amount 'a'
                if (coins[i] <= a) {

                    // Add the number of ways to form the remaining amount
                    dp[a] += dp[a - coins[i]];
                }
            }
        }

        // dp[amount] now holds the total number of combinations
        return dp[amount];
    }
}
