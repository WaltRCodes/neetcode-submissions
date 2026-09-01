public class Solution {
    public List<string> LetterCombinations(string digits) {
        if (digits.Length == 0) return new List<string>();

        List<string> res = new List<string> { "" };
        Dictionary<char, string> digitToChar = new Dictionary<char, string>{
            {'2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl"},
            { '6', "mno"}, { '7', "qprs" }, { '8', "tuv" }, { '9', "wxyz" }
        };

        foreach (char digit in digits) {
            List<string> tmp = new List<string>();
            foreach (string curStr in res) {
                foreach (char c in digitToChar[digit]) {
                    tmp.Add(curStr + c);
                }
            }
            res = tmp;
        }
        return res;
            }
}
