public class Solution {

    // Manacher's algorithm: computes the palindrome radius at every position
    // in a transformed string where '#' characters are inserted between letters.
    public int[] Manacher(string s) {

        // Transform the string to handle even/odd palindromes uniformly.
        // Example: "aba" → "#a#b#a#"
        string t = "#" + string.Join("#", s.ToCharArray()) + "#";

        int n = t.Length;
        int[] p = new int[n];   // p[i] = radius of palindrome centered at i
        int l = 0, r = 0;       // current known palindrome window [l, r]

        for (int i = 0; i < n; i++) {

            // If i is inside the current palindrome window,
            // mirror the radius from the symmetric position.
            p[i] = (i < r) ? Math.Min(r - i, p[l + (r - i)]) : 0;

            // Expand around center i while characters match.
            while (i + p[i] + 1 < n &&
                   i - p[i] - 1 >= 0 &&
                   t[i + p[i] + 1] == t[i - p[i] - 1]) {
                p[i]++;
            }

            // If the palindrome centered at i extends beyond r,
            // update the window to the new boundaries.
            if (i + p[i] > r) {
                l = i - p[i];
                r = i + p[i];
            }
        }

        return p;
    }

    // Count palindromic substrings using the radii from Manacher's algorithm.
    public int CountSubstrings(string s) {

        // p[i] gives the radius in the transformed string.
        int[] p = Manacher(s);

        int res = 0;

        // Each radius contributes (radius + 1) / 2 palindromes in the original string.
        foreach (int radius in p) {
            res += (radius + 1) / 2;
        }

        return res;
    }
}
