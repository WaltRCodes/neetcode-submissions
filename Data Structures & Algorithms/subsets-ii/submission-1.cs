public class Solution {

    // Function to generate all subsets of nums including duplicates
    public List<List<int>> SubsetsWithDup(int[] nums) {

        Array.Sort(nums); // Sort array to group duplicates together

        var res = new List<List<int>> { new List<int>() }; // Start with empty subset
        int prevIdx = 0; // Start index for subsets to extend
        int idx = 0;     // Current start index

        // Iterate through all numbers in nums
        for (int i = 0; i < nums.Length; i++) {
            
            // If current number is same as previous, only extend subsets
            // added in previous iteration to avoid duplicates
            idx = (i >= 1 && nums[i] == nums[i - 1]) ? prevIdx : 0;

            prevIdx = res.Count; // Record current size of res

            // Extend existing subsets from idx to prevIdx with nums[i]
            for (int j = idx; j < prevIdx; j++) {
                var tmp = new List<int>(res[j]); // Copy existing subset
                tmp.Add(nums[i]);                // Add current number
                res.Add(tmp);                    // Add new subset to result
            }
        }

        return res;
    }
}
