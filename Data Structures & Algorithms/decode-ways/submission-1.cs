public class Solution {

    public int NumDecodings(string s) {

        // Rolling DP:
        // dp1 = number of ways to decode starting at index i+1
        // dp2 = number of ways to decode starting at index i+2
        // dp  = number of ways to decode starting at index i (computed each loop)
        int dp = 0, dp1 = 1, dp2 = 0;

        // Traverse from right to left
        for (int i = s.Length - 1; i >= 0; i--) {

            // If current char is '0', it cannot be decoded alone
            if (s[i] == '0') {
                dp = 0;
            }
            else {
                // Single-digit decode always valid for '1'–'9'
                dp = dp1;

                // Check if a valid two-digit decode exists:
                // "10"–"26"
                bool canTwoDigit =
                    i + 1 < s.Length &&
                    (s[i] == '1' || (s[i] == '2' && s[i + 1] < '7'));

                if (canTwoDigit) {
                    dp += dp2;
                }
            }

            // Slide the DP window forward
            dp2 = dp1;  // dp2 becomes old dp1
            dp1 = dp;   // dp1 becomes current dp
            dp = 0;     // reset dp for next iteration
        }

        // dp1 now holds the number of ways to decode from index 0
        return dp1;
    }
}
