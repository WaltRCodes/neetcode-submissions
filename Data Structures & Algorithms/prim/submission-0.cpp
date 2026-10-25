class Solution {
public:
    int minimumSpanningTree(vector<vector<int>>& edges, int n) {
        unordered_map<int, vector<pair<int, int>>> adj;
        for (int i = 0; i < n; ++i) {
            adj[i] = vector<pair<int, int>>();
        }
        for (auto& edge : edges) {
            int n1 = edge[0], n2 = edge[1], weight = edge[2];
            adj[n1].push_back({n2, weight});
            adj[n2].push_back({n1, weight});
        }

        priority_queue<tuple<int,int,int>,vector<tuple<int,int,int>>, greater<tuple<int,int,int>>> minHeap;
        for (auto& neighbor : adj[0]) {
            int node = neighbor.first, weight = neighbor.second;
            minHeap.push(make_tuple(weight, 0, node));
        }

        int totalWeight = 0;
        unordered_set<int> visit;
        visit.insert(0);
        while (visit.size() < n && !minHeap.empty()) {
            tuple<int, int, int> cur = minHeap.top();
            minHeap.pop();
            int w1 = std::get<0>(cur), n1 = std::get<1>(cur), n2 = std::get<2>(cur);
            if(visit.find(n2) != visit.end()) {
                continue;
            }
            totalWeight += w1;
            visit.insert(n2);
            for (auto& pair : adj[n2]) {
                int neighbor = pair.first, weight = pair.second;
                if (visit.find(neighbor) == visit.end()) {
                    minHeap.push(make_tuple(weight, n2, neighbor));
                }
            }
        }
        return visit.size() == n ? totalWeight : -1;
    }
};

