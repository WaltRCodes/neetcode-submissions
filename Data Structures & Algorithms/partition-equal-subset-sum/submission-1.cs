public class Solution {
    public bool CanPartition(int[] nums) {

        // If the total sum is odd, it's impossible to split into two equal subsets
        if (nums.Sum() % 2 != 0) {
            return false;
        }

        // We want to know if any subset sums to target = totalSum / 2
        int target = nums.Sum() / 2;

        // dp = set of all subset sums achievable so far
        HashSet<int> dp = new HashSet<int>();
        dp.Add(0); // zero sum is always achievable (empty subset)

        // Process numbers from right to left (order doesn't matter)
        for (int i = nums.Length - 1; i >= 0; i--) {

            // nextDP will store the new set of achievable sums after including nums[i]
            HashSet<int> nextDP = new HashSet<int>();

            foreach (int t in dp) {

                // If adding nums[i] hits the target, we can stop immediately
                if (t + nums[i] == target) {
                    return true;
                }

                // Option 1: include nums[i]
                nextDP.Add(t + nums[i]);

                // Option 2: exclude nums[i]
                nextDP.Add(t);
            }

            // Move to the next iteration with updated sums
            dp = nextDP;
        }

        // If we never hit the target, partitioning is impossible
        return false;
    }
}
