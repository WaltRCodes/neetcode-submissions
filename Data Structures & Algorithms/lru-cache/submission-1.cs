public class LRUCache {

    // Maps keys → linked list nodes for O(1) access
    private Dictionary<int, LinkedListNode<(int key, int value)>> cache;

    // Doubly‑linked list storing items in LRU order:
    //   - Most recently used at the end
    //   - Least recently used at the front
    private LinkedList<(int key, int value)> order;

    // Maximum number of items the cache can hold
    private int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.cache = new Dictionary<int, LinkedListNode<(int key, int value)>>();
        this.order = new LinkedList<(int key, int value)>();
    }
    
    public int Get(int key) {
        // If key not found, return -1
        if (!cache.ContainsKey(key)) return -1;

        // Retrieve the node from the dictionary
        var node = cache[key];

        // Move this node to the end of the list (most recently used)
        order.Remove(node);
        order.AddLast(node);

        // Return the stored value
        return node.Value.value;
    }
    
    public void Put(int key, int value) {

        // If the key already exists, update and move to MRU position
        if (cache.ContainsKey(key)) {
            var node = cache[key];

            // Remove old position
            order.Remove(node);

            // Update stored value
            node.Value = (key, value);

            // Move to end (most recently used)
            order.AddLast(node);
        } 
        else {
            // If cache is full, evict the least recently used item
            if (cache.Count == capacity) {
                // First node = least recently used
                var lru = order.First.Value;

                // Remove from linked list
                order.RemoveFirst();

                // Remove from dictionary
                cache.Remove(lru.key);
            }

            // Insert new key/value pair
            var newNode = new LinkedListNode<(int key, int value)>((key, value));

            // Add to end (most recently used)
            order.AddLast(newNode);

            // Store reference in dictionary
            cache[key] = newNode;
        }
    }
}
