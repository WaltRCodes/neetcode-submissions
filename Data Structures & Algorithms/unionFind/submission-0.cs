public class UnionFind {
    int[] parent;
    int[] size;
    int numComponents;

    public UnionFind(int n) {
        parent = new int[n];
        size = new int[n];
        numComponents = n;
        for (int i = 0; i < n; i++){
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int x) {
        if (x != parent[x]) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    public bool IsSameComponent(int x, int y) {
        return Find(x) == Find(y);
    }

    public bool Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY) {
            if (size[rootX] < size[rootY]){
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

    public int GetNumComponents() {
        return numComponents;
    }
}