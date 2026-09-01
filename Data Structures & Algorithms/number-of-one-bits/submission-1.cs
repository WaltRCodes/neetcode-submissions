public class Solution {
    public int HammingWeight(uint n) {

        int res = 0;

        // Brian Kernighan’s algorithm:
        // Each iteration removes the lowest‑set (rightmost 1) bit from n.
        //
        // Why it works:
        //   n & (n - 1) clears the lowest 1 bit in n.
        //   Example:
        //       n      = 101100
        //       n - 1  = 101011
        //       n&(n-1)= 101000   (lowest 1 removed)
        //
        // So the number of times we can do this until n becomes 0
        // is exactly the number of 1 bits in the original number.
        while (n != 0) {
            n = n & (n - 1);  // drop the lowest set bit
            res++;            // count that bit
        }

        return res;
    }
}
