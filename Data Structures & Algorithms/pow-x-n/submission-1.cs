public class Solution {
    public double MyPow(double x, int n) {

        // Handle simple base cases
        if (x == 0) return 0;   // 0 raised to anything is 0
        if (n == 0) return 1;   // x^0 = 1

        double res = 1;

        // Convert n to long before taking abs, because Math.Abs(int.MinValue)
        // overflows. Using long avoids that.
        long power = Math.Abs((long)n);

        // Fast exponentiation (binary exponentiation)
        // Repeatedly square x and multiply it into the result when needed.
        while (power > 0) {

            // If the lowest bit of power is 1, multiply res by current x
            if ((power & 1) == 1) {
                res *= x;
            }

            // Square x for the next bit
            x *= x;

            // Shift power right by 1 bit (divide by 2)
            power >>= 1;
        }

        // If n was negative, return the reciprocal
        return n >= 0 ? res : 1 / res;
    }
}
