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
    public int GoodNodes(TreeNode root) {

    // Counter for the number of "good" nodes
    int res = 0;

    // Queue used for BFS traversal.
    // Each entry stores:
    // - the current node
    // - the maximum value seen so far on the path from the root to this node
    Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();

    // Start with the root node and an initial minimum value
    q.Enqueue((root, int.MinValue));

    // Continue traversal until all nodes are processed
    while (q.Count > 0) {

        // Dequeue the current node and the max value on its path
        var (node, maxval) = q.Dequeue();

        // If the current node's value is greater than or equal to
        // all values seen so far on the path, it is a "good" node
        if (node.val >= maxval) {
            res++;
        }

        // Enqueue the left child with the updated maximum value
        if (node.left != null) {
            q.Enqueue((node.left, Math.Max(maxval, node.val)));
        }

        // Enqueue the right child with the updated maximum value
        if (node.right != null) {
            q.Enqueue((node.right, Math.Max(maxval, node.val)));
        }
    }

    // Return the total number of good nodes
    return res;
}

}
