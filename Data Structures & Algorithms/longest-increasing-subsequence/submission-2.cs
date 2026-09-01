public class Solution {
    public int LengthOfLIS(int[] nums) {
        int n = nums.Length;

        // dp[k] = smallest tail of an increasing subsequence of length k+1
        int[] dp = new int[n];
        int size = 0;

        foreach (int num in nums) {

            // Manual binary search on dp[0..size)
            int left = 0, right = size;

            while (left < right) {
                int mid = (left + right) / 2;
                if (dp[mid] < num)
                    left = mid + 1;
                else
                    right = mid;
            }

            // left is the insertion point
            dp[left] = num;

            // If we inserted at the end, we extended the LIS
            if (left == size)
                size++;
        }

        return size;
    }
}
