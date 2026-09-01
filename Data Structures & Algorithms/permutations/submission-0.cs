public class Solution {
    private List<List<int>> res;

    public List<List<int>> Permute(int[] nums) {
        res = new List<List<int>>();
        Backtrack(nums, 0);
        return res;
    }

    private void Backtrack(int[] nums, int idx) {
        if (idx == nums.Length) {
            res.Add(new List<int>(nums));
            return;
        }
        for (int i = idx; i < nums.Length; i ++) {
            Swap(nums, idx, i);
            Backtrack(nums, idx + 1);
            Swap(nums, idx, i);
        }
    }

    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
