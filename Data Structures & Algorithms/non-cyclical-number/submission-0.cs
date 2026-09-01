public class Solution {
    public bool IsHappy(int n) {
        int slow = n, fast = sumOfSquares(n);
        int power = 1, lam = 1;

        while (slow != fast){
            if (power == lam) {
                slow = fast;
                power *= 2;
                lam = 0;
            }
            lam++;
            fast =sumOfSquares(fast);
        }

        return fast == 1;
    }

    private int sumOfSquares(int n) {
        int output = 0;
        while (n != 0) {
            output += (n % 10) * (n % 10);
            n /= 10;
        }
        return output;
    }
}
