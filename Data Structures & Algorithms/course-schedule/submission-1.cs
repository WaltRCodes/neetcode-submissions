public class Solution {

    // Maps each course to the list of prerequisites it depends on
    private Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();

    // Tracks nodes currently in the DFS recursion stack (used to detect cycles)
    private HashSet<int> visiting = new HashSet<int>();

    public bool CanFinish(int numCourses, int[][] prerequisites) {

        // Initialize adjacency list for all courses
        for (int i = 0; i < numCourses; i++){
            preMap[i] = new List<int>();
        }

        // Build graph: prereq[0] depends on prereq[1]
        foreach (var prereq in prerequisites) {
            preMap[prereq[0]].Add(prereq[1]);
        }

        // Run DFS on every course to detect cycles
        for (int c = 0; c < numCourses; c++){
            if (!DFS(c)) {
                return false; // cycle found → cannot finish all courses
            }
        }

        return true; // no cycles → all courses can be completed
    }

    private bool DFS(int crs) {

        // If the course is already in the recursion stack, we found a cycle
        if (visiting.Contains(crs)) {
            return false;
        }

        // If this course has no prerequisites left, it's safe
        if (preMap[crs].Count == 0) {
            return true;
        }

        // Mark this course as being visited in the current DFS path
        visiting.Add(crs);

        // Visit all prerequisites
        foreach (int pre in preMap[crs]) {
            if (!DFS(pre)) {
                return false; // cycle detected in dependency chain
            }
        }

        // Remove from recursion stack after exploring all dependencies
        visiting.Remove(crs);

        // Optimization: mark this course as fully processed
        preMap[crs].Clear();

        return true;
    }
}
