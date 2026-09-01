public class Solution {
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int,int>();
        foreach (int s in stones) {
            minHeap.Enqueue(-s, -s);
        }

        while (minHeap.Count > 1) {
            int first = minHeap.Dequeue();
            int second = minHeap.Dequeue();
            if (second > first) {
                minHeap.Enqueue(first - second, first - second);
            }
        }
        minHeap.Enqueue(0,0);
        return Math.Abs(minHeap.Peek());
    }
}
