public class Solution {
    public int MinDistance(string word1, string word2) {

        // dp[i, j] = minimum edit distance between:
        //   word1[i:] (suffix starting at i)
        //   word2[j:] (suffix starting at j)
        //
        // We build this table bottom‑up, starting from the ends of the strings.
        int[,] dp = new int[word1.Length + 1, word2.Length + 1];

        // Base case 1:
        // If word1 is exhausted (i == word1.Length),
        // the only option is to insert all remaining characters of word2.
        for (int j = 0; j <= word2.Length; j++) {
            dp[word1.Length, j] = word2.Length - j;
        }

        // Base case 2:
        // If word2 is exhausted (j == word2.Length),
        // the only option is to delete all remaining characters of word1.
        for (int i = 0; i <= word1.Length; i++) {
            dp[i, word2.Length] = word1.Length - i;
        }

        // Fill the table bottom‑up.
        // We move from the end of both strings toward the beginning.
        for (int i = word1.Length - 1; i >= 0; i--) {
            for (int j = word2.Length - 1; j >= 0; j--) {

                // If characters match, no edit needed here.
                // Just take the cost of the remaining suffixes.
                if (word1[i] == word2[j]) {
                    dp[i, j] = dp[i + 1, j + 1];
                }
                else {
                    // Characters differ → we consider all three operations:
                    //
                    // 1. Delete from word1:     dp[i + 1, j]
                    // 2. Insert into word1:     dp[i, j + 1]
                    // 3. Replace character:     dp[i + 1, j + 1]
                    //
                    // Each operation costs 1, so we add 1 to the minimum.
                    dp[i, j] = 1 + Math.Min(
                        dp[i + 1, j],                 // delete
                        Math.Min(
                            dp[i, j + 1],             // insert
                            dp[i + 1, j + 1]          // replace
                        )
                    );
                }
            }
        }

        // dp[0,0] = edit distance between the full strings
        return dp[0, 0];
    }
}
