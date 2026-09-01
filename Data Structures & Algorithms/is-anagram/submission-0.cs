public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }
        Dictionary<char, int> countS = new Dictionary<char,int>();
        Dictionary<char, int> countT = new Dictionary<char, int>();
        for(int i = 0; i<s.Length; i++){
            countS[s[i]] = countS.GetValueOrDefault(s[i],0)+1;
            countT[t[i]] = countT.GetValueOrDefault(t[i],0)+1;
        }
        return countS.Count == countT.Count && !countS.Except(countT).Any();
    }
}
