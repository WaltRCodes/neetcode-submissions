public class Solution {
    public string LongestPalindrome(string s) {
        // resLen = length of the longest palindrome found so far
        // resIdx = starting index of that palindrome
        int resLen = 0, resIdx = 0;

        // Try expanding around every index in the string
        for (int i = 0; i < s.Length; i++) {

            // -------------------------
            // Expand around center (odd-length palindromes)
            // Example: "racecar" → center at 'e'
            // -------------------------
            int l = i, r = i;

            // Expand outward while characters match
            while (l >= 0 && r < s.Length && s[l] == s[r]) {

                // Update best palindrome if this one is longer
                if (r - l + 1 > resLen) {
                    resIdx = l;
                    resLen = r - l + 1;
                }

                l--;
                r++;
            }

            // -------------------------
            // Expand around center (even-length palindromes)
            // Example: "abba" → center between the two 'b's
            // -------------------------
            l = i;
            r = i + 1;

            while (l >= 0 && r < s.Length && s[l] == s[r]) {

                // Update best palindrome if this one is longer
                if (r - l + 1 > resLen) {
                    resIdx = l;
                    resLen = r - l + 1;
                }

                l--;
                r++;
            }
        }

        // Return the longest palindromic substring found
        return s.Substring(resIdx, resLen);
    }
}
