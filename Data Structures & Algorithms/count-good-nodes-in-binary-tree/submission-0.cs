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
        int res = 0;
        Queue<(TreeNode, int)> q = new Queue<(TreeNode,int)>();
        q.Enqueue((root, int.MinValue));

        while (q.Count > 0) {
            var (node, maxval) = q.Dequeue();
            if (node.val >= maxval) {
                res++;
            }
            if (node.left != null) {
                q.Enqueue((node.left, Math.Max(maxval, node.val)));
            }
            if (node.right != null) {
                q.Enqueue((node.right, Math.Max(maxval, node.val)));
            }
        }
        return res;
    }
}
