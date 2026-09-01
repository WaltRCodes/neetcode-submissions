public class Solution {
    
    private int ROWS, COLS; // Dimensions of the board

    // Main function to check if the word exists in the board
    public bool Exist(char[][] board, string word) {
        ROWS = board.Length;
        COLS = board[0].Length;

        // Try starting DFS from every cell in the board
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (Dfs(board, word, r, c, 0)) {
                    return true; // Found the word
                }
            }
        }
        return false; // Word not found
    }

    // Helper function: DFS/backtracking
    private bool Dfs(char[][] board, string word, int r, int c, int i) {
        // Base case: all characters matched
        if (i == word.Length) {
            return true;
        }

        // Check boundaries and character match
        if (r < 0 || c < 0 || r >= ROWS || c >= COLS || board[r][c] != word[i] || board[r][c] == '#') {
            return false;
        }

        // Mark current cell as visited
        board[r][c] = '#';

        // Explore all 4 directions (up, down, left, right)
        bool res = Dfs(board, word, r + 1, c, i + 1) ||
                   Dfs(board, word, r - 1, c, i + 1) ||
                   Dfs(board, word, r, c + 1, i + 1) ||
                   Dfs(board, word, r, c - 1, i + 1);

        // Backtrack: restore original character
        board[r][c] = word[i];

        return res;
    }
}
