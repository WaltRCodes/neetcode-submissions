public class Solution {

    public List<List<string>> Partition(string s) {
        // Result list: stores all valid palindrome partitions
        List<List<string>> res = new List<List<string>>();

        // Current partition being built during DFS
        List<string> part = new List<string>();

        // Start DFS from index 0
        Dfs(0, s, part, res);

        return res;
    }

    private void Dfs(int i, string s, List<string> part, List<List<string>> res) {
        // If we've reached the end of the string,
        // the current partition is complete and valid
        if (i >= s.Length) {
            res.Add(new List<string>(part));   // add a copy of the current path
            return;
        }

        // Try all possible substring cuts starting at index i
        for (int j = i; j < s.Length; j++) {

            // Only continue if s[i..j] is a palindrome
            if (IsPali(s, i, j)) {

                // Choose: add the palindrome substring to the current path
                part.Add(s.Substring(i, j - i + 1));

                // Explore: recursively partition the rest of the string
                Dfs(j + 1, s, part, res);

                // Un-choose: backtrack by removing the last added substring
                part.RemoveAt(part.Count - 1);
            }
        }
    }

    private bool IsPali(string s, int l, int r) {
        // Check if the substring s[l..r] is a palindrome
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}
