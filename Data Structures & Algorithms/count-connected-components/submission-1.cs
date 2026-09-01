public class Solution {
    public int CountComponents(int n, int[][] edges) {

        // Adjacency list for the graph
        List<List<int>> adj = new List<List<int>>();

        // Track visited nodes during DFS
        bool[] visit = new bool[n];

        // Initialize adjacency list with empty lists
        for (int i = 0; i < n; i++){
            adj.Add(new List<int>());
        }

        // Build the undirected graph
        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int res = 0; // Number of connected components

        // Visit each node; if unvisited, start a DFS and count a new component
        for (int node = 0; node < n; node++){
            if (!visit[node]) {
                DFS(adj, visit, node);
                res++;
            }
        }

        return res;
    }

    // Depth-first search to mark all nodes in the same component
    private void DFS(List<List<int>> adj, bool[] visit, int node) {
        visit[node] = true;

        // Explore all neighbors
        foreach (var nei in adj[node]){
            if (!visit[nei]) {
                DFS(adj, visit, nei);
            }
        }
    }
}
