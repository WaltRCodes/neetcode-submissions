public class Solution {
    // HashSets to keep track of attacks
    HashSet<int> col = new HashSet<int>();       // Columns that already have queens
    HashSet<int> posDiag = new HashSet<int>();   // Positive diagonals (r + c)
    HashSet<int> negDiag = new HashSet<int>();   // Negative diagonals (r - c)
    
    List<List<string>> res = new List<List<string>>(); // Result list to store all solutions

    public List<List<string>> SolveNQueens(int n) {
        // Initialize the board with empty cells '.'
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++) {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }

        // Start backtracking from the first row
        Backtrack(0, n, board);
        return res;
    }

    private void Backtrack(int r, int n, char[][] board) {
        // Base case: all queens are placed
        if (r == n) {
            List<string> copy = new List<string>();
            foreach (char[] row in board) {
                copy.Add(new string(row)); // Convert row to string
            }
            res.Add(copy);
            return;
        }

        // Try placing a queen in each column of row r
        for (int c = 0; c < n; c++) {
            // Skip if column or diagonals are under attack
            if (col.Contains(c) || posDiag.Contains(r + c) || negDiag.Contains(r - c)) {
                continue;
            }

            // Place the queen
            col.Add(c);
            posDiag.Add(r + c);
            negDiag.Add(r - c);
            board[r][c] = 'Q';

            // Move to the next row
            Backtrack(r + 1, n, board);

            // Remove the queen (backtrack)
            col.Remove(c);
            posDiag.Remove(r + c);
            negDiag.Remove(r - c);
            board[r][c] = '.';
        }
    }
}
