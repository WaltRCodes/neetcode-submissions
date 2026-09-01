public class Solution {
    public bool CanJump(int[] nums) {

        // The "goal" is the leftmost index we must be able to reach.
        // Initially, the goal is the last index.
        int goal = nums.Length - 1;

        // Scan from right to left.
        // If from index i we can jump to (or past) the current goal,
        // then we can shift the goal leftward to i.
        for (int i = nums.Length - 2; i >= 0; i--) {

            // Check if nums[i] allows reaching the current goal.
            if (i + nums[i] >= goal) {
                goal = i;   // We can now aim to reach index i instead.
            }
        }

        // If the goal has moved all the way back to index 0,
        // then the start position can reach the end.
        return goal == 0;
    }
}
