public class Solution {

    private List<List<int>> res; // Stores all generated permutations

    // Main function to generate all permutations of nums
    public List<List<int>> Permute(int[] nums) {
        res = new List<List<int>>();
        Backtrack(nums, 0); // Start backtracking from index 0
        return res;
    }

    // Helper function for DFS/backtracking
    private void Backtrack(int[] nums, int idx) {
        // Base case: all positions fixed, store current permutation
        if (idx == nums.Length) {
            res.Add(new List<int>(nums)); // Make a copy to avoid reference issues
            return;
        }

        // Swap each element to the current position and recurse
        for (int i = idx; i < nums.Length; i++) {
            Swap(nums, idx, i);         // Swap i-th element to current position
            Backtrack(nums, idx + 1);   // Recurse to fix the next position
            Swap(nums, idx, i);         // Backtrack: restore original array
        }
    }

    // Utility function to swap two elements in array
    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
