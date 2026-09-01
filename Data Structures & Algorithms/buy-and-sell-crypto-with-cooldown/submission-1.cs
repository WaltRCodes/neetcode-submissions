public class Solution {
    public int MaxProfit(int[] prices) {

        int n = prices.Length;

        // dp1_buy  = max profit starting at day i+1 when we are allowed to BUY (1st or 2nd buy)
        // dp1_sell = max profit starting at day i+1 when we are allowed to SELL (after a buy)
        // dp2_buy  = dp1_buy from the next day (used to compute dp_sell)

        int dp1_buy = 0, dp1_sell = 0;
        int dp2_buy = 0;

        // Iterate from right → left (future → past)
        for (int i = n - 1; i >= 0; i--) {

            // If we are allowed to BUY at day i:
            // Option 1: Buy now → -prices[i] + dp1_sell (next state is SELL)
            // Option 2: Skip buying → dp1_buy (stay in BUY state)
            int dp_buy = Math.Max(dp1_sell - prices[i], dp1_buy);

            // If we are allowed to SELL at day i:
            // Option 1: Sell now → +prices[i] + dp2_buy (next state is BUY for next transaction)
            // Option 2: Skip selling → dp1_sell (stay in SELL state)
            int dp_sell = Math.Max(dp2_buy + prices[i], dp1_sell);

            // Slide DP window forward
            dp2_buy = dp1_buy;  // dp2_buy becomes yesterday’s dp1_buy
            dp1_buy = dp_buy;   // update buy state
            dp1_sell = dp_sell; // update sell state
        }

        // dp1_buy at day 0 = max profit with up to 2 transactions
        return dp1_buy;
    }
}
