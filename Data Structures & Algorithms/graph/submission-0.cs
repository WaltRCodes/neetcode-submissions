public class Graph {
    private Dictionary<int, HashSet<int>> adjList;

    public Graph() {
        adjList = new Dictionary<int, HashSet<int>>();
    }

    public void AddEdge(int src, int dst) {
        if (!adjList.ContainsKey(src)) adjList[src] = new HashSet<int>();
        if (!adjList.ContainsKey(dst)) adjList[dst] = new HashSet<int>();

        adjList[src].Add(dst);
    }

    public bool RemoveEdge(int src, int dst) {
        if (!adjList.ContainsKey(src) || !adjList[src].Contains(dst)) {
            return false;
        }

        adjList[src].Remove(dst);
        return true;
    }

    public bool HasPath(int src, int dst) {
        HashSet<int> visited = new HashSet<int>();
        return HasPathDFS(src, dst, visited);
    }

    public bool HasPathDFS(int src, int dst, HashSet<int> visited) {
        if (src == dst) {
            return true;
        }
        visited.Add(src);
        foreach (int neighbor in adjList.GetValueOrDefault(src, new HashSet<int>()))
        {
            if (!visited.Contains(neighbor)){
                if(HasPathDFS(neighbor, dst, visited)) {
                    return true;
                }
            }
        }

        return false;
    }

}
