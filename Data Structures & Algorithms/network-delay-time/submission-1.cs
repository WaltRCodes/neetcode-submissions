public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {

        // Build adjacency list:
        // edges[u] = list of (v, w) meaning u → v with travel time w.
        var edges = new Dictionary<int, List<int[]>>();
        foreach (var time in times) {
            if (!edges.ContainsKey(time[0])) {
                edges[time[0]] = new List<int[]>();
            }
            edges[time[0]].Add(new int[] { time[1], time[2] });
        }

        // Min‑heap for Dijkstra: (node, distance)
        // Priority is the distance.
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0);   // start from node k with distance 0

        // dist[x] = shortest known distance from k to x
        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) {
            dist[i] = int.MaxValue;
        }
        dist[k] = 0;

        // Standard Dijkstra loop
        while (pq.Count > 0) {

            // Extract node with smallest known distance
            if (pq.TryDequeue(out int node, out int minDist)) {

                // If this entry is outdated, skip it
                if (minDist > dist[node]) {
                    continue;
                }

                // Relax edges from this node
                if (edges.ContainsKey(node)) {
                    foreach (var edge in edges[node]) {
                        var next = edge[0];
                        var weight = edge[1];
                        var newDist = minDist + weight;

                        // Found a shorter path to 'next'
                        if (newDist < dist[next]) {
                            dist[next] = newDist;
                            pq.Enqueue(next, newDist);
                        }
                    }
                }
            }
        }

        // After Dijkstra, compute the maximum shortest‑path distance.
        // If any node is unreachable, return -1.
        int result = 0;
        for (int i = 1; i <= n; i++) {
            if (dist[i] == int.MaxValue) {
                return -1;  // unreachable node
            }
            result = Math.Max(result, dist[i]);
        }

        // The answer is the time it takes for the signal to reach the farthest node.
        return result;
    }
}
