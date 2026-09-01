public class Solution {

    List<List<int>> res; // Stores all valid combinations

    // Main function to find all unique combinations that sum to target
    public List<List<int>> CombinationSum(int[] nums, int target) {
        res = new List<List<int>>();

        // Sort the array to allow early termination (pruning)
        Array.Sort(nums);

        // Start DFS/backtracking from index 0
        dfs(0, new List<int>(), 0, nums, target);

        return res;
    }

    // Helper function for DFS/backtracking
    private void dfs(int i, List<int> cur, int total, int[] nums, int target) {
        // Base case: combination sums to target
        if (total == target) {
            res.Add(new List<int>(cur)); // Add a copy of the current combination
            return;
        }

        // Explore remaining candidates starting from index i
        for (int j = i; j < nums.Length; j++) {
            // Prune the search if sum exceeds target
            if (total + nums[j] > target) {
                return; // Early termination since array is sorted
            }

            // Include nums[j] in the current combination
            cur.Add(nums[j]);

            // Recurse: j instead of j+1 because the same number can be used multiple times
            dfs(j, cur, total + nums[j], nums, target);

            // Backtrack: remove last added element and try next candidate
            cur.RemoveAt(cur.Count - 1);
        }
    }
}
