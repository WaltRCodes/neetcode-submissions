public class Solution {
    public int SingleNumber(int[] nums) {

        // XOR accumulator — will eventually hold the unique number
        int res = 0;

        // XOR has two key properties that make this work:
        //   1. a ^ a = 0        (a number cancels itself out)
        //   2. a ^ 0 = a        (XOR with zero keeps the number)
        //   3. XOR is commutative and associative
        //
        // Since every number except one appears twice,
        // all pairs cancel out, leaving only the single number.
        foreach (int num in nums) {
            res ^= num;
        }

        return res;
    }
}
