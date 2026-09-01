public class Solution {

    public int[] FindRedundantConnection(int[][] edges) {

        // Parent array for Union-Find (1-indexed)
        int[] par = new int[edges.Length + 1];

        // Rank array to keep tree shallow (stores size of each set)
        int[] rank = new int[edges.Length + 1];

        // Initialize each node to be its own parent
        for (int i = 0; i < par.Length; i++){
            par[i] = i;
            rank[i] = 1;
        }

        // Process each edge; if Union returns false, the edge creates a cycle
        foreach (var edge in edges) {
            if (!Union(par, rank, edge[0], edge[1])) {
                // This edge connects two nodes already in the same set → redundant
                return new int[]{ edge[0], edge[1] };
            }
        }

        // Should never reach here for valid input
        return new int[0];
    }

    // Find with path compression
    private int Find(int[] par, int n) {
        int p = par[n];

        // Climb up until reaching the root
        while (p != par[p]) {
            // Path compression: point node directly to its grandparent
            par[p] = par[par[p]];
            p = par[p];
        }

        return p;
    }

    // Union by rank (size)
    private bool Union(int[] par, int[] rank, int n1, int n2) {

        // Find roots of both nodes
        int p1 = Find(par, n1);
        int p2 = Find(par, n2);

        // If they share the same root, adding this edge creates a cycle
        if (p1 == p2) {
            return false;
        }

        // Attach smaller tree under larger tree
        if (rank[p1] > rank[p2]) {
            par[p2] = p1;
            rank[p1] += rank[p2];
        } else {
            par[p1] = p2;
            rank[p2] += rank[p1];
        }

        return true;
    }
}
