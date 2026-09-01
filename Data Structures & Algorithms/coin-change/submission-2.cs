public class Solution {

    // Memoization cache:
    // Key   = remaining amount
    // Value = minimum coins needed to form that amount
    private Dictionary<int, int> memo = new Dictionary<int, int>();

    // Depth‑first search that returns the minimum number of coins
    // needed to form "amount" using unlimited copies of coins[]
    private int Dfs(int amount, int[] coins) {

        // Base case: exact amount formed
        if (amount == 0) 
            return 0;

        // If we've already computed this amount, reuse it
        if (memo.ContainsKey(amount))
            return memo[amount];

        // Start with "infinity" — meaning we haven't found a valid solution yet
        int res = int.MaxValue;

        // Try every coin
        foreach (int coin in coins) {

            // Only recurse if the coin does not overshoot the amount
            if (amount - coin >= 0) {

                // Recursively compute the minimum coins for the remaining amount
                int result = Dfs(amount - coin, coins);

                // If the recursive call found a valid solution,
                // update the best (minimum) result
                if (result != int.MaxValue) {
                    res = Math.Min(res, 1 + result);
                }
            }
        }

        // Store the computed result (even if it's int.MaxValue)
        memo[amount] = res;
        return res;
    }

    public int CoinChange(int[] coins, int amount) {

        // Run DFS with memoization to compute the minimum coins
        int minCoins = Dfs(amount, coins);

        // If no valid combination was found, return -1
        return minCoins == int.MaxValue ? -1 : minCoins;
    }
}
