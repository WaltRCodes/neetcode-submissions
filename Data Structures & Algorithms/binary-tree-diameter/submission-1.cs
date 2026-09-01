/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int DiameterOfBinaryTree(TreeNode root) {

    // If the tree is empty, the diameter is 0
    if (root == null) {
        return 0;
    }

    // Stack used to perform an iterative post-order traversal
    Stack<TreeNode> stack = new Stack<TreeNode>();

    // Dictionary to store computed values for each node:
    // Key   → TreeNode
    // Value → (height of subtree, diameter of subtree)
    Dictionary<TreeNode, (int, int)> mp = new Dictionary<TreeNode, (int, int)>();

    // Start traversal from the root
    stack.Push(root);

    // Continue until all nodes are processed
    while (stack.Count > 0) {

        // Peek at the top node without removing it
        TreeNode node = stack.Peek();

        // Traverse left subtree first if not yet processed
        if (node.left != null && !mp.ContainsKey(node.left)) {
            stack.Push(node.left);

        // Traverse right subtree if left is already processed
        } else if (node.right != null && !mp.ContainsKey(node.right)) {
            stack.Push(node.right);

        // Both children are processed (or null), now process this node
        } else {
            node = stack.Pop();

            // Retrieve left child's height and diameter if it exists
            int leftHeight = 0, leftDiameter = 0;
            if (node.left != null && mp.ContainsKey(node.left)) {
                (leftHeight, leftDiameter) = mp[node.left];
            }

            // Retrieve right child's height and diameter if it exists
            int rightHeight = 0, rightDiameter = 0;
            if (node.right != null && mp.ContainsKey(node.right)) {
                (rightHeight, rightDiameter) = mp[node.right];
            }

            // Height of current node = 1 + max height of children
            int height = 1 + Math.Max(leftHeight, rightHeight);

            // Diameter at current node is the max of:
            // 1) Path through the node (leftHeight + rightHeight)
            // 2) Maximum diameter in left subtree
            // 3) Maximum diameter in right subtree
            int diameter = Math.Max(
                leftHeight + rightHeight,
                Math.Max(leftDiameter, rightDiameter)
            );

            // Store computed height and diameter for this node
            mp[node] = (height, diameter);
        }
    }

    // The diameter of the entire tree is stored at the root
    return mp[root].Item2;
}

}
