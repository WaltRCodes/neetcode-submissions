public class Solution {
    public int OrangesRotting(int[][] grid) {
        // Queue to perform BFS on rotten oranges
        Queue<int[]> q = new Queue<int[]>();
        int fresh = 0; // Count of fresh oranges
        int time = 0;  // Minutes elapsed

        // Step 1: Initialize queue with positions of rotten oranges and count fresh oranges
        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++){
                if (grid[r][c] == 1){
                    fresh++; // Count fresh orange
                }
                if (grid[r][c] == 2) {
                    q.Enqueue(new int[] {r,c}); // Enqueue rotten orange
                }
            }
        }

        // Directions for adjacent cells (up, down, left, right)
        int[][] directions = {
            new int[] {0,1}, new int[] {0,-1}, 
            new int[] {1,0}, new int[] {-1,0}
        };

        // Step 2: BFS to rot adjacent fresh oranges
        while (fresh > 0 && q.Count > 0){
            int length = q.Count; // Process all rotten oranges at current time
            for (int i = 0; i < length; i++){
                int[] curr = q.Dequeue();
                int r = curr[0];
                int c = curr[1];

                foreach (int[] dir in directions){
                    int row = r + dir[0];
                    int col = c + dir[1];

                    // Rot the fresh orange if it's within bounds
                    if (row >= 0 && row < grid.Length && col >= 0 && col < grid[0].Length && grid[row][col] == 1){
                        grid[row][col] = 2;      // Orange becomes rotten
                        q.Enqueue(new int[] {row, col}); // Add newly rotten orange to queue
                        fresh--; // Decrease count of fresh oranges
                    }
                }
            }
            time++; // Increment minutes after processing current layer
        }

        // If all oranges are rotten, return time, otherwise return -1
        return fresh == 0 ? time : -1;
    }
}
