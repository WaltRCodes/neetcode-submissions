/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;          // Value of the node
 *     public TreeNode left;    // Left child
 *     public TreeNode right;   // Right child
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    // Index pointer for preorder traversal
    // Tracks which node we are currently creating
    int preIdx = 0;

    // Index pointer for inorder traversal
    // Tracks subtree boundaries
    int inIdx = 0;

    // Main function to build tree from preorder and inorder arrays
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // Start DFS with no upper boundary (int.MaxValue acts as sentinel)
        return Dfs(preorder, inorder, int.MaxValue);
    }

    // Recursive DFS function
    // "limit" acts as a boundary marker to know when to stop building a subtree
    private TreeNode Dfs(int[] preorder, int[] inorder, int limit) {

        // If we've used all preorder elements, stop recursion
        if (preIdx >= preorder.Length) 
            return null;

        // If current inorder value matches the limit,
        // it means we've finished building this subtree.
        // Move inorder pointer forward and stop this branch.
        if (inorder[inIdx] == limit) {
            inIdx++;
            return null;
        }

        // Create the root node using current preorder value
        // Preorder order: Root -> Left -> Right
        TreeNode root = new TreeNode(preorder[preIdx++]);

        // Recursively build left subtree
        // The current root value becomes the new boundary (limit)
        // because in inorder traversal, left subtree appears before root
        root.left = Dfs(preorder, inorder, root.val);

        // Recursively build right subtree
        // After finishing left subtree, build right subtree
        // The limit remains the same as parent boundary
        root.right = Dfs(preorder, inorder, limit);

        return root;
    }
}
