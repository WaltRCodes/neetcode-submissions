public class Solution {
    public int RemoveElement(int[] nums, int val) {
        // i scans the array from the start
        // n represents the current "effective" length of the array
        int i = 0, n = nums.Length;

        // Continue while i is within the shrinking array
        while (i < n) {

            // If the current element matches the value to remove...
            if (nums[i] == val) {

                // Replace it with the last element in the current range.
                // Decrease n to shrink the considered portion of the array.
                nums[i] = nums[--n];

                // Do NOT increment i here, because we need to check
                // the swapped-in element at this same index.
            } else {

                // If it's not the target value, move to the next index.
                i++;
            }
        }

        // n is the new length after removing all occurrences of val
        return n;
    }
}
