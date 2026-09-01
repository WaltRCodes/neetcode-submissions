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
    public int KthSmallest(TreeNode root, int k) {

    // Start traversal from the root
    TreeNode curr = root;

    // Use Morris Inorder Traversal to avoid recursion / stack
    while (curr != null) {

        // If there is no left child, process current node
        if (curr.left == null) {
            k--;  // Count this node
            if (k == 0) return curr.val;  // Found the kth smallest
            curr = curr.right;  // Move to right subtree
        } 
        else {
            // Find the inorder predecessor of the current node
            TreeNode pred = curr.left;
            while (pred.right != null && pred.right != curr)
                pred = pred.right;

            // If predecessor's right is null, make a temporary thread to current
            if (pred.right == null) {
                pred.right = curr;  // Create thread
                curr = curr.left;   // Move to left subtree
            } 
            else { 
                // Thread exists, remove it and process current node
                pred.right = null;  // Remove temporary link
                k--;  // Count this node
                if (k == 0) return curr.val;  // Found the kth smallest
                curr = curr.right;  // Move to right subtree
            }
        }
    }

    // If k is invalid
    return -1;
}

}
