public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {

        // Result list to store the spiral traversal
        var res = new List<int>();

        // Directions in order: right, down, left, up
        // Each tuple represents (rowDelta, colDelta)
        var directions = new (int, int)[] {
            (0, 1),   // move right
            (1, 0),   // move down
            (0, -1),  // move left
            (-1, 0)   // move up
        };

        // Number of steps to take in horizontal and vertical directions.
        // First: number of columns
        // Second: number of rows minus one (because after the first row, you move down)
        var steps = new int[] { matrix[0].Length, matrix.Length - 1 };

        // Current position (start just outside the matrix on the left)
        int r = 0, c = -1;

        // Current direction index (0 = right)
        int d = 0;

        // Continue while there are steps left in the current direction type
        while (steps[d % 2] > 0) {

            // Move in the current direction for the required number of steps
            for (int i = 0; i < steps[d % 2]; i++) {
                r += directions[d].Item1;  // update row
                c += directions[d].Item2;  // update column
                res.Add(matrix[r][c]);     // record the value
            }

            // After completing a segment, reduce the step count
            steps[d % 2]--;

            // Rotate direction: right → down → left → up → right...
            d = (d + 1) % 4;
        }

        return res;
    }
}
