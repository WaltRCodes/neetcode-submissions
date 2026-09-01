public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int l = 0, r = numbers.Length - 1;

        while (l < r){
            int curSum = numbers[l] + numbers[r];

            if(curSum > target){
                r--;
            } else if (curSum < target){
                l++;
            } else {
                return new int[] {l + 1, r+1};
            }
        }
        return new int[0];
    }
}
