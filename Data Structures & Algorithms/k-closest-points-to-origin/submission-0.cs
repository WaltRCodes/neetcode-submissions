public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        int L = 0, R = points.Length - 1;
        int pivot = points.Length;

        while (pivot != k) {
            pivot = Partition(points, L, R);
            if (pivot < k) {
                L = pivot + 1;
            } else {
                R = pivot - 1;
            }
        }
        int[][] res = new int[k][];
        Array.Copy(points, res, k);
        return res;
    }

    private int Partition(int[][] points, int l, int r) {
        int pivotIdx = r;
        int pivotDist = Euclidean(points[pivotIdx]);
        int i = l;
        for(int j = l; j < r; j++) {
            if (Euclidean(points[j]) <= pivotDist) {
                Swap(points, i, j);
                i++;
            }
        }
        Swap(points, i, r);
        return i;
    }

    private int Euclidean(int[] point) {
        return point[0] * point[0] + point[1]* point[1];
    }

    private void Swap(int[][] points, int i, int j) {
        int[] temp = points[i];
        points[i] = points[j];
        points[j] = temp;
    }
}
