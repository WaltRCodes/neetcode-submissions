public class Solution {
    public int ClimbStairs(int n) {
        // 'one' represents the number of ways to reach the current step
        // 'two' represents the number of ways to reach the previous step
        // Both start at 1 because:
        // - There is 1 way to stand at step 0 (do nothing)
        // - There is 1 way to reach step 1 (one single step)
        int one = 1, two = 1;

        // Loop from step 2 up to step n
        // Each new value is the sum of the previous two,
        // just like the Fibonacci sequence.
        for (int i = 0; i < n - 1; i++) {
            int temp = one;      // temporarily store current 'one'
            one = one + two;     // ways to reach next step
            two = temp;          // shift 'two' to previous 'one'
        }

        // 'one' now holds the number of ways to reach step n
        return one;
    }
}
