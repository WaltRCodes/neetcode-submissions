public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;

        // Visited matrix reused for each DFS attempt
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++) {
            visit[i] = new bool[n];
        }

        // Find the minimum and maximum heights in the grid.
        // These form the search range for the required water level.
        int minH = grid[0][0], maxH = grid[0][0];
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                maxH = Math.Max(maxH, grid[row][col]);
                minH = Math.Min(minH, grid[row][col]);
            }
        }

        // Binary search on the minimum time t such that
        // you can reach (n-1, n-1) when water level = t.
        int l = minH, r = maxH;
        while (l < r) {
            int m = (l + r) >> 1;   // mid water level

            // If DFS can reach the end with max allowed height m,
            // try a smaller value.
            if (dfs(grid, visit, 0, 0, m)) {
                r = m;
            } else {
                l = m + 1;
            }

            // Reset visited array for the next DFS attempt
            for (int row = 0; row < n; row++) {
                Array.Fill(visit[row], false);
            }
        }

        return r;  // the smallest feasible water level
    }

    // DFS checks whether we can reach the bottom‑right cell
    // without stepping on any cell with height > t.
    private bool dfs(int[][] grid, bool[][] visit, int r, int c, int t) {

        // Out of bounds, already visited, or too high → cannot proceed
        if (r < 0 || c < 0 || r >= grid.Length || c >= grid.Length ||
            visit[r][c] || grid[r][c] > t) {
            return false;
        }

        // Reached destination
        if (r == grid.Length - 1 && c == grid.Length - 1) {
            return true;
        }

        visit[r][c] = true;

        // Explore all four directions
        return dfs(grid, visit, r + 1, c, t) ||
               dfs(grid, visit, r - 1, c, t) ||
               dfs(grid, visit, r, c + 1, t) ||
               dfs(grid, visit, r, c - 1, t);
    }
}
