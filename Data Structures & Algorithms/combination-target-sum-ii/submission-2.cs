public class Solution {
    // Stores all valid combinations
    private List<List<int>> res;

    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        res = new List<List<int>>();

        // Sort to ensure duplicates are adjacent
        // This allows us to skip repeated values cleanly
        Array.Sort(candidates);

        // Start DFS with index 0, empty combination, and total = 0
        Dfs(candidates, target, 0, new List<int>(), 0);

        return res;
    }

    private void Dfs(int[] candidates, int target, int i, List<int> cur, int total) {

        // If we hit the target exactly, record the current combination
        if (total == target) {
            res.Add(new List<int>(cur));   // copy to avoid mutation
            return;
        }

        // If we exceed the target OR run out of numbers, stop exploring
        if (total > target || i == candidates.Length) {
            return;
        }

        // --- CHOICE 1: Include candidates[i] ---
        cur.Add(candidates[i]);
        Dfs(candidates, target, i + 1, cur, total + candidates[i]);
        cur.RemoveAt(cur.Count - 1);  // backtrack

        // --- CHOICE 2: Skip candidates[i] and all duplicates of it ---
        // Move index forward past any duplicates to avoid repeated combinations
        while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1]) {
            i++;
        }

        // Explore the path where we skip this value entirely
        Dfs(candidates, target, i + 1, cur, total);
    }
}
