public class Solution {
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char, int> mp = new Dictionary<char, int>();
        int l = 0, res = 0;

        for (int r = 0; r < s.Length; r++){
            if (mp.ContainsKey(s[r])){
                l = Math.Max(mp[s[r]]+1,l);
            }
            mp[s[r]] = r;
            res = Math.Max(res, r - l + 1);
        }
        return res;
    }
}
