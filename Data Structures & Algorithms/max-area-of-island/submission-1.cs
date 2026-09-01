public class Solution {
    // Directions for moving up, down, left, right
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0},
        new int[] {0, 1}, new int[] {0, -1}
    };

    public int MaxAreaOfIsland(int[][] grid) {
        int ROWS = grid.Length, COLS = grid[0].Length;
        int area = 0;

        // Iterate through each cell in the grid
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                // If cell is land (1), compute area using BFS
                if (grid[r][c] == 1) {
                    area = Math.Max(area, BFS(grid, r, c));
                }
            }
        }
        return area;
    }

    // BFS to compute the area of the island starting at (r, c)
    private int BFS(int[][] grid, int r, int c){
        Queue<int[]> q = new Queue<int[]>();
        grid[r][c] = 0; // mark as visited
        q.Enqueue(new int[] {r, c});
        int res = 1; // start with area = 1

        while (q.Count > 0) {
            var node = q.Dequeue();
            int row = node[0], col = node[1];

            // Explore all 4 directions
            foreach (var dir in directions) {
                int nr = row + dir[0], nc = col + dir[1];
                // If new cell is valid and land, add to queue and mark visited
                if (nr >= 0 && nc >= 0 && nr < grid.Length && nc < grid[0].Length && grid[nr][nc] == 1) {
                    q.Enqueue(new int[] {nr, nc});
                    grid[nr][nc] = 0; // mark visited
                    res++;
                }
            }
        }
        return res;
    }
}
