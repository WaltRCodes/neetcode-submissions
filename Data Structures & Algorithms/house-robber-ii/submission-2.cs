public class Solution {
    public int Rob(int[] nums) {

        // If there is only one house, rob it — no circular conflict.
        if (nums.Length == 1)
            return nums[0];

        // Because the houses form a circle, you cannot rob both the first and last.
        // So you compute:
        //   1) Max if you rob from house 1 to n‑1  (exclude first)
        //   2) Max if you rob from house 0 to n‑2  (exclude last)
        // Then take the better of the two.
        return Math.Max(Helper(nums[1..nums.Length]), Helper(nums[0..(nums.Length-1)]));
    }

    // Standard House Robber DP on a linear array.
    private int Helper(int[] nums) {

        // rob1 = best total two houses back
        // rob2 = best total one house back
        int rob1 = 0, rob2 = 0;

        foreach (int num in nums) {

            // Either rob this house (rob1 + num)
            // or skip it (rob2)
            int newRob = Math.Max(rob1 + num, rob2);

            // Slide the window forward
            rob1 = rob2;
            rob2 = newRob;
        }

        // rob2 holds the best result for this linear segment
        return rob2;
    }
}
