public class Solution {
    // This will store all unique subsets
    private List<List<int>> res = new List<List<int>>();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        // Sort so duplicates are adjacent — this is essential for skipping duplicates
        Array.Sort(nums);

        // Start backtracking from index 0 with an empty subset
        Backtrack(0, new List<int>(), nums);

        return res;
    }

    private void Backtrack(int i, List<int> subset, int[] nums) {
        // Every position in the recursion represents a valid subset
        // Add a *copy* of the current subset
        res.Add(new List<int>(subset));

        // Explore all choices starting from index i
        for (int j = i; j < nums.Length; j++) {

            // Skip duplicates:
            // If nums[j] is the same as nums[j-1], and j > i,
            // then we've already explored subsets that start with this value at this depth.
            if (j > i && nums[j] == nums[j - 1]) {
                continue;
            }

            // Choose nums[j]
            subset.Add(nums[j]);

            // Recurse with next index
            Backtrack(j + 1, subset, nums);

            // Undo the choice (backtrack)
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
