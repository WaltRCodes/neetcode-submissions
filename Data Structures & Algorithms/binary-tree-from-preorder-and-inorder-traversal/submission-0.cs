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

    int preIdx = 0;
    int inIdx = 0;

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return Dfs(preorder, inorder, int.MaxValue);
    }

    private TreeNode Dfs(int[] preorder, int[] inorder, int limit) {
        if (preIdx >= preorder.Length) return null;
        if (inorder[inIdx] == limit) {
            inIdx++;
            return null;
        }
        TreeNode root = new TreeNode(preorder[preIdx++]);
        root.left = Dfs(preorder, inorder, root.val);
        root.right = Dfs(preorder, inorder, limit);
        return root;
    }
}
