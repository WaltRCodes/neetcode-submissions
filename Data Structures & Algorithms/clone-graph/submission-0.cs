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
        if (node == null) return null;
        var oldToNew = new Dictionary<Node, Node>();
        var q = new Queue<Node>();
        oldToNew[node] = new Node(node.val);
        q.Enqueue(node);
        while (q.Count > 0) {
            var cur = q.Dequeue();
            foreach (var nei in cur.neighbors) {
                if(!oldToNew.ContainsKey(nei)){
                    oldToNew[nei] = new Node(nei.val);
                    q.Enqueue(nei);
                }
                oldToNew[cur].neighbors.Add(oldToNew[nei]);
            }
        }
        return oldToNew[node];
        
    }
}
