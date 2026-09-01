public class Solution {
    public uint ReverseBits(uint n) {

        // Result will accumulate the reversed bit pattern
        uint res = 0;

        // A 32‑bit unsigned integer always has exactly 32 bits
        for (int i = 0; i < 32; i++) {

            // Extract the i‑th bit from n
            // Shift right by i, then mask with 1
            uint bit = (n >> i) & 1;

            // Place this bit in the mirrored position:
            // bit at index i moves to index (31 - i)
            res += (bit << (31 - i));
        }

        return res;
    }
}
