public class Solution {
    private Dictionary<char, HashSet<char>> adj;
    private Dictionary<char, bool> visited;
    private List<char> result;

    public string foreignDictionary(string[] words) {
        adj = new Dictionary<char, HashSet<char>>();
        foreach (var word in words) {
            foreach (var c in word) {
                if (!adj.ContainsKey(c)){
                    adj[c] = new HashSet<char>();
                }
            }
        }

        for(int i = 0; i < words.Length - 1; i++){
            var w1 = words[i];
            var w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0,minLen)){
                return "";
            }
            for(int j = 0; j < minLen; j++){
                if(w1[j] != w2[j]){
                    adj[w1[j]].Add(w2[j]);
                    break;
                }
            }
        }
        visited = new Dictionary<char, bool>();
        result = new List<char>();
        foreach (var c in adj.Keys){
            if (dfs(c)){
                return "";
            }
        }
            result.Reverse();
            var sb = new StringBuilder();
            foreach (var c in result){
                sb.Append(c);
            }
            return sb.ToString();
        

        
    }
    private bool dfs(char ch){
        if(visited.ContainsKey(ch)){
            return visited[ch];

        }
        visited[ch] = true;
        foreach(var next in adj[ch]){
            if(dfs(next)){
                return true;
            }
        }
        visited[ch] = false;
        result.Add(ch);
        return false;
    }
}
