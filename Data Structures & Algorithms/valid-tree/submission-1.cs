public class Solution {
    public bool ValidTree(int n, int[][] edges) {

        // A valid tree with n nodes must have exactly n - 1 edges.
        // If there are more, a cycle must exist → not a tree.
        if (edges.Length > n - 1) {
            return false;
        }

        // Build adjacency list for the undirected graph
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }

        // Add edges to adjacency list (undirected)
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        // Track visited nodes to detect cycles and ensure connectivity
        HashSet<int> visit = new HashSet<int>();

        // BFS queue storing (currentNode, parentNode)
        Queue<(int, int)> q = new Queue<(int, int)>();

        // Start BFS from node 0
        q.Enqueue((0, -1));
        visit.Add(0);

        // Standard BFS traversal
        while (q.Count > 0) {
            var (node, parent) = q.Dequeue();

            // Explore neighbors
            foreach (var nei in adj[node]) {

                // Skip the edge leading back to the parent
                if (nei == parent) {
                    continue;
                }

                // If we see a visited neighbor that is not the parent → cycle
                if (visit.Contains(nei)) {
                    return false;
                }

                // Mark neighbor visited and continue BFS
                visit.Add(nei);
                q.Enqueue((nei, node));
            }
        }

        // A valid tree must be fully connected:
        // all n nodes must be visited
        return visit.Count == n;
    }
}
