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
// Serializes a binary tree into a string using preorder traversal.
// "$" marks the start of a node value and "#"" represents a null node.
// This encoding uniquely identifies both structure and values.
public string Serialize(TreeNode root) {

    // Null node marker
    if (root == null) {
        return "$#";
    }

    // Preorder: node value + left subtree + right subtree
    return "$" + root.val 
           + Serialize(root.left) 
           + Serialize(root.right);
}

// Computes the Z-function (Z-array) for a string.
// z[i] = length of the longest substring starting at i
// that matches the prefix of the string.
public int[] ZFunction(string s) {

    int n = s.Length;
    int[] z = new int[n];

    // [l, r] defines the current Z-box interval
    int l = 0, r = 0;

    // Start from index 1 since z[0] is always 0
    for (int i = 1; i < n; i++) {

        // If i is inside the Z-box, reuse previous computations
        if (i <= r) {
            z[i] = Math.Min(r - i + 1, z[i - l]);
        }

        // Expand the match beyond the Z-box if possible
        while (i + z[i] < n && s[z[i]] == s[i + z[i]]) {
            z[i]++;
        }

        // Update the Z-box if we extended past r
        if (i + z[i] - 1 > r) {
            l = i;
            r = i + z[i] - 1;
        }
    }

    return z;
}

// Determines whether subRoot is a subtree of root
// using tree serialization and the Z-algorithm for pattern matching.
public bool IsSubtree(TreeNode root, TreeNode subRoot){

    // Serialize both trees
    string serialized_root = Serialize(root);
    string serialized_subRoot = Serialize(subRoot);

    // Combine strings with a delimiter to avoid overlap issues
    string combined = serialized_subRoot + "|" + serialized_root;

    // Compute Z-values for pattern matching
    int[] z_values = ZFunction(combined);
    int sub_len = serialized_subRoot.Length;

    // Check if serialized_subRoot appears in serialized_root
    for (int i = sub_len + 1; i < combined.Length; i++) {
        if (z_values[i] == sub_len) {
            return true;
        }
    }

    // No match found
    return false;
}
}
