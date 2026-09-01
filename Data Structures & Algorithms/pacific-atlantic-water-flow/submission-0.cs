public class Solution {
    private int[][] directions = new int[][] {
        new int[] {1,0}, new int[] {-1,0}, new int[] {0,1}, new int[] {0,-1}
    };
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int ROWS = heights.Length, COLS = heights[0].Length;
        bool[,] pac = new bool[ROWS, COLS];
        bool[,] atl = new bool[ROWS, COLS];

        for (int c = 0; c < COLS; c++) {
            DFS(0, c, pac, heights);
            DFS(ROWS - 1, c, atl, heights);
        }
        for (int r = 0; r < ROWS; r++){
            DFS(r, 0, pac, heights);
            DFS(r, COLS - 1, atl, heights);
        }

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

    private void DFS(int r, int c, bool[,] ocean, int[][] heights) {
        ocean[r,c] = true;
        foreach (var dir in directions) {
            int nr = r + dir[0], nc = c + dir[1];
            if (nr >= 0 && nr < heights.Length && nc >= 0 && nc < heights[0].Length && !ocean[nr,nc] && heights[nr][nc] >= heights[r][c]){
                DFS(nr,nc,ocean,heights);
            }
        }
    }
}
