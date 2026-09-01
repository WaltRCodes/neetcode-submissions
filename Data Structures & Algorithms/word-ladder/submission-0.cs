public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord)){
            return 0;
        }
        Dictionary<string, List<string>> nei = new Dictionary<string, List<string>>();
        wordList.Add(beginWord);
        foreach (string word in wordList) {
            for (int j = 0; j < word.Length; j++) {
                string pattern = word.Substring(0, j) + "*" + word.Substring(j + 1);
                if (!nei.ContainsKey(pattern)){
                    nei[pattern] = new List<string>();
                }
                nei[pattern].Add(word);
            }
        }
        HashSet<string> visit = new HashSet<string>();
        Queue<string> q = new Queue<string>();
        q.Enqueue(beginWord);
        int res = 1;
        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; i++){
                string word = q.Dequeue();
                if (word == endWord) {
                    return res;
                }
                for ( int j = 0; j < word.Length; j++){
                    string pattern = word.Substring(0,j) + "*" + word.Substring(j + 1);
                    if (nei.ContainsKey(pattern)) {
                        foreach (string neiWord in nei[pattern]){
                            if (!visit.Contains(neiWord)){
                                visit.Add(neiWord);
                                q.Enqueue(neiWord);
                            }
                        }
                    }
                }
            }
            res++;
        }
        return 0;
    }
}
