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
// Global variable to store the maximum path sum found so far
int res = int.MinValue;

public int MaxPathSum(TreeNode root) {

    // Start DFS traversal to compute maximum path sum
    dfs(root);

    // Return the maximum path sum found
    return res;
}

// Helper function to compute the maximum contribution of a node
// to the path sum that can be extended to its parent
private int GetMax(TreeNode root) {
    if (root == null) return 0;

    // Recursively compute maximum contribution from left and right subtrees
    int left = GetMax(root.left);
    int right = GetMax(root.right);

    // Path sum including this node and one of its children
    int path = root.val + Math.Max(left, right);

    // Return the max contribution to parent (ignore negative sums)
    return Math.Max(0, path);
} 

// DFS function to explore all nodes and update global maximum
private void dfs(TreeNode root) {
    if (root == null) return;

    // Get the maximum contributions from left and right subtrees
    int left = GetMax(root.left);
    int right = GetMax(root.right);

    // Update the global maximum considering a path through this node
    res = Math.Max(res, root.val + left + right);

    // Recursively explore left and right subtrees
    dfs(root.left);
    dfs(root.right);
}

}
