public class Solution {
    public int CoinChange(int[] coins, int amount) {

        // dp[i] = minimum number of coins needed to make amount i
        // Initialize all values to amount+1 (an impossible large value),
        // because the worst case can never exceed amount coins of value 1.
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);

        // Base case: 0 coins are needed to make amount 0
        dp[0] = 0;

        // Build the solution for all amounts from 1 to 'amount'
        for (int i = 1; i <= amount; i++) {

            // Try every coin and see if it can contribute to amount i
            foreach (int coin in coins) {

                // Only consider this coin if it does not exceed the current amount
                if (coin <= i) {

                    // dp[i - coin] is the best way to form the remaining amount
                    // Add 1 coin to that result
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        // If dp[amount] is still larger than amount, it means no solution was found
        return dp[amount] > amount ? -1 : dp[amount];
    }
}
