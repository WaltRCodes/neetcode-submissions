public class MedianFinder {

    // Max-heap to store the smaller half of numbers
    private PriorityQueue<int, int> small;
    
    // Min-heap to store the larger half of numbers
    private PriorityQueue<int, int> large;

    // Constructor: initialize the heaps
    public MedianFinder() {
        // Max-heap: invert comparison to get largest element on top
        small = new PriorityQueue<int, int>(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        // Min-heap: default priority queue
        large = new PriorityQueue<int, int>();
    }
    
    // Adds a number into the data structure
    public void AddNum(int num) {
        // Add to appropriate heap
        if (large.Count != 0 && num > large.Peek()) {
            large.Enqueue(num, num); // bigger than min of large heap
        } else {
            small.Enqueue(num, num); // smaller than max of small heap
        }

        // Balance the heaps: difference in size should be at most 1
        if (small.Count > large.Count + 1) {
            int val = small.Dequeue();
            large.Enqueue(val, val);
        } else if (large.Count > small.Count + 1) {
            int val = large.Dequeue();
            small.Enqueue(val,val);
        }
    }
    
    // Finds the median of current data stream
    public double FindMedian() {
        if (small.Count > large.Count) {
            return small.Peek(); // odd number of elements, max of smaller half
        } else if (large.Count > small.Count) {
            return large.Peek(); // odd number of elements, min of larger half
        }
        // Even number of elements: average of two middle values
        int smallTop = small.Peek();
        return (smallTop + large.Peek()) / 2.0;
    }
}
