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

        // Use a queue to perform level‑order traversal (BFS)
        Queue<TreeNode> q = new Queue<TreeNode>();

        // If the tree is not empty, start with the root
        if (root != null) {
            q.Enqueue(root);
        }

        int level = 0; // Tracks how many levels we've processed

        // Process the tree level by level
        while (q.Count > 0) {

            // Number of nodes in the current level
            int size = q.Count;

            // Process all nodes in this level
            for (int i = 0; i < size; i++) {
                TreeNode node = q.Dequeue();

                // Add children to the queue for the next level
                if (node.left != null) {
                    q.Enqueue(node.left);
                }
                if (node.right != null) {
                    q.Enqueue(node.right);
                }
            }

            // After finishing one full level, increase depth count
            level++;
        }

        // 'level' now represents the maximum depth of the tree
        return level;
    }
}
