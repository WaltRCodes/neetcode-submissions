public class Solution {
    public string MinWindow(string s, string t) {
        if (t == "") return "";

        Dictionary<char, int> countT = new Dictionary<char, int>();
        Dictionary<char, int> window = new Dictionary<char, int>();

        foreach (char c in t) {
            if (countT.ContainsKey(c)) {
                countT[c]++;
            } else {
                countT[c] = 1;
            }
        }

        int have = 0, need = countT.Count;
        int[] res = { -1, -1 };
        int resLen = int.MaxValue;
        int l = 0;

        for (int r=0; r< s.Length; r++) {
            char c = s[r];
            if ( window.ContainsKey(c)){
                window[c]++;
            } else {
                window[c] = 1;
            }

            if(countT.ContainsKey(c) && window[c] == countT[c]) {
                have++;
            }

            while (have == need) {
                if ((r - l + 1) < resLen) {
                    resLen = r - l + 1;
                    res[0] = l;
                    res[1] = r;
                }

                char leftChar = s[l];
                window[leftChar]--;
                if (countT.ContainsKey(leftChar) && window[leftChar] < countT[leftChar]){
                    have--;
                }
                l++;
            }
        }
        return resLen == int.MaxValue ? "" : s.Substring(res[0],resLen);
    }
}
