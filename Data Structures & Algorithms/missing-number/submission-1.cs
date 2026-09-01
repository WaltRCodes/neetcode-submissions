public class Solution {
    public int MissingNumber(int[] nums) {

        // Start with n (the value that would appear at the end of the full range [0..n])
        int res = nums.Length;

        // For each index i and value nums[i], accumulate (i - nums[i]).
        //
        // Why this works:
        //   The full range sum is: 0 + 1 + 2 + ... + n
        //   The array sum is: nums[0] + nums[1] + ... + nums[n-1]
        //
        //   Summing (i - nums[i]) across all i effectively computes:
        //       (0 + 1 + ... + n) - (nums[0] + nums[1] + ... + nums[n-1])
        //
        //   The difference is exactly the missing number.
        for (int i = 0; i < nums.Length; i++) {
            res += i - nums[i];
        }

        return res;
    }
}
