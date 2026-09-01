public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        bool[] dp = new bool[s.Length + 1];
        dp[s.Length] = true;

        for (int i = s.Length - 1; i >= 0; i--) {
            foreach (string w in wordDict) {
                if ((i + w.Length) <= s.Length && s.Substring(i, w.Length) == w){
                    dp[i] = dp[i + w.Length];
                }
                if(dp[i]){
                    break;
                }
            }
        }

        return dp[0];
    }
}
