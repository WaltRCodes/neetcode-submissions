public class Solution {

    // Stores the final topological order
    private List<int> output = new List<int>();

    // indegree[i] = number of prerequisites for course i
    private int[] indegree;

    // Adjacency list: adj[a] contains all courses that depend on course a
    private List<List<int>> adj;

    // DFS-based topological sort:
    // When a node reaches indegree 0, we add it to the output and
    // reduce the indegree of all its neighbors.
    private void DFS(int node) {
        output.Add(node);

        // Mark this node as processed by reducing its indegree
        indegree[node]--;

        // Explore all courses that depend on this course
        foreach (var nei in adj[node]) {

            // Reduce indegree of dependent course
            indegree[nei]--;

            // If this neighbor now has no prerequisites left, process it
            if (indegree[nei] == 0) {
                DFS(nei);
            }
        }
    }

    public int[] FindOrder(int numCourses, int[][] prerequisites) {

        // Initialize adjacency list
        adj = new List<List<int>>();
        for (int i = 0; i < numCourses; i++) {
            adj.Add(new List<int>());
        }

        // Initialize indegree array
        indegree = new int[numCourses];

        // Build graph:
        // pre[1] → pre[0] means: to take pre[0], you must first take pre[1]
        foreach (var pre in prerequisites) {
            indegree[pre[0]]++;      // pre[0] has one more prerequisite
            adj[pre[1]].Add(pre[0]); // pre[1] leads to pre[0]
        }

        // Start DFS from all nodes with indegree 0 (no prerequisites)
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                DFS(i);
            }
        }

        // If we couldn't process all courses, a cycle exists → no valid order
        if (output.Count != numCourses) return new int[0];

        return output.ToArray();
    }
}
