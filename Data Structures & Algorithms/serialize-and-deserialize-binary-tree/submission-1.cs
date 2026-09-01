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

public class Codec {

    // Encodes a tree to a single string using preorder traversal.
    public string Serialize(TreeNode root) {
        List<string> res = new List<string>();
        dfsSerialize(root, res); // Helper to fill the list
        return String.Join(",", res); // Convert list to comma-separated string
    }

    // Preorder DFS serialization helper
    private void dfsSerialize(TreeNode node, List<string> res) {
        if (node == null) {
            res.Add("N"); // Marker for null nodes
            return;
        }

        // Add current node value
        res.Add(node.val.ToString());

        // Serialize left and right subtrees
        dfsSerialize(node.left, res);
        dfsSerialize(node.right, res);
    }

    // Decodes your encoded data back to a tree.
    public TreeNode Deserialize(string data) {
        string[] vals = data.Split(','); // Split the string into values
        int i = 0; // Index pointer for traversal
        return dfsDeserialize(vals, ref i); // Build tree recursively
    }

    // Preorder DFS deserialization helper
    private TreeNode dfsDeserialize(string[] vals, ref int i) {
        if (vals[i] == "N") { // Null node encountered
            i++;
            return null;
        }

        // Create node from current value
        TreeNode node = new TreeNode(Int32.Parse(vals[i]));
        i++;

        // Recur for left and right children
        node.left = dfsDeserialize(vals, ref i);
        node.right = dfsDeserialize(vals, ref i);

        return node; // Return the reconstructed subtree
    }
}

