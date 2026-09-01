public class Solution {
    public uint ReverseBits(uint n) {
        uint res = 0;
        for(int i = 0; i< 32; i++){
            uint bit = (n >> i) & 1;
            res += (bit << (31 - i));
        }
        return res;
    }
}
