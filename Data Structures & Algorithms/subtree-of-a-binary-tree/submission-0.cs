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
    public string Serialize(TreeNode root) {
        if (root == null) {
            return "$#";
        }
        return "$" + root.val + Serialize(root.left) + Serialize(root.right);
    }

    public int[] ZFunction(string s) {
        int[] z = new int[s.Length];
        int l = 0, r = 0, n = s.Length;
        for (int i = 1; i < n; i++){
            if (i <= r){
                z[i] = Math.Min(r - i + 1, z[i - l]);
            }
            while (i + z[i] < n && s[z[i]] == s[i + z[i]]) {
                z[i]++;
            }
            if (i + z[i] - 1 > r) {
                l = i;
                r = i + z[i] - 1;
            }
        }
        return z;
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot){
        string serialized_root = Serialize(root);
        string serialized_subRoot = Serialize(subRoot);
        string combined = serialized_subRoot + "|" + serialized_root;

        int[] z_values = ZFunction(combined);
        int sub_len = serialized_subRoot.Length;

        for (int i = sub_len + 1; i < combined.Length; i++) {
            if (z_values[i] == sub_len) {
                return true;
            }
        }

        return false;
    }
}
