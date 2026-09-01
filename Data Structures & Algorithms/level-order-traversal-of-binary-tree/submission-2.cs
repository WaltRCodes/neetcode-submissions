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

    // Stores the final result: one list per depth level
    List<List<int>> res = new List<List<int>>();

    public List<List<int>> LevelOrder(TreeNode root) {
        // Start DFS from the root at depth 0
        dfs(root, 0);
        return res;
    }

    private void dfs(TreeNode node, int depth) {
        // Base case: null node means nothing to process
        if (node == null) {
            return;
        }

        // If this is the first time reaching this depth,
        // create a new list to hold values for this level
        if (res.Count == depth) {
            res.Add(new List<int>());
        }

        // Add the current node's value to its corresponding depth list
        res[depth].Add(node.val);

        // Recurse into left and right children, increasing depth
        dfs(node.left, depth + 1);
        dfs(node.right, depth + 1);
    }
}
