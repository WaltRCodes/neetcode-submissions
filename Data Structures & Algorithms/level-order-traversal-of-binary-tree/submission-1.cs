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
    public List<List<int>> LevelOrder(TreeNode root) {

    // Result list where each inner list represents one level of the tree
    List<List<int>> res = new List<List<int>>();

    // If the tree is empty, return an empty result
    if (root == null) return res;

    // Queue used for breadth-first traversal
    Queue<TreeNode> q = new Queue<TreeNode>();

    // Start with the root node
    q.Enqueue(root);

    // Continue while there are nodes to process
    while (q.Count > 0) {

        // List to store values at the current level
        List<int> level = new List<int>();

        // Process all nodes currently in the queue (one full level)
        for (int i = q.Count; i > 0; i--) {

            // Dequeue the next node
            TreeNode node = q.Dequeue();

            // Check for null (children may be null)
            if (node != null) {

                // Add the node's value to the current level
                level.Add(node.val);

                // Enqueue left and right children for the next level
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
        }

        // Add the level to the result if it contains values
        if (level.Count > 0) {
            res.Add(level);
        }
    }

    // Return the list of levels
    return res;
}

}
