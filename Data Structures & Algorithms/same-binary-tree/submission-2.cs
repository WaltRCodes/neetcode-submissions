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

        // Stack holds pairs of nodes to compare
        var stack = new Stack<(TreeNode, TreeNode)>();

        // Start by comparing the roots
        stack.Push((p, q));

        while (stack.Count > 0) {

            // Pop the next pair of nodes to compare
            var (node1, node2) = stack.Pop();

            // If both nodes are null, this branch matches — continue
            if (node1 == null && node2 == null) continue;

            // If only one is null OR values differ, trees are not the same
            if (node1 == null || node2 == null || node1.val != node2.val) {
                return false;
            }

            // Push children to compare later
            // Right children
            stack.Push((node1.right, node2.right));

            // Left children
            stack.Push((node1.left, node2.left));
        }

        // If we never found a mismatch, the trees are identical
        return true;
    }
}
