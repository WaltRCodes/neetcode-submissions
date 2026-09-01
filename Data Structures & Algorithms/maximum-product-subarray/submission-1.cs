public class Solution {
    public int MaxProduct(int[] nums) {

        int n = nums.Length;

        // Result starts as the first element (handles single‑element arrays)
        int res = nums[0];

        // prefix  = running product from the left
        // suffix  = running product from the right
        // Using both directions helps handle negative numbers and zeros.
        int prefix = 0, suffix = 0;

        for (int i = 0; i < n; i++) {

            // Build prefix product:
            // If prefix is zero, reset to 1 before multiplying.
            prefix = nums[i] * (prefix == 0 ? 1 : prefix);

            // Build suffix product from the opposite direction:
            suffix = nums[n - 1 - i] * (suffix == 0 ? 1 : suffix);

            // Update result with the best seen so far
            res = Math.Max(res, Math.Max(prefix, suffix));
        }

        return res;
    }
}
