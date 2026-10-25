class UnionFind {
    public:
    vector<int> parent;
    vector<int> size;
    int numComponents;

    UnionFind(int n) {
        parent.resize(n);
        size.resize(n, 1);
        numComponents = n;
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    int find(int x) {
        if (x != parent[x]) {
            parent[x] = find(parent[x]);
        }
        return parent[x];
    }

    bool _union(int x, int y) {
        int rootX = find(x);
        int rootY = find(y);
        if (rootX != rootY) {
            if (size[rootX] < size[rootY]) {
                parent[rootX] = rootY;
                size[rootY] += size[rootX];
            } else {
                parent[rootY] = rootX;
                size[rootX] += size[rootY];
            }
            numComponents--;
            return true;
        }
        return false;
    }

    int getNumComponents() {
        return numComponents;
    }
};

class Solution {
public:
    int minimumSpanningTree(vector<vector<int>>& edges, int n) {
        priority_queue<tuple<int, int, int>, vector<tuple<int, int, int>>, greater<tuple<int, int, int>>> minHeap;
        for (const auto& edge : edges) {
            minHeap.push(make_tuple(edge[2], edge[0], edge[1]));
        }
        UnionFind unionFind(n);
        int totalWeight = 0;
        while (!minHeap.empty()) {
            tuple<int, int, int> cur = minHeap.top();
            int w1 = std::get<0>(cur), n1 = std::get<1>(cur), n2 = std::get<2>(cur);
            minHeap.pop();

            if (unionFind._union(n1,n2)) {
                totalWeight += w1;
            }
        }
        return unionFind.getNumComponents() != 1 ? -1 : totalWeight;
    }
};
