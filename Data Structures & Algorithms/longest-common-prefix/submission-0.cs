public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        // Iterate through each character index of the first string
        for (int i = 0; i < strs[0].Length; i++) {

            // Compare this character with the character at the same index in every string
            foreach (string s in strs) {

                // If we've reached the end of a string OR characters don't match,
                // then the common prefix ends right before this index.
                if (i == s.Length || s[i] != strs[0][i]) {
                    return s.Substring(0, i);
                }
            }
        }

        // If the loop finishes, the entire first string is the common prefix
        return strs[0];
    }
}
