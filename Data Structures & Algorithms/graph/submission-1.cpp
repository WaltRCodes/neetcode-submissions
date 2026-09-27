class Graph {
    private:
    unordered_map<int, unordered_set<int>> adj_list;

    bool hasPathDFS(int src, int dst, unordered_set<int> &visited) {
        if (src == dst) {
            return true;
        }
        visited.insert(src);
        for (const int &neighbor : adj_list[src]) {
            if (visited.find(neighbor) == visited.end()) {
                if (hasPathDFS(neighbor, dst, visited)) {
                    return true;
                }
            }
        }
        return false;
    }
public:
    Graph() {}

    void addEdge(int src, int dst) {
        adj_list[src].insert(dst);
    }

    bool removeEdge(int src, int dst) {
        if (adj_list.find(src) == adj_list.end() || adj_list[src].find(dst) == adj_list[src].end()) {
            return false;
        }
        adj_list[src].erase(dst);
        return true;
    }

    bool hasPath(int src, int dst) {
        unordered_set<int> visited;
        return hasPathDFS(src,dst,visited);
    }
};
