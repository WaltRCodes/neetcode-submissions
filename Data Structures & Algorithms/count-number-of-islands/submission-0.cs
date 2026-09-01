public class Solution {
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0},
        new int[] {0, 1}, new int[] {0, -1}
    };
    public int NumIslands(char[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int islands = 0;

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (grid[r][c] == '1') {
                    Dfs(grid, r, c);
                    islands++;
                }
            }
        }

        return islands;
    }

    private void Dfs(char[][] grid, int r, int c) {
        if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length || grid[r][c] == '0') {
            return;
        }

        grid[r][c] = '0';
        foreach (var dir in directions) {
            Dfs(grid, r + dir[0], c + dir[1]);
        }
    }
}
