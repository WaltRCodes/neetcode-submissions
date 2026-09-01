public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        // List to store the result in spiral order
        List<int> res = new List<int>();

        // Define the boundaries of the current layer
        int left = 0;                    // Left column boundary
        int right = matrix[0].Length;    // Right column boundary (exclusive)
        int top = 0;                     // Top row boundary
        int bottom = matrix.Length;      // Bottom row boundary (exclusive)

        // Continue while there is a valid submatrix remaining
        while (left < right && top < bottom) {

            // 1. Traverse from left to right across the top row
            for (int i = left; i < right; i++) {
                res.Add(matrix[top][i]);
            }
            top++; // Move the top boundary down

            // 2. Traverse from top to bottom along the right column
            for (int i = top; i < bottom; i++) {
                res.Add(matrix[i][right - 1]);
            }
            right--; // Move the right boundary left

            // If boundaries have crossed, stop to avoid duplicate traversal
            if (!(left < right && top < bottom)) {
                break;
            }

            // 3. Traverse from right to left across the bottom row
            for (int i = right - 1; i >= left; i--) {
                res.Add(matrix[bottom - 1][i]);
            }
            bottom--; // Move the bottom boundary up

            // 4. Traverse from bottom to top along the left column
            for (int i = bottom - 1; i >= top; i--) {
                res.Add(matrix[i][left]);
            }
            left++; // Move the left boundary right
        }

        // Return the collected spiral order elements
        return res;
    }
}