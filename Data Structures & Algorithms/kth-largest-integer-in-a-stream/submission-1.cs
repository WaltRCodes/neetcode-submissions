public class KthLargest {

    // Min-heap to store the k largest elements
    private PriorityQueue<int,int> minHeap;
    
    // k-th largest element to track
    private int k;

    // Constructor: initialize the heap with the first numbers
    public KthLargest(int k, int[] nums) {
        this.k = k;
        this.minHeap = new PriorityQueue<int, int>();

        // Add each number to the heap
        foreach (int num in nums) {
            minHeap.Enqueue(num, num);  // PriorityQueue uses value as priority
            if (minHeap.Count > k) {    // Keep heap size at most k
                minHeap.Dequeue();      // Remove smallest element
            }
        }
    }
    
    // Adds a new value and returns the k-th largest element
    public int Add(int val) {
        minHeap.Enqueue(val, val);      // Add new value
        if (minHeap.Count > k) {        // Maintain heap size k
            minHeap.Dequeue();          // Remove smallest element
        }
        return minHeap.Peek();          // The smallest in heap is the k-th largest overall
    }
}
