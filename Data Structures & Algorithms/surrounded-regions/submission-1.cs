public class Solution {
    private int ROWS, COLS;
    // Directions: down, right, up, left
    private int[][] directions = new int[][] {
        new int[] {1,0}, new int[] {0,1}, new int[] {-1,0}, new int[] {0,-1}
    };

    public void Solve(char[][] board) {
        ROWS = board.Length;
        COLS = board[0].Length;

        // Step 1: Capture all 'O's connected to borders using BFS
        Capture(board);

        // Step 2: Flip all remaining 'O's to 'X' and restore border-connected 'O's
        for (int r = 0; r < ROWS; r++) {
            for(int c = 0; c < COLS; c++){
                if(board[r][c] == 'O'){
                    board[r][c] = 'X'; // Surrounded region
                } else if (board[r][c] == 'T'){
                    board[r][c] = 'O'; // Border-connected region
                }
            }
        }
    }

    private void Capture(char[][] board) {
        Queue<int[]> q = new Queue<int[]>();

        // Enqueue all 'O's on the border
        for(int r = 0; r < ROWS; r++){
            for(int c = 0; c < COLS; c++) {
                if ((r == 0 || r == ROWS - 1 || c == 0 || c == COLS - 1) && board[r][c] == 'O') {
                    q.Enqueue(new int[] {r,c});
                }
            }
        }

        // BFS from border 'O's
        while(q.Count > 0) {
            int[] cell = q.Dequeue();
            int r = cell[0], c = cell[1];
            if (board[r][c] == 'O'){
                board[r][c] = 'T'; // Temporarily mark as safe
                foreach (var direction in directions) {
                    int nr = r + direction[0];
                    int nc = c + direction[1];
                    // Enqueue neighbors within bounds
                    if (nr >= 0 && nr < ROWS && nc >= 0 && nc < COLS){
                        q.Enqueue(new int[] {nr,nc});
                    }
                }
            }
        }
    }
}
