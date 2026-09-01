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
    public List<int> RightSideView(TreeNode root) {

    // List to store the values visible from the right side
    List<int> res = new List<int>();

    // Queue used for level-order (BFS) traversal
    Queue<TreeNode> q = new Queue<TreeNode>();

    // Start traversal from the root (may be null)
    q.Enqueue(root);

    // Continue while there are nodes to process
    while (q.Count > 0) {

        // Will hold the last (rightmost) node seen at the current level
        TreeNode rightSide = null;

        // Number of nodes at the current level
        int qLen = q.Count;

        // Process all nodes at the current level
        for (int i = 0; i < qLen; i++) {

            // Dequeue the next node
            TreeNode node = q.Dequeue();

            // Skip null nodes
            if (node != null) {

                // Update rightSide — the last valid node at this level
                rightSide = node;

                // Enqueue children for the next level
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
        }

        // Add the rightmost node's value to the result
        if (rightSide != null) {
            res.Add(rightSide.val);
        }
    }

    // Return the right-side view of the tree
    return res;
}

}
