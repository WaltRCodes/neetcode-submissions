public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        bool[][] visit = new bool[n][];
        for (int i = 0; i < n; i++){
            visit[i] = new bool[n];
        }
        int minH = grid[0][0], maxH = grid[0][0];
        for (int row = 0; row < n; row++){
            for (int col = 0; col < n; col++){
                maxH = Math.Max(maxH, grid[row][col]);
                minH = Math.Min(minH, grid[row][col]);
            }
        }
        int l = minH, r = maxH;
        while (l < r) {
            int m = (l + r) >> 1;
            if(dfs(grid, visit, 0, 0, m)){
                r = m;
            } else {
                l = m + 1;
            }
            for(int row = 0; row < n; row++){
                Array.Fill(visit[row], false);
            }
        }
        return r;
    }
    private bool dfs(int[][] grid, bool[][] visit, int r, int c, int t) {
        if (r < 0 || c < 0 || r >= grid.Length || c >= grid.Length || visit[r][c] || grid[r][c] > t){
            return false;
        }
        if (r == grid.Length - 1 && c == grid.Length -1) {
            return true;
        }
        visit[r][c] = true;
        return dfs(grid, visit, r+1, c, t) || dfs(grid, visit, r-1, c, t) || dfs(grid, visit, r, c+1, t) || dfs(grid, visit, r, c-1, t);
    }
}
