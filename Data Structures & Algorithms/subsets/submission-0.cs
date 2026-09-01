public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        int n = nums.Length;
        List<List<int>> res = new List<List<int>>();
        for (int i = 0; i < (1 << n); i++){
            List<int> subset = new List<int>();
            for (int j = 0; j < n; j++) {
                if ((i & (1 << j)) != 0) {
                    subset.Add(nums[j]);
                }
            }
            res.Add(subset);

        }
        return res;
    }
}
