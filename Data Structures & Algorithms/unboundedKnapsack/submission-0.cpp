class Solution {
public:
    int maximumProfit(vector<int>& profit, vector<int>& weight, int capacity) {
        int N = profit.size(), M = capacity;
        vector<int> dp(M + 1, 0);

        for (int i = 0; i < N; i++) {
            vector<int> curRow(M + 1, 0);
            for (int c = 1; c <= M; c++) {
                int skip = dp[c];
                int include = 0;
                if (c - weight[i] >= 0) {
                    include = profit[i] + curRow[c - weight[i]];
                }
                curRow[c] = max(include, skip);
            }
            dp = curRow;
        }
        return dp[M];
    }
};
