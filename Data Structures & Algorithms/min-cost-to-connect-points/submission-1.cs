public class Solution {
    public int MinCostConnectPoints(int[][] points) {

        int n = points.Length;

        // Start Prim's algorithm from node 0
        int node = 0;

        // dist[i] = minimum cost to connect point i to the growing MST
        int[] dist = new int[n];

        // visit[i] = whether point i is already included in the MST
        bool[] visit = new bool[n];

        // Initialize all distances to a large number
        Array.Fill(dist, 100000000);

        int edges = 0; // number of edges added to the MST
        int res = 0;   // total cost of the MST

        // Prim’s algorithm: we need exactly n - 1 edges
        while (edges < n - 1) {

            // Mark current node as part of the MST
            visit[node] = true;

            int nextNode = -1;

            // Update distances to all unvisited nodes
            for (int i = 0; i < n; i++) {

                if (visit[i]) continue;

                // Manhattan distance between current node and node i
                int curDist =
                    Math.Abs(points[i][0] - points[node][0]) +
                    Math.Abs(points[i][1] - points[node][1]);

                // Keep the minimum distance seen so far for node i
                dist[i] = Math.Min(dist[i], curDist);

                // Select the unvisited node with the smallest connection cost
                if (nextNode == -1 || dist[i] < dist[nextNode]) {
                    nextNode = i;
                }
            }

            // Add the cheapest edge to the MST
            res += dist[nextNode];

            // Move to the next node
            node = nextNode;
            edges++;
        }

        return res;
    }
}
