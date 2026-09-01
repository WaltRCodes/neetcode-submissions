public class Solution {

    // Four possible movement directions: up, down, left, right
    int[][] directions = new int[][] {
        new int[] {-1, 0}, new int[] {1, 0},
        new int[] {0, -1}, new int[] {0, 1}
    };

    // Memoization table: dp[r, c] = longest increasing path starting at (r, c)
    int[,] dp;

    // Depth‑first search that returns the longest increasing path starting at (r, c)
    private int Dfs(int[][] matrix, int r, int c, int prevVal) {

        int ROWS = matrix.Length, COLS = matrix[0].Length;

        // Out of bounds OR not strictly increasing → stop
        if (r < 0 || r >= ROWS || c < 0 || c >= COLS || matrix[r][c] <= prevVal) {
            return 0;
        }

        // If already computed, return memoized result
        if (dp[r, c] != -1) return dp[r, c];

        // At minimum, the path length is 1 (the current cell)
        int res = 1;

        // Explore all four directions
        foreach (int[] d in directions) {
            int nr = r + d[0];
            int nc = c + d[1];

            // Try extending the path and take the best result
            res = Math.Max(res, 1 + Dfs(matrix, nr, nc, matrix[r][c]));
        }

        // Store result in memo table
        dp[r, c] = res;
        return res;
    }

    public int LongestIncreasingPath(int[][] matrix) {

        int ROWS = matrix.Length, COLS = matrix[0].Length;

        // Initialize memo table with -1 (meaning "uncomputed")
        dp = new int[ROWS, COLS];
        for (int i = 0; i < ROWS; i++) {
            for (int j = 0; j < COLS; j++) {
                dp[i, j] = -1;
            }
        }

        int LIP = 0; // Longest Increasing Path found so far

        // Run DFS from every cell
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                LIP = Math.Max(LIP, Dfs(matrix, r, c, int.MinValue));
            }
        }

        return LIP;
    }
}
