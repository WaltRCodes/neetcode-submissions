public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {

        // dp[sum] = number of ways to reach this sum using processed numbers
        Dictionary<int, int> dp = new Dictionary<int, int>();

        // Start with sum = 0 achievable in exactly 1 way (choose nothing yet)
        dp[0] = 1;

        // Process each number one by one
        foreach (int num in nums) {

            // nextDp will store the updated counts after including this number
            Dictionary<int, int> nextDp = new Dictionary<int, int>();

            // For every sum we have so far, branch into +num and -num
            foreach (var entry in dp) {

                int total = entry.Key;   // existing sum
                int count = entry.Value; // number of ways to reach this sum

                // Option 1: add the number
                if (!nextDp.ContainsKey(total + num)) {
                    nextDp[total + num] = 0;
                }
                nextDp[total + num] += count;

                // Option 2: subtract the number
                if (!nextDp.ContainsKey(total - num)) {
                    nextDp[total - num] = 0;
                }
                nextDp[total - num] += count;
            }

            // Move to the next state
            dp = nextDp;
        }

        // If the target sum exists, return its count; otherwise return 0
        return dp.ContainsKey(target) ? dp[target] : 0;
    }
}
