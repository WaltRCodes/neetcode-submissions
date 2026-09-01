public class Solution {
    public int[] GetConcatenation(int[] nums) {
        // Store the length of the original array
        int n = nums.Length;

        // Create a new array with double the size
        int[] ans = new int[2 * n];

        // Copy each element of nums twice:
        // once in the first half and once in the second half
        for (int i = 0; i < n; i++){
            ans[i] = nums[i];       // first copy
            ans[i + n] = nums[i];   // second copy
        }

        // Return the concatenated array
        return ans;
    }
}
