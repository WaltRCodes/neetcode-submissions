public class Solution {
    public void Rotate(int[][] matrix) {

        // Step 1: Reverse the rows of the matrix.
        // This flips the matrix vertically.
        // Example:
        // [1 2 3]        [7 8 9]
        // [4 5 6]   →    [4 5 6]
        // [7 8 9]        [1 2 3]
        Array.Reverse(matrix);

        // Step 2: Transpose the matrix.
        // Swap elements across the diagonal (i, j) ↔ (j, i).
        // Combined with the vertical flip, this results in a 90° clockwise rotation.
        for (int i = 0; i < matrix.Length; i++) {
            for (int j = i; j < matrix[i].Length; j++) {

                // Swap matrix[i][j] with matrix[j][i]
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }
    }
}
