public class Solution {
    public int LastStoneWeight(int[] stones) {

    // Max-heap simulated using PriorityQueue with negative values
    PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
    foreach (int s in stones) {
        // Store negative to simulate max-heap behavior
        minHeap.Enqueue(-s, -s);
    }

    // Continue until only one or zero stones remain
    while (minHeap.Count > 1) {

        // Remove the two heaviest stones (largest values)
        int first = minHeap.Dequeue();  // heaviest
        int second = minHeap.Dequeue(); // second heaviest

        // If the stones are not equal, push the difference back into heap
        if (second > first) {
            minHeap.Enqueue(first - second, first - second);
        }
    }

    // Ensure heap is non-empty for final peek
    minHeap.Enqueue(0, 0);

    // Return the absolute value of the remaining stone
    return Math.Abs(minHeap.Peek());
}

}
