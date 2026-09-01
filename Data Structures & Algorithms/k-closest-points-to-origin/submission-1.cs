public class Solution {

    // Returns the k closest points to the origin
    public int[][] KClosest(int[][] points, int k) {
        int L = 0, R = points.Length - 1;
        int pivot = points.Length;

        // Quickselect loop: partition until the pivot index equals k
        while (pivot != k) {
            pivot = Partition(points, L, R);

            // If pivot is less than k, search right part
            if (pivot < k) {
                L = pivot + 1;
            } 
            // If pivot is greater than k, search left part
            else {
                R = pivot - 1;
            }
        }

        // Copy the first k points (closest points) into result array
        int[][] res = new int[k][];
        Array.Copy(points, res, k);
        return res;
    }

    // Partition the array similar to quicksort
    private int Partition(int[][] points, int l, int r) {
        int pivotIdx = r;
        int pivotDist = Euclidean(points[pivotIdx]); // distance of pivot
        int i = l;

        for(int j = l; j < r; j++) {
            if (Euclidean(points[j]) <= pivotDist) { // points closer than pivot
                Swap(points, i, j); // move it to left part
                i++;
            }
        }

        Swap(points, i, r); // place pivot in correct position
        return i; // return pivot index
    }

    // Compute squared Euclidean distance from origin
    private int Euclidean(int[] point) {
        return point[0] * point[0] + point[1]* point[1];
    }

    // Swap two points in the array
    private void Swap(int[][] points, int i, int j) {
        int[] temp = points[i];
        points[i] = points[j];
        points[j] = temp;
    }
}
