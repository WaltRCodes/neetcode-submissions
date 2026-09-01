public class Solution {
    private int Partition(int[] nums, int left, int right) {
        int mid = (left + right) >> 1;
        (nums[mid], nums[left + 1]) = (nums[left + 1], nums[mid]);

        if (nums[left] < nums[right])
            (nums[left], nums[right]) = (nums[right], nums[left]);
        if (nums[left + 1] < nums[right])
            (nums[left + 1], nums[right]) = (nums[right], nums[left + 1]);
        if (nums[left] < nums[left + 1])
            (nums[left], nums[left + 1]) = (nums[left + 1], nums[left]);

        int pivot = nums[left + 1];
        int i = left + 1;
        int j = right;

        while (true) {
            while (nums[++i] > pivot);
            while (nums[--j] < pivot);
            if (i > j) break;
            (nums[i], nums[j]) = (nums[j],nums[i]);
        }

        nums[left + 1] = nums[j];
        nums[j] = pivot;
        return j;
    }

    private int QuickSelect(int[] nums, int k) {
        int left = 0;
        int right = nums.Length - 1;

        while (true) {
            if (right <= left + 1) {
                if (right == left + 1 && nums[right] > nums[left])
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                return nums[k];
            }

            int j = Partition(nums, left, right);

            if (j >= k) right = j - 1;
            if (j <= k) left = j + 1;
        }
    }

    public int FindKthLargest(int[] nums, int k) {
        return QuickSelect(nums, k - 1);
    }
}
