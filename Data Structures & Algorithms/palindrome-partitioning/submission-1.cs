public class Solution {
    public List<List<string>> Partition(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n,n];
        for (int l = 1; l <= n; l++) {
            for(int i = 0; i <= n - l; i++){
                dp[i, i + l - 1] = (s[i] == s[i + l - 1] && (i + 1 > (i + l - 2) || dp[i + 1, i + l - 2]));
            }
            
        }
        return Dfs(s, dp, 0);
    }

    private List<List<string>> Dfs(string s, bool[,] dp, int i) {
        if (i >= s.Length) {
            return new List<List<string>> { new List<string>()};
        }

        var ret = new List<List<string>>();
        for (int j = i; j < s.Length; j++) {
            if (dp[i, j]) {
                var nxt = Dfs(s, dp, j + 1);
                foreach (var part in nxt) {
                    var cur = new List<string> { s.Substring(i, j - i + 1) };
                    cur.AddRange(part);
                    ret.Add(cur);
                }
            }
        }
        return ret;
    }
}
