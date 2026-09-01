public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int,int> prevMap = new Dictionary<int,int>();
        for(int i = 0; i< nums.Length; i++){
            var diff = target -nums[i];
            if(prevMap.ContainsKey(diff)){
                return new int[]{prevMap[diff],i};
            }
            prevMap[nums[i]]=i;
        }
        return null;
    }
}
