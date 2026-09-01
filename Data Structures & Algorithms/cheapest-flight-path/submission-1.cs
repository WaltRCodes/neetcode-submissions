public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {

        // prices[i] = cheapest known cost to reach city i
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;

        // Build adjacency list: adj[u] = list of (v, price)
        List<int[]>[] adj = new List<int[]>[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new List<int[]>();
        }
        foreach (var flight in flights) {
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        // Queue holds (currentCost, currentCity, stopsUsed)
        var q = new Queue<(int cst, int node, int stops)>();
        q.Enqueue((0, src, 0));

        // BFS-like traversal, but with cost relaxation
        while (q.Count > 0) {

            var (cst, node, stops) = q.Dequeue();

            // If we exceed allowed stops, skip this path
            if (stops > k) continue;

            // Explore neighbors
            foreach (var neighbor in adj[node]) {
                int nei = neighbor[0];
                int w = neighbor[1];
                int nextCost = cst + w;

                // Relaxation: found a cheaper way to reach 'nei'
                if (nextCost < prices[nei]) {
                    prices[nei] = nextCost;
                    q.Enqueue((nextCost, nei, stops + 1));
                }
            }
        }

        // If destination is unreachable within k stops, return -1
        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}
