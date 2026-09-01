public class Solution {
    // Directions: down, up, right, left
    private int[][] directions = new int[][] {
        new int[] {1,0}, new int[] {-1,0}, new int[] {0,1}, new int[] {0,-1}
    };

    public List<List<int>> PacificAtlantic(int[][] heights) {
        int ROWS = heights.Length, COLS = heights[0].Length;

        // Boolean matrices to mark cells reachable by Pacific and Atlantic oceans
        bool[,] pac = new bool[ROWS, COLS];
        bool[,] atl = new bool[ROWS, COLS];

        // Step 1: Start DFS from Pacific (top row & left column) and Atlantic (bottom row & right column)
        for (int c = 0; c < COLS; c++) {
            DFS(0, c, pac, heights);          // Top row -> Pacific
            DFS(ROWS - 1, c, atl, heights);   // Bottom row -> Atlantic
        }
        for (int r = 0; r < ROWS; r++){
            DFS(r, 0, pac, heights);          // Left column -> Pacific
            DFS(r, COLS - 1, atl, heights);   // Right column -> Atlantic
        }

        // Step 2: Collect cells reachable by both oceans
        List<List<int>> res = new List<List<int>>();
        for (int r = 0; r < ROWS; r++){
            for (int c = 0; c < COLS; c++) {
                if (pac[r, c] && atl[r,c]) {
                    res.Add(new List<int> {r,c});
                }
            }
        }
        return res;
    }

    // DFS to mark all cells reachable by an ocean
    private void DFS(int r, int c, bool[,] ocean, int[][] heights) {
        ocean[r,c] = true; // Mark current cell as reachable
        foreach (var dir in directions) {
            int nr = r + dir[0], nc = c + dir[1];
            // Continue DFS if next cell is in bounds, not visited, and height is >= current
            if (nr >= 0 && nr < heights.Length && nc >= 0 && nc < heights[0].Length &&
                !ocean[nr,nc] && heights[nr][nc] >= heights[r][c]){
                DFS(nr,nc,ocean,heights);
            }
        }
    }
}
