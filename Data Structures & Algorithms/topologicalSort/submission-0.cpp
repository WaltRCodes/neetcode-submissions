class Solution {
public:
    unordered_map<int, vector<int>> adj;
    unordered_set<int> visited;
    unordered_set<int> visiting;
    vector<int> topSort;

    vector<int> topologicalSort(int n, vector<vector<int>>& edges) {
        for (const auto& edge : edges) {
            adj[edge[0]].push_back(edge[1]);
        }

        for (int i = 0; i < n; ++i) {
            if (!dfs(i)) {
                return {};
            }
        }

        reverse(topSort.begin(), topSort.end());
        return topSort;
    }

    bool dfs(int src) {
        if (visited.count(src)) return true;
        if (visiting.count(src)) return false;
        visiting.insert(src);

        for (int neighbor : adj[src]) {
            if (!dfs(neighbor)) return false;
        }

        visiting.erase(src);
        visited.insert(src);
        topSort.push_back(src);

        return true;
    }
};
