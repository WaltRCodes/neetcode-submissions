public class Solution {
    
    // Function to generate all subsets (the power set) of nums
    public List<List<int>> Subsets(int[] nums) {
        int n = nums.Length; // Number of elements in input
        List<List<int>> res = new List<List<int>>();

        // Iterate over all possible bitmasks from 0 to 2^n - 1
        // Each bitmask represents a subset: 1 means include the element
        for (int i = 0; i < (1 << n); i++) {
            List<int> subset = new List<int>();

            // Check each bit position j
            for (int j = 0; j < n; j++) {
                if ((i & (1 << j)) != 0) { // If bit j is set, include nums[j]
                    subset.Add(nums[j]);
                }
            }

            // Add the current subset to the result
            res.Add(subset);
        }

        return res;
    }
}
