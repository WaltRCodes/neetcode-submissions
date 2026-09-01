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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {

    // Start traversal from the root of the BST
    TreeNode cur = root;

    // Iterate down the tree until the LCA is found
    while (cur != null) {

        // If both p and q are greater than current node,
        // LCA must be in the right subtree
        if (p.val > cur.val && q.val > cur.val) {
            cur = cur.right;

        // If both p and q are less than current node,
        // LCA must be in the left subtree
        } else if (p.val < cur.val && q.val < cur.val) {
            cur = cur.left;

        // Otherwise, current node is the split point
        // and hence the Lowest Common Ancestor
        } else {
            return cur;
        }
    }

    // If no common ancestor is found (should not happen in valid input)
    return null;
}

}
