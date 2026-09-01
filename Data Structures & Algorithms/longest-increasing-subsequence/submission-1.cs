public class Solution {
    public int LengthOfLIS(int[] nums) {

        // dp[k] = the smallest possible tail value of an increasing subsequence of length (k+1)
        // This list is kept sorted, enabling binary search.
        List<int> dp = new List<int>();

        // Start with the first number as the tail of a subsequence of length 1
        dp.Add(nums[0]);

        int LIS = 1; // length of the longest increasing subsequence found so far

        for (int i = 1; i < nums.Length; i++) {

            // Case 1: nums[i] extends the longest subsequence
            // If nums[i] is greater than all tails, append it.
            if (dp[dp.Count - 1] < nums[i]) {
                dp.Add(nums[i]);
                LIS++;
                continue;
            }

            // Case 2: nums[i] cannot extend; find where it fits.
            // BinarySearch returns:
            //   - index if found
            //   - bitwise complement (~index) of insertion point if not found
            int idx = dp.BinarySearch(nums[i]);

            // If not found, convert to insertion index
            if (idx < 0) idx = ~idx;

            // Replace the element at idx with nums[i]
            // This keeps dp sorted and maintains the smallest possible tail
            dp[idx] = nums[i];
        }

        // dp.Count == LIS, but we tracked LIS explicitly
        return LIS;
    }
}
