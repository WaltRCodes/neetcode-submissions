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
    public int MaxDepth(TreeNode root) {

    // Stack to perform iterative DFS.
    // Each entry stores a node and its corresponding depth.
    Stack<Tuple<TreeNode, int>> stack = new Stack<Tuple<TreeNode, int>>();

    // Push the root node with an initial depth of 1
    stack.Push(new Tuple<TreeNode, int>(root, 1));

    // Variable to store the maximum depth found
    int res = 0;

    // Continue traversal until all nodes are processed
    while (stack.Count > 0) {

        // Pop the top element from the stack
        Tuple<TreeNode, int> current = stack.Pop();
        TreeNode node = current.Item1;
        int depth = current.Item2;

        // Only process non-null nodes
        if (node != null) {

            // Update the maximum depth
            res = Math.Max(res, depth);

            // Push left child with incremented depth
            stack.Push(new Tuple<TreeNode, int>(node.left, depth + 1));

            // Push right child with incremented depth
            stack.Push(new Tuple<TreeNode, int>(node.right, depth + 1));
        }
    }

    // Return the maximum depth of the binary tree
    return res;
}

}
