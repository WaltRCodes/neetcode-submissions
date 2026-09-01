public class Solution {
    public bool IsHappy(int n) {

        // We use Brent's cycle detection algorithm.
        // "slow" moves one step at a time.
        // "fast" moves one step at a time too, but we periodically reset slow.
        int slow = n;
        int fast = sumOfSquares(n);

        // power = length of the current search window
        // lam   = current step count within that window
        int power = 1, lam = 1;

        // Continue until slow and fast meet (cycle detected)
        while (slow != fast) {

            // If we've taken 'power' steps, reset slow to fast
            // and double the window size.
            if (power == lam) {
                slow = fast;
                power *= 2;
                lam = 0;
            }

            lam++;

            // Move fast forward by one step (sum of squares)
            fast = sumOfSquares(fast);
        }

        // If the cycle ends at 1, it's a happy number.
        return fast == 1;
    }

    // Computes the sum of the squares of the digits of n.
    // Example: n = 19 → 1² + 9² = 82
    private int sumOfSquares(int n) {
        int output = 0;
        while (n != 0) {
            int digit = n % 10;
            output += digit * digit;
            n /= 10;
        }
        return output;
    }
}
