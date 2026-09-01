public class Solution {

    // Partition function similar to QuickSort, but for descending order
    private int Partition(int[] nums, int left, int right) {
        int mid = (left + right) >> 1; // middle index
        (nums[mid], nums[left + 1]) = (nums[left + 1], nums[mid]); // move pivot candidate

        // Median-of-three pivot selection for better performance
        if (nums[left] < nums[right])
            (nums[left], nums[right]) = (nums[right], nums[left]);
        if (nums[left + 1] < nums[right])
            (nums[left + 1], nums[right]) = (nums[right], nums[left + 1]);
        if (nums[left] < nums[left + 1])
            (nums[left], nums[left + 1]) = (nums[left + 1], nums[left]);

        int pivot = nums[left + 1];
        int i = left + 1;
        int j = right;

        // Partitioning: move numbers greater than pivot to the left
        while (true) {
            while (nums[++i] > pivot); // move i right while nums[i] > pivot
            while (nums[--j] < pivot); // move j left while nums[j] < pivot
            if (i > j) break;          // pointers crossed
            (nums[i], nums[j]) = (nums[j], nums[i]); // swap
        }

        // Place pivot in its correct position
        nums[left + 1] = nums[j];
        nums[j] = pivot;
        return j; // return pivot index
    }

    // QuickSelect algorithm to find the k-th largest element
    private int QuickSelect(int[] nums, int k) {
        int left = 0;
        int right = nums.Length - 1;

        while (true) {
            // Handle small subarrays of size 1 or 2
            if (right <= left + 1) {
                if (right == left + 1 && nums[right] > nums[left])
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                return nums[k]; // k-th largest found
            }

            int j = Partition(nums, left, right);

            if (j >= k) right = j - 1; // search left side
            if (j <= k) left = j + 1;  // search right side
        }
    }

    // Public function to find k-th largest element
    public int FindKthLargest(int[] nums, int k) {
        return QuickSelect(nums, k - 1); // convert to 0-based index
    }
}
