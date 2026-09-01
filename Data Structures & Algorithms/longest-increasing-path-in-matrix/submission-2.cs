public class Solution {

    // Four movement directions: down, up, right, left.
    // Using a static readonly array avoids reallocation on every DFS call.
    private static readonly int[][] DIRS = new int[][] {
        new[] { 1, 0 },   // down
        new[] { -1, 0 },  // up
        new[] { 0, 1 },   // right
        new[] { 0, -1 }   // left
    };

    // memo[r, c] stores the length of the longest increasing path
    // starting from cell (r, c). A value of 0 means "not computed yet".
    private int[,] memo;

    private int rows, cols;

    public int LongestIncreasingPath(int[][] matrix) {
        rows = matrix.Length;
        cols = matrix[0].Length;

        // Allocate memo table; default values are 0 (uncomputed).
        memo = new int[rows, cols];

        int best = 0;

        // Try starting a path from every cell in the matrix.
        // DFS + memoization ensures each cell is computed once.
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                best = Math.Max(best, DFS(matrix, r, c));
            }
        }

        return best;
    }

    private int DFS(int[][] matrix, int r, int c) {

        // If we've already computed the best path from this cell,
        // return the cached value immediately.
        if (memo[r, c] != 0)
            return memo[r, c];

        // Minimum path length is 1 (the cell itself).
        int best = 1;

        // Explore all four directions.
        foreach (var d in DIRS) {
            int nr = r + d[0];
            int nc = c + d[1];

            // Check bounds AND ensure the next cell is strictly increasing.
            if (nr >= 0 && nr < rows &&
                nc >= 0 && nc < cols &&
                matrix[nr][nc] > matrix[r][c]) {

                // Recursively compute the best path from the neighbor.
                // Add 1 to include the current cell.
                best = Math.Max(best, 1 + DFS(matrix, nr, nc));
            }
        }

        // Store the computed result so future calls are O(1).
        memo[r, c] = best;
        return best;
    }
}
