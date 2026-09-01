public class Solution {
    public int MinCostClimbingStairs(int[] cost) {

        // We fill the array from right to left.
        // cost[i] will represent the minimum total cost to start at step i
        // and reach the top of the staircase.

        // Start from the third‑to‑last step and move backward.
        for (int i = cost.Length - 3; i >= 0; i--) {

            // From step i, you can move to i+1 or i+2.
            // Add the cheaper of the two future paths to cost[i].
            cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
        }

        // You can start at step 0 or step 1.
        // The answer is whichever starting point yields the smaller total cost.
        return Math.Min(cost[0], cost[1]);
    }
}
