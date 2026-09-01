public class Solution {

    // Function to generate all letter combinations for a phone number
    public List<string> LetterCombinations(string digits) {
        if (digits.Length == 0) return new List<string>(); // No input, return empty list

        List<string> res = new List<string> { "" }; // Start with an empty string

        // Mapping from digit to possible letters
        Dictionary<char, string> digitToChar = new Dictionary<char, string> {
            {'2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl"},
            {'6', "mno"}, { '7', "qprs" }, { '8', "tuv" }, { '9', "wxyz" }
        };

        // Iterate over each digit in the input
        foreach (char digit in digits) {
            List<string> tmp = new List<string>(); // Temporary list to store new combinations

            // For each existing combination, append all possible letters for the current digit
            foreach (string curStr in res) {
                foreach (char c in digitToChar[digit]) {
                    tmp.Add(curStr + c); // Append letter and add to tmp
                }
            }

            res = tmp; // Update result with new combinations
        }

        return res;
    }
}
