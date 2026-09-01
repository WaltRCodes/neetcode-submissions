public class Solution {
    // Directions for moving up, down, left, right
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0},
        new int[] {0, 1}, new int[] {0, -1}
    };

    public int NumIslands(char[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int islands = 0;

        // Iterate through each cell of the grid
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                // If we find land ('1'), perform DFS to mark the whole island
                if (grid[r][c] == '1') {
                    Dfs(grid, r, c);
                    islands++; // increment island count
                }
            }
        }

        return islands;
    }

    // Depth-First Search to mark all connected land cells
    private void Dfs(char[][] grid, int r, int c) {
        // Boundary check and check if current cell is water
        if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length || grid[r][c] == '0') {
            return;
        }

        grid[r][c] = '0'; // mark cell as visited

        // Explore all 4 directions
        foreach (var dir in directions) {
            Dfs(grid, r + dir[0], c + dir[1]);
        }
    }
}
