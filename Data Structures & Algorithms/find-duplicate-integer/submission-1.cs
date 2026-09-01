public class Solution {
    public int FindDuplicate(int[] nums) {

        // Floyd's Tortoise and Hare algorithm
        // Phase 1: Detect the cycle

        int slow = 0, fast = 0;

        // Move slow by 1 step, fast by 2 steps
        // They will eventually meet inside the cycle
        while (true) {
            slow = nums[slow];           // slow moves 1 step
            fast = nums[nums[fast]];     // fast moves 2 steps

            if (slow == fast) {          // cycle detected
                break;
            }
        }

        // Phase 2: Find the entrance to the cycle
        // This entrance corresponds to the duplicate number

        int slow2 = 0;

        // Move slow and slow2 at the same speed
        // They will meet at the duplicate value
        while (true) {
            slow = nums[slow];           // move inside cycle
            slow2 = nums[slow2];         // move from start

            if (slow == slow2) {         // meeting point = duplicate
                return slow;
            }
        }
    }
}
