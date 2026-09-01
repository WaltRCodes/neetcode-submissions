public class Solution {
    public int Rob(int[] nums) {

        // rob1 = best we can do up to the house before the previous one
        // rob2 = best we can do up to the previous house
        int rob1 = 0, rob2 = 0;

        // Iterate through each house's money
        foreach (int num in nums) {

            // Option 1: rob this house → num + rob1 (skip previous)
            // Option 2: skip this house → rob2 (take previous best)
            int temp = Math.Max(num + rob1, rob2);

            // Shift the window forward:
            // rob1 becomes old rob2
            rob1 = rob2;

            // rob2 becomes the new best (temp)
            rob2 = temp;
        }

        // rob2 holds the maximum amount we can rob
        return rob2;
    }
}
