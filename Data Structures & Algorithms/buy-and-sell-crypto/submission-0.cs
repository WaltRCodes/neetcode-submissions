public class Solution {
    public int MaxProfit(int[] prices) {
        int l = 0, r = 1;
        int maxP = 0;
        while (r< prices.Length){
            if (prices[l]<prices[r]){
            int profit = prices[r] - prices [l];
            maxP = Math.Max(maxP, profit);
        } else {
            l = r;
        }
        r++;
    }
        return maxP;
    }
} 
