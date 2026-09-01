public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        var res = new List<int>();
        var directions = new (int, int)[] {(0,1),(1,0),(0,-1),(-1,0)};
        var steps = new int[] {matrix[0].Length, matrix.Length - 1};

        int r = 0, c = -1, d = 0;
        while (steps[d % 2] > 0){
            for(int i = 0; i < steps[d % 2]; i++){
                r += directions[d].Item1;
                c += directions[d].Item2;
                res.Add(matrix[r][c]);
            }
            steps[d % 2]--;
            d = (d + 1) % 4;
        }
        return res;
    }
}
