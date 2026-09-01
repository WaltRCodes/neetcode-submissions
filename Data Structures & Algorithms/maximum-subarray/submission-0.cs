public class Solution {
    public int MaxSubArray(int[] nums) {
        return Dfs(nums, 0, nums.Length - 1);
    }
    private int Dfs(int[] nums, int l, int r){
        if (l > r) {
            return int.MinValue;
        }
        int m = (l + r) >> 1;
        int leftSum = 0, rightSum = 0, curSum = 0;
        for (int i = m - 1; i >= l; i--){
            curSum += nums[i];
            leftSum = Math.Max(leftSum, curSum);
        }

        curSum = 0;
        for (int i = m + 1; i <= r; i++){
            curSum += nums[i];
            rightSum = Math.Max(rightSum, curSum);
        }

        return Math.Max(Dfs(nums, l, m - 1),Math.Max(Dfs(nums, m + 1, r), leftSum + nums[m] + rightSum));
    }
}
