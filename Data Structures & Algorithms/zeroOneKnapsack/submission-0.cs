public class Solution {
    public int MaximumProfit(List<int> profit, List<int> weight, int capacity) {
        int N = profit.Count, M = capacity;
        int[] dp = new int[M+1];
        Array.Fill(dp, 0);

        for (int c = 0; c <= M; c++){
            if(weight[0] <= c) {
                dp[c] = profit[0];
            }
        }

        for (int i = 1; i < N; i++){
            int[] curRow = new int[M+1];
            Array.Fill(curRow,0);
            for (int c = 1; c <= M; c++) {
                int skip = dp[c];
                int include = 0;
                if (c - weight[i] >= 0) {
                    include = profit[i] + dp[c - weight[i]];
                }
                curRow[c] = Math.Max(include, skip);
            }
            dp = curRow;
        }
        return dp[M];
    } 
}
