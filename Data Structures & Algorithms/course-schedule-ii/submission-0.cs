public class Solution {
    private List<int> output = new List<int>();
    private int[] indegree;
    private List<List<int>> adj;
    private void DFS(int node) {
        output.Add(node);
        indegree[node]--;
        foreach (var nei in adj[node]){
            indegree[nei]--;
            if (indegree[nei] == 0) {
                DFS(nei);
            }
        }
    }
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        adj = new List<List<int>>();
        for (int i = 0; i < numCourses; i++) {
            adj.Add(new List<int>());
        }
        indegree = new int[numCourses];
        foreach (var pre in prerequisites){
            indegree[pre[0]]++;
            adj[pre[1]].Add(pre[0]);
        }
        for (int i = 0; i < numCourses; i++){
            if (indegree[i] == 0) {
                DFS(i);
            }
        }
        if (output.Count != numCourses) return new int[0];
        return output.ToArray();
    }
}
