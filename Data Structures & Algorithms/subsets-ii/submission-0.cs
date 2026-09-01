public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        var res = new List<List<int>> { new List<int>()};
        int prevIdx = 0;
        int idx = 0;

        for (int i = 0; i < nums.Length; i++){
            idx = (i >= 1 && nums[i] == nums[i - 1]) ? prevIdx : 0;
            prevIdx = res.Count;
            for (int j = idx; j < prevIdx; j++) {
                var tmp = new List<int>(res[j]);
                tmp.Add(nums[i]);
                res.Add(tmp);
            }
        }
        return res;
    }
}
