public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {

        // Tracks which indices (0,1,2) of the target we can match.
        // We need all three to succeed.
        HashSet<int> good = new HashSet<int>();

        foreach (var t in triplets) {

            // A triplet is only usable if ALL its values
            // are <= the corresponding target values.
            // Otherwise, merging it would exceed the target.
            if (t[0] > target[0] || t[1] > target[1] || t[2] > target[2]) {
                continue;
            }

            // For each component of the triplet,
            // if it matches the target exactly,
            // then this triplet can help satisfy that index.
            for (int i = 0; i < t.Length; i++) {
                if (t[i] == target[i]) {
                    good.Add(i);
                }
            }
        }

        // We can form the target only if we matched all 3 components.
        return good.Count == 3;
    }
}
