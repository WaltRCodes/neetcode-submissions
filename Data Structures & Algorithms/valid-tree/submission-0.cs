public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length > n - 1) {
            return false;
        }

        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }
        HashSet<int> visit = new HashSet<int>();
        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((0, -1));
        visit.Add(0);
        while (q.Count > 0) {
            var (node, parent) = q.Dequeue();
            foreach (var nei in adj[node]) {
                if (nei == parent) {
                    continue;
                }
                if (visit.Contains(nei)){
                    return false;
                }
                visit.Add(nei);
                q.Enqueue((nei, node));
            }
        }
        return visit.Count == n;
    }
}
