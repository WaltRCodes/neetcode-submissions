/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) return null; // Handle empty graph

        // Dictionary to map original nodes to their cloned counterparts
        var oldToNew = new Dictionary<Node, Node>();
        // Queue for BFS traversal
        var q = new Queue<Node>();

        // Clone the starting node and put it in the dictionary
        oldToNew[node] = new Node(node.val);
        q.Enqueue(node);

        // BFS traversal
        while (q.Count > 0) {
            var cur = q.Dequeue();
            // Iterate through all neighbors of the current node
            foreach (var nei in cur.neighbors) {
                // If neighbor is not cloned yet, clone it and enqueue
                if(!oldToNew.ContainsKey(nei)){
                    oldToNew[nei] = new Node(nei.val);
                    q.Enqueue(nei);
                }
                // Link the cloned current node to the cloned neighbor
                oldToNew[cur].neighbors.Add(oldToNew[nei]);
            }
        }

        // Return the clone of the starting node
        return oldToNew[node];
    }
}

