public class Solution {
    public int MaxSubArray(int[] nums) {
        // Use divide‑and‑conquer to compute the maximum subarray sum
        return Dfs(nums, 0, nums.Length - 1);
    }

    private int Dfs(int[] nums, int l, int r) {

        // Base case: invalid range → return the smallest possible value
        // so it never gets chosen as a max.
        if (l > r) {
            return int.MinValue;
        }

        // Middle index
        int m = (l + r) >> 1;

        // Compute the best subarray sum that ends at m‑1 (left side)
        int leftSum = 0, rightSum = 0, curSum = 0;
        for (int i = m - 1; i >= l; i--) {
            curSum += nums[i];
            leftSum = Math.Max(leftSum, curSum);
        }

        // Compute the best subarray sum that starts at m+1 (right side)
        curSum = 0;
        for (int i = m + 1; i <= r; i++) {
            curSum += nums[i];
            rightSum = Math.Max(rightSum, curSum);
        }

        // Three possibilities:
        // 1. Max subarray is entirely in the left half
        // 2. Max subarray is entirely in the right half
        // 3. Max subarray crosses the midpoint (left + nums[m] + right)
        return Math.Max(
            Dfs(nums, l, m - 1),
            Math.Max(
                Dfs(nums, m + 1, r),
                leftSum + nums[m] + rightSum
            )
        );
    }
}
