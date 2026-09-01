public class Solution {
    private int ROWS, COLS;
    private int[][] directions = new int[][] {
        new int[] {1,0}, new int[] {0,1}, new int[] {-1,0}, new int[] {0,-1}
    };
    public void Solve(char[][] board) {
        ROWS = board.Length;
        COLS = board[0].Length;

        Capture(board);

        for (int r = 0; r < ROWS; r++) {
            for(int c = 0; c < COLS; c++){
                if(board[r][c] == 'O'){
                    board[r][c] = 'X';
                } else if (board[r][c] == 'T'){
                    board[r][c] = 'O';
                }
            }
        }
    }
    private void Capture(char[][] board) {
        Queue<int[]> q = new Queue<int[]>();
        for(int r = 0; r < ROWS; r++){
            for(int c = 0; c < COLS; c++) {
                if (r == 0 || r == ROWS - 1 || c == 0 || c == COLS - 1 && board[r][c] == 'O') {
                    q.Enqueue(new int[] {r,c});
                }
            }
        }
        while(q.Count > 0) {
            int[] cell = q.Dequeue();
            int r = cell[0], c = cell[1];
            if (board[r][c] == 'O'){
                board[r][c] = 'T';
                foreach (var direction in directions) {
                    int nr = r + direction[0];
                    int nc = c + direction[1];
                    if (nr >= 0 && nr < ROWS && nc >= 0 && nc < COLS){
                        q.Enqueue(new int[] {nr,nc});
                    }
                }
            }
        }
    }
}
