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
    public int MaxDepth(TreeNode root) {
        Stack<Tuple<TreeNode, int>> stack = new Stack<Tuple<TreeNode,int>>();
        stack.Push(new Tuple<TreeNode, int>(root, 1));
        int res = 0;

        while (stack.Count > 0) {
            Tuple<TreeNode, int> current = stack.Pop();
            TreeNode node = current.Item1;
            int depth = current.Item2;

            if (node != null) {
                res = Math.Max(res,depth);
                stack.Push(new Tuple<TreeNode, int>(node.left, depth + 1));
                stack.Push(new Tuple<TreeNode, int>(node.right, depth + 1));
            }
        }

        return res;
    }
}
