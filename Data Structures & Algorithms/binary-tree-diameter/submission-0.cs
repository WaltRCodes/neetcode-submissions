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
    public int DiameterOfBinaryTree(TreeNode root) {
        if (root == null) {
            return 0;
        }

        Stack<TreeNode> stack = new Stack<TreeNode>();
        Dictionary<TreeNode, (int, int)> mp = new Dictionary<TreeNode, (int, int)>();
        stack.Push(root);

        while (stack.Count > 0) {
            TreeNode node = stack.Peek();

            if (node.left != null && !mp.ContainsKey(node.left)){
                stack.Push(node.left);
            } else if (node.right != null && !mp.ContainsKey(node.right)) {
                stack.Push(node.right);
            } else {
                node = stack.Pop();

                int leftHeight = 0, leftDiameter = 0;
                if (node.left != null && mp.ContainsKey(node.left)) {
                    (leftHeight, leftDiameter) = mp[node.left];
                }

                int rightHeight = 0, rightDiameter = 0;
                if (node.right != null && mp.ContainsKey(node.right)) {
                    (rightHeight,rightDiameter) = mp[node.right];
                }

                int height = 1 + Math.Max(leftHeight, rightHeight);
                int diameter = Math.Max(leftHeight + rightHeight, Math.Max(leftDiameter,rightDiameter));

                mp[node] = (height,diameter);
            }
        }

        return mp[root].Item2;
    }
}
