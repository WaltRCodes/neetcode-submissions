public class Solution {
    public int MajorityElement(int[] nums) {
        // 'res' will hold the current candidate for majority element
        // 'count' tracks how strongly this candidate is supported
        int res = 0, count = 0;

        // Scan through each number in the array
        foreach (int num in nums) {

            // If count drops to zero, we adopt a new candidate
            if (count == 0) {
                res = num;
            }

            // Increase count if the current number supports the candidate,
            // otherwise decrease it (they "cancel out")
            count += (num == res) ? 1 : -1;
        }

        // The remaining candidate is the majority element
        return res;
    }
}
