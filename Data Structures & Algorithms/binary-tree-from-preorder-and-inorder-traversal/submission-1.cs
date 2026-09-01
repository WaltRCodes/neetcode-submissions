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

// Global indices to track position in preorder and inorder arrays
int preIdx = 0;
int inIdx = 0;

public TreeNode BuildTree(int[] preorder, int[] inorder) {
    // Start DFS with an initial limit value that won't appear in the tree
    return Dfs(preorder, inorder, int.MaxValue);
}

// Helper function to recursively construct the tree
private TreeNode Dfs(int[] preorder, int[] inorder, int limit) {

    // Base case: all nodes in preorder are processed
    if (preIdx >= preorder.Length) 
        return null;

    // If the current inorder value matches the limit, this subtree ends
    if (inorder[inIdx] == limit) {
        inIdx++;  // Move inorder index forward
        return null;
    }

    // Create the root node from the current preorder value
    TreeNode root = new TreeNode(preorder[preIdx++]);

    // Recursively build the left subtree with new limit = root value
    root.left = Dfs(preorder, inorder, root.val);

    // Recursively build the right subtree with the inherited limit
    root.right = Dfs(preorder, inorder, limit);

    // Return the constructed subtree rooted at 'root'
    return root;
}

}
