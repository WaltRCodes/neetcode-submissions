public class Solution {

    public int CountSubstrings(string s) {
        int res = 0;

        // Try treating every index as the center of a palindrome.
        // Each character can be:
        //   - the center of an odd-length palindrome (i, i)
        //   - the left center of an even-length palindrome (i, i+1)
        for (int i = 0; i < s.Length; i++) {
            // Count odd-length palindromes centered at i
            res += CountPali(s, i, i);

            // Count even-length palindromes centered between i and i+1
            res += CountPali(s, i, i + 1);
        }

        return res;
    }

    private int CountPali(string s, int l, int r) {
        int res = 0;

        // Expand outward while the substring s[l..r] remains a palindrome
        while (l >= 0 && r < s.Length && s[l] == s[r]) {
            // Found a valid palindrome substring
            res++;

            // Expand further outward
            l--;
            r++;
        }

        return res;
    }
}
