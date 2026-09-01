public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int n = points.Length, node = 0;
        int[] dist = new int[n];
        bool[] visit = new bool[n];
        Array.Fill(dist, 100000000);
        int edges  = 0, res = 0;
        while (edges < n - 1){
            visit[node] = true;
            int nextNode = -1;
            for (int i = 0; i < n; i++) {
                if(visit[i]) continue;
                int curDist = Math.Abs(points[i][0] - points[node][0]) + Math.Abs(points[i][1] - points[node][1]);
                dist[i] = Math.Min(dist[i], curDist);
                if (nextNode == -1 || dist[i] < dist[nextNode]){
                    nextNode = i;
                }
            }
            res += dist[nextNode];
            node = nextNode;
            edges++;
        }
        return res;
    }
}
