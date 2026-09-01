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
    public bool IsSameTree(TreeNode p, TreeNode q) {

    // Queues used to perform a breadth-first (level-order) traversal
    // q1 traverses tree p, q2 traverses tree q
    var q1 = new Queue<TreeNode>(new[] { p });
    var q2 = new Queue<TreeNode>(new[] { q });

    // Continue while both queues have nodes to compare
    while (q1.Count > 0 && q2.Count > 0) {

        // Process all nodes currently at this level
        for (int i = q1.Count; i > 0; i--) {

            // Dequeue one node from each tree
            var nodeP = q1.Dequeue();
            var nodeQ = q2.Dequeue();

            // If both nodes are null, they match at this position
            if (nodeP == null && nodeQ == null) 
                continue;

            // If one is null, or values differ, trees are not the same
            if (nodeP == null || nodeQ == null || nodeP.val != nodeQ.val) {
                return false;
            }

            // Enqueue left and right children for both trees
            q1.Enqueue(nodeP.left);
            q1.Enqueue(nodeP.right);
            q2.Enqueue(nodeQ.left);
            q2.Enqueue(nodeQ.right);
        }
    }

    // All nodes matched in structure and value
    return true;
}

}
