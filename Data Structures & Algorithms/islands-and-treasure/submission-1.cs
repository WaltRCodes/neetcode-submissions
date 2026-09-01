public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        // Queue for BFS traversal
        Queue<int[]> q = new Queue<int[]>();

        int m = grid.Length;       // number of rows
        int n = grid[0].Length;    // number of columns

        // Step 1: Enqueue all islands (cells with value 0)
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) q.Enqueue(new int[] {i,j});
            }
        }

        // If there are no islands, nothing to do
        if (q.Count == 0) return;

        // Directions for exploring neighbors (up, left, down, right)
        int[][] dirs = {
            new int[] {-1,0}, new int[] {0,-1},
            new int[] {1,0}, new int[] {0,1}
        };

        // Step 2: BFS from all islands simultaneously
        while (q.Count > 0) {
            int[] cur = q.Dequeue();
            int row = cur[0];
            int col = cur[1];

            foreach (int[] dir in dirs) {
                int r = row + dir[0];
                int c = col + dir[1];

                // Skip out-of-bound cells or already visited/non-empty cells
                if (r >= m || c >= n || r < 0 || c < 0 || grid[r][c] != int.MaxValue) {
                    continue;
                }

                // Enqueue the neighbor for BFS
                q.Enqueue(new int[] {r,c});

                // Update the distance to nearest island
                grid[r][c] = grid[row][col] + 1;
            }
        }
    }
}
