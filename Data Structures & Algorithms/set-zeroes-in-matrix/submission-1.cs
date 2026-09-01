public class Solution {
    public void SetZeroes(int[][] matrix) {

        // Get matrix dimensions
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        // Arrays to mark which rows and columns must be zeroed
        bool[] rowZero = new bool[rows];
        bool[] colZero = new bool[cols];

        // First pass:
        // Identify all rows and columns that contain at least one zero.
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (matrix[r][c] == 0) {
                    rowZero[r] = true;   // mark entire row for zeroing
                    colZero[c] = true;   // mark entire column for zeroing
                }
            }
        }

        // Second pass:
        // Set cells to zero if their row or column was marked.
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (rowZero[r] || colZero[c]) {
                    matrix[r][c] = 0;
                }
            }
        }
    }
}
