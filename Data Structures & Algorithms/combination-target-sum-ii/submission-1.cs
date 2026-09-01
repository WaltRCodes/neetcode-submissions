public class Solution {

    private HashSet<string> res; // Stores unique combinations as comma-separated strings

    // Main function to find all unique combinations (each number can be used once)
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        res = new HashSet<string>();

        // Sort array to handle duplicates and allow early pruning
        Array.Sort(candidates);

        // Start DFS/backtracking
        GenerateSubsets(candidates, target, 0, new List<int>(), 0);

        // Convert string representations back to List<int>
        return res.Select(s => s.Split(',').Select(int.Parse).ToList()).ToList();
    }

    // Helper function for DFS/backtracking
    private void GenerateSubsets(int[] candidates, int target, int i, List<int> cur, int total) {
        // Base case: combination sums to target
        if (total == target) {
            res.Add(string.Join(",", cur)); // Add combination as string to ensure uniqueness
            return;
        }

        // Base case: sum exceeds target or reached end of array
        if (total > target || i == candidates.Length) {
            return;
        }

        // Include candidates[i] in the combination
        cur.Add(candidates[i]);
        GenerateSubsets(candidates, target, i + 1, cur, total + candidates[i]);
        cur.RemoveAt(cur.Count - 1); // Backtrack

        // Exclude candidates[i] and move to next element
        GenerateSubsets(candidates, target, i + 1, cur, total);
    }
}
