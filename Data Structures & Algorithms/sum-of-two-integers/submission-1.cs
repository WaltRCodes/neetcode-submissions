public class Solution {
    public int GetSum(int a, int b) {

        // We keep looping until there is no carry left.
        // 'a' will hold the running sum,
        // 'b' will hold the carry that still needs to be added.
        while (b != 0) {

            // Carry is produced where both a and b have a 1 bit.
            // (a & b) finds those positions.
            // Shifting left by 1 moves the carry into the correct place.
            int carry = (a & b) << 1;

            // XOR adds the bits without carrying:
            //   0^0=0, 1^0=1, 0^1=1, 1^1=0
            // This gives the partial sum.
            a ^= b;

            // Now assign the carry to b so it can be added in the next loop.
            b = carry;
        }

        // When no carry remains, 'a' contains the full sum.
        return a;
    }
}
