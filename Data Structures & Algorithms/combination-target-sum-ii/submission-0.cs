public class Solution {
    private HashSet<string> res;
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        res = new HashSet<string>();
        Array.Sort(candidates);
        GenerateSubsets(candidates,target,0,new List<int>(),0);
        return res.Select(s => s.Split(',').Select(int.Parse).ToList()).ToList();
    }

    private void GenerateSubsets(int[] candidates, int target, int i, List<int> cur, int total) {
        if (total == target) {
            res.Add(string.Join(",", cur));
            return;
        }
        if (total > target || i == candidates.Length) {
            return;
        }

        cur.Add(candidates[i]);
        GenerateSubsets(candidates, target, i + 1, cur, total + candidates[i]);
        cur.RemoveAt(cur.Count - 1);

        GenerateSubsets(candidates,target,i+1,cur,total);
    }
}
