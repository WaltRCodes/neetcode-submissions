public class Solution {
    public int Reverse(int x) {
        
            //res = Rec(Math.Abs(x),0) * (x < 0 ? -1 : 1);
        long res = Rec(Math.Abs((long)x),0) * (x < 0 ? -1 : 1);
        if (res < int.MinValue || res > int.MaxValue){
            return 0;
        }
        return (int)res;
    }
    private long Rec(long n, long rev){
        if (n == 0){
            return rev;
        }
        rev = rev * 10 + n % 10;
        return Rec(n / 10, rev);
    }
}
