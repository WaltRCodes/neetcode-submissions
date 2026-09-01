public class Solution {
    public int UniquePaths(int m, int n) {

        // If either dimension is 1, there is only one possible path
        if (m == 1 || n == 1) {
            return 1;
        }

        // Ensure m >= n to minimize the number of iterations.
        // This reduces overflow risk and improves efficiency.
        if (m < n) {
            int temp = m;
            m = n;
            n = temp;
        }

        // We are computing the binomial coefficient:
        //     C(m+n-2, n-1)
        //
        // Instead of computing factorials directly (which overflow),
        // we build the result multiplicatively:
        //
        //     res = (m * (m+1) * ... * (m+n-2)) / (1 * 2 * ... * (n-1))
        long res = 1;
        int j = 1;

        // Multiply numerator terms and divide by denominator terms step‑by‑step
        for (int i = m; i < m + n - 1; i++) {
            res *= i;   // multiply by next numerator term
            res /= j;   // divide by next denominator term
            j++;
        }

        // Result fits in 32‑bit int for all valid constraints
        return (int)res;
    }
}
