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
    // Inverts a binary tree using an iterative DFS approach
    public TreeNode InvertTree(TreeNode root) {

        // If the tree is empty, return null
        if (root == null) return null;

        // Stack used to traverse the tree iteratively
        Stack<TreeNode> stack = new Stack<TreeNode>();

        // Start with the root node
        stack.Push(root);

        // Continue until all nodes are processed
        while (stack.Count > 0) {

            // Pop the current node from the stack
            TreeNode node = stack.Pop();

            // Swap the left and right children
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;

            // Push left child to stack if it exists
            if (node.left != null) 
                stack.Push(node.left);

            // Push right child to stack if it exists
            if (node.right != null) 
                stack.Push(node.right);
        }

        // Return the root of the inverted tree
        return root;
    }
}

