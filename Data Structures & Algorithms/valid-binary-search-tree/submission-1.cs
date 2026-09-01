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
    public bool IsValidBST(TreeNode root) {

    // Start recursive validation with the widest possible value range
    return valid(root, long.MinValue, long.MaxValue);
}

// Helper function that checks whether the subtree rooted at `node`
// satisfies the BST property within the given (left, right) bounds
public bool valid(TreeNode node, long left, long right) {

    // An empty subtree is always valid
    if (node == null) {
        return true;
    }

    // Current node must be strictly between left and right bounds
    if (!(left < node.val && node.val < right)) {
        return false;
    }

    // Recursively validate:
    // - left subtree with updated upper bound
    // - right subtree with updated lower bound
    return valid(node.left, left, node.val) &&
           valid(node.right, node.val, right);
}

}
