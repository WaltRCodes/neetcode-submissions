public class Solution {
    int[][] directions = new int[][] {
        new int[] {-1,0}, new int[] {1,0},
        new int[] {0,-1}, new int[] {0,1}
    };
    int[,] dp;
    private int Dfs(int[][] matrix, int r, int c, int prevVal){
        int ROWS = matrix.Length, COLS = matrix[0].Length;
        if (r < 0 || r >= ROWS || c < 0 || c >= COLS || matrix[r][c] <= prevVal){
            return 0;
        }
        if (dp[r,c] != -1) return dp[r,c];

        int res = 1;
        foreach (int[] d in directions) {
            res = Math.Max(res, 1 + Dfs(matrix, r + d[0], c + d[1], matrix[r][c]));
        }
        dp[r,c] = res;
        return res;
    }
    public int LongestIncreasingPath(int[][] matrix) {
        int ROWS = matrix.Length, COLS = matrix[0].Length;
        dp = new int[ROWS, COLS];
        for (int i = 0; i < ROWS; i++){
            for(int j = 0; j < COLS; j++) {
                dp[i, j] = -1;
            }
        }
        int LIP = 0;
        for(int r = 0; r < ROWS; r++){
            for (int c = 0; c < COLS; c++){
                LIP = Math.Max(LIP, Dfs(matrix, r,c, int.MinValue));
            }
        }
        return LIP;
    }
}
