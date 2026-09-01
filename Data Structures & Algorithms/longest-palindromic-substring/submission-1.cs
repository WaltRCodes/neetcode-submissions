public class Solution {

    public string LongestPalindrome(string s) {

        // Run Manacher’s algorithm to compute palindrome radii
        int[] p = Manacher(s);

        int resLen = 0;      // length of longest palindrome (in original string)
        int center_idx = 0;  // center index in transformed string

        // Find the center with the largest radius
        for (int i = 0; i < p.Length; i++) {
            if (p[i] > resLen) {
                resLen = p[i];
                center_idx = i;
            }
        }

        // Convert center index in transformed string back to original string index
        // (center_idx - resLen) gives left boundary in transformed string
        // dividing by 2 maps back to original string indexing
        int resIdx = (center_idx - resLen) / 2;

        // Extract the longest palindromic substring
        return s.Substring(resIdx, resLen);
    }

    public int[] Manacher(string s) {

        // Transform string by inserting '#' between characters
        // Example: "abba" → "#a#b#b#a#"
        // This allows uniform handling of even/odd palindromes
        string t = "#" + string.Join("#", s.ToCharArray()) + "#";

        int n = t.Length;
        int[] p = new int[n]; // p[i] = radius of palindrome centered at i
        int l = 0, r = 0;     // current palindrome window [l, r]

        for (int i = 0; i < n; i++) {

            // Mirror optimization:
            // If i is inside the current window, use mirrored value
            if (i < r) {
                p[i] = Math.Min(r - i, p[l + (r - i)]);
            } else {
                p[i] = 0;
            }

            // Expand around center i
            while (i + p[i] + 1 < n &&
                   i - p[i] - 1 >= 0 &&
                   t[i + p[i] + 1] == t[i - p[i] - 1]) {
                p[i]++;
            }

            // If expanded palindrome goes beyond current right boundary,
            // update the window to the new palindrome
            if (i + p[i] > r) {
                l = i - p[i];
                r = i + p[i];
            }
        }

        return p;
    }
}
