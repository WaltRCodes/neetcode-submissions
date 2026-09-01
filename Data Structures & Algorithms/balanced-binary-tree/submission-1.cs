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

    // Stack used to perform an iterative post-order traversal
    Stack<TreeNode> stack = new Stack<TreeNode>();

    // 'node' is the current node being traversed
    // 'last' keeps track of the last node that was processed
    TreeNode node = root, last = null;

    // Dictionary to store the depth (height) of each subtree
    Dictionary<TreeNode, int> depths = new Dictionary<TreeNode, int>();

    // Continue traversal while there are nodes to process
    while (stack.Count > 0 || node != null) {

        // Traverse left subtree as far as possible
        if (node != null) {
            stack.Push(node);
            node = node.left;

        } else {
            // Peek at the top node without removing it
            node = stack.Peek();

            // If right child is null or already processed,
            // we can now process the current node
            if (node.right == null || last == node.right) {

                // Remove the node from the stack
                stack.Pop();

                // Get left subtree depth (0 if it does not exist)
                int left = (node.left != null && depths.ContainsKey(node.left))
                            ? depths[node.left]
                            : 0;

                // Get right subtree depth (0 if it does not exist)
                int right = (node.right != null && depths.ContainsKey(node.right))
                            ? depths[node.right]
                            : 0;

                // If the difference in heights is greater than 1,
                // the tree is not height-balanced
                if (Math.Abs(left - right) > 1) 
                    return false;

                // Store the depth of the current node
                depths[node] = 1 + Math.Max(left, right);

                // Mark this node as the last processed node
                last = node;

                // Reset node to continue popping from the stack
                node = null;

            } else {
                // Right subtree has not been processed yet
                node = node.right;
            }
        }
    }

    // All nodes satisfy the balance condition
    return true;
}

}
