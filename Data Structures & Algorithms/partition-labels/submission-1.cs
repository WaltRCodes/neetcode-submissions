public class Solution {
    public List<int> PartitionLabels(string s) {

        // Map each character to the last index where it appears in the string.
        // This lets us know how far a partition must extend to include all
        // occurrences of every character inside it.
        Dictionary<char, int> lastIndex = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            lastIndex[s[i]] = i;
        }

        List<int> res = new List<int>();

        int size = 0; // current partition size
        int end = 0;  // the farthest index this partition must reach

        // Walk through the string and expand the current partition
        // until we've included all characters that appear within it.
        for (int i = 0; i < s.Length; i++) {

            size++; // grow current partition

            // Update the required end boundary based on this character's last occurrence
            end = Math.Max(end, lastIndex[s[i]]);

            // If we've reached the boundary, we can close this partition
            if (i == end) {
                res.Add(size); // record partition size
                size = 0;      // reset for next partition
            }
        }

        return res;
    }
}
