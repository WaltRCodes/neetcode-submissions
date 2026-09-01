class Node {
    public int sum;
    public Node left;
    public Node right;
    public int L;
    public int R;

    public Node(int total, int L, int R){
        this.sum = total;
        this.left = null;
        this.right = null;
        this.L = L;
        this.R = R;
    }
}
class SegmentTree {

    Node root;

    public SegmentTree(int[] nums) {
        this.root = build(nums, 0, nums.Length -1);
    }

    private Node build(int[] nums, int L, int R) {
        if (L == R) {
            return new Node(nums[L],L, R);
        }

        int M = (L + R) / 2;
        Node root = new Node(0, L, R);
        root.left = build(nums, L, M);
        root.right = build(nums, M + 1, R);
        root.sum = root.left.sum + root.right.sum;
        return root;
    }

    public void update(int index, int val) {
        updateHelper(root, index, val);
    }

    private void updateHelper(Node root, int index, int val) {
        if (root.L == root.R) {
            root.sum = val;
            return;
        }

        int M = (root.L + root.R) / 2;
        if (index > M) {
            updateHelper(root.right, index, val);
        } else {
            updateHelper(root.left, index, val);
        }
        root.sum = root.left.sum + root.right.sum;
    }

    public int query(int L, int R) {
        return queryHelper(root, L, R);
    }

    private int queryHelper(Node root, int L, int R) {
        if (L <= root.L && root.R <= R){
            return root.sum;
        }
        if (R < root.L || L > root.R) {
            return 0;
        }
        return queryHelper(root.left, L, R) + queryHelper(root.right, L, R);
    }
}
