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

    // Pointer into the preorder array (tracks which root to use next)
    int pre_idx = 0;

    // Maps each value in inorder[] to its index for O(1) lookup
    Dictionary<int, int> indices = new Dictionary<int, int>();

    public TreeNode BuildTree(int[] preorder, int[] inorder) {

        // Precompute all inorder positions to avoid repeated scanning
        for (int i = 0; i < inorder.Length; i++) {
            indices[inorder[i]] = i;
        }

        // Recursively build the tree using preorder and inorder boundaries
        return Dfs(preorder, 0, inorder.Length - 1);
    }

    private TreeNode Dfs(int[] preorder, int l, int r) {

        // If the inorder window is invalid, no subtree exists here
        if (l > r) return null;

        // The next value in preorder is always the root of this subtree
        int root_val = preorder[pre_idx++];

        // Create the root node
        TreeNode root = new TreeNode(root_val);

        // Find the root's index in inorder to split left/right subtrees
        int mid = indices[root_val];

        // Build left subtree from inorder[l .. mid-1]
        root.left = Dfs(preorder, l, mid - 1);

        // Build right subtree from inorder[mid+1 .. r]
        root.right = Dfs(preorder, mid + 1, r);

        return root;
    }
}
