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
    public bool IsBalanced(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root, last = null;
        Dictionary<TreeNode, int> depths = new Dictionary<TreeNode, int>();

        while (stack.Count > 0 || node != null) {
            if (node != null) {
                stack.Push(node);
                node = node.left;
            } else {
                node = stack.Peek();
                if (node.right == null || last == node.right) {
                    stack.Pop();

                    int left = (node.left != null && depths.ContainsKey(node.left)) ? depths[node.left] : 0;

                    int right = (node.right != null && depths.ContainsKey(node.right)) ? depths[node.right] : 0;

                    if (Math.Abs(left - right) > 1) return false;

                    depths[node] = 1 + Math.Max(left,right);
                    last = node;
                    node = null;
                } else {
                    node = node.right;
                }
            }
        }
        return true;
    }
}
