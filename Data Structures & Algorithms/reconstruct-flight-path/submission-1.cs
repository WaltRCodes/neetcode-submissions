public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {

        // Build adjacency list:
        // For each departure airport, store a list of arrival airports.
        // Sort tickets in descending order so we can pop the *smallest* destination
        // from the *end* of the list (efficient for lexicographically smallest path).
        var adj = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets.OrderByDescending(t => t[1])) {
            if (!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }
            adj[ticket[0]].Add(ticket[1]);
        }

        // Result itinerary (will be built in reverse)
        var res = new List<string>();

        // Stack used for Hierholzer’s algorithm (Eulerian path construction)
        var stack = new Stack<string>();
        stack.Push("JFK");  // itinerary must start at JFK

        // Perform DFS-like traversal
        while (stack.Count > 0) {

            var curr = stack.Peek();

            // If no outgoing edges remain from this airport,
            // add it to the itinerary (in reverse order).
            if (!adj.ContainsKey(curr) || adj[curr].Count == 0) {
                res.Insert(0, stack.Pop());
            }
            else {
                // Otherwise, follow the lexicographically smallest unused edge.
                var next = adj[curr][adj[curr].Count - 1];
                adj[curr].RemoveAt(adj[curr].Count - 1);
                stack.Push(next);
            }
        }

        return res;
    }
}
