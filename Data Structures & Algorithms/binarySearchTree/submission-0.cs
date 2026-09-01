class TreeNode {
    public int key;
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int key, int val){
        this.key = key;
        this.val = val;
    }
}
class TreeMap {
    private TreeNode root;

    public TreeMap() {
        root = null;
    }

    public void Insert(int key, int val) {
        TreeNode newNode = new TreeNode(key, val);
        if (root == null){
            root = newNode;
            return;
        }

        TreeNode current = root;
        while (true) {
            if (key < current.key){
                if (current.left == null) {
                    current.left = newNode;
                    return;
                }
                current = current.left;
            } else if (key > current.key) {
                if (current.right == null) {
                    current.right = newNode;
                    return;
                }
                current = current.right;
            } else {
                current.val = val;
                return;
            }
        }
    }

    public int Get(int key) {
        TreeNode current = root;
        while (current != null) {
            if (key < current.key) {
                current = current.left;
            } else if (key > current.key) {
                current = current.right;
            } else {
                return current.val;
            }
        }
        return -1;
    }

    public int GetMin() {
        TreeNode current = FindMin(root);
        return (current != null) ? current.val : -1;
    }

    private TreeNode FindMin(TreeNode node) {
        while (node != null && node.left != null) {
            node = node.left;
        }
        return node;
    }

    public int GetMax() {
        TreeNode current = root;
        while (current != null && current.right != null) {
            current = current.right;
        }
        return (current != null) ? current.val : -1;
    }

    public void Remove(int key) {
        root = RemoveHelper(root, key);
    }

    private TreeNode RemoveHelper(TreeNode curr, int key) {
        if (curr == null) {
            return null;
        }

        if (key > curr.key) {
            curr.right = RemoveHelper(curr.right, key);
        } else if (key < curr.key){
            curr.left = RemoveHelper(curr.left, key);
        } else {
            if (curr.left == null) {
                return curr.right;
            } else if (curr.right == null){
                return curr.left;
            } else {
                TreeNode minNode = FindMin(curr.right);
                curr.key = minNode.key;
                curr.val = minNode.val;
                curr.right = RemoveHelper(curr.right, minNode.key);
            }
        }
        return curr;
    }

    public List<int> GetInorderKeys() {
        List<int> result = new List<int>();
        InorderTraversal(root, result);
        return result;
    }

    private void InorderTraversal(TreeNode root, List<int> result){
        if (root != null) {
            InorderTraversal(root.left, result);
            result.Add(root.key);
            InorderTraversal(root.right, result);
        }
    }

}
