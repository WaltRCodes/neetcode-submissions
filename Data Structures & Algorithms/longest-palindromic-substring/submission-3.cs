public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length;

        // dp[l][r] = true means s[l..r] is a palindrome
        bool[,] dp = new bool[n, n];

        int start = 0;   // starting index of longest palindrome
        int maxLen = 1;  // at least every char is a palindrome of length 1

        // Fill DP table
        // We expand by substring length: len = 1, 2, 3, ...
        for (int len = 1; len <= n; len++) {
            for (int l = 0; l + len - 1 < n; l++) {
                int r = l + len - 1; // right boundary

                if (s[l] == s[r]) {
                    // If substring length <= 2, it's automatically a palindrome
                    // (e.g., "a", "aa")
                    if (len <= 2) {
                        dp[l, r] = true;
                    }
                    else {
                        // Otherwise, check the inside substring
                        dp[l, r] = dp[l + 1, r - 1];
                    }
                }

                // Update longest palindrome found
                if (dp[l, r] && len > maxLen) {
                    start = l;
                    maxLen = len;
                }
            }
        }

        return s.Substring(start, maxLen);
    }
}
