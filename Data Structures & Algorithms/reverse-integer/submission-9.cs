public class Solution {
    public int Reverse(int x) {

        // Reverse the absolute value of x using recursion.
        // Cast to long to avoid overflow during Math.Abs(int.MinValue).
        long res = Rec(Math.Abs((long)x), 0);

        // Restore the sign if x was negative.
        res *= (x < 0 ? -1 : 1);

        // If the reversed value doesn't fit in a 32‑bit signed int,
        // return 0 as required by the problem.
        if (res < int.MinValue || res > int.MaxValue) {
            return 0;
        }

        return (int)res;
    }

    // Recursively builds the reversed number.
    // n   = remaining digits to process
    // rev = the reversed number built so far
    private long Rec(long n, long rev) {

        // Base case: no digits left
        if (n == 0) {
            return rev;
        }

        // Append the last digit of n to rev
        rev = rev * 10 + (n % 10);

        // Recurse on the remaining digits
        return Rec(n / 10, rev);
    }
}
