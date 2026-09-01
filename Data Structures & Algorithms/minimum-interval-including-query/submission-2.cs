public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {

        // Sort intervals by their start value so we can add them to the heap
        // in the correct order as queries increase.
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // Min‑heap keyed by interval size.
        // Each entry stores: (Size, End)
        //   Size = interval length
        //   End  = right boundary, used to discard intervals that no longer cover q
        var minHeap = new PriorityQueue<(int Size, int End), int>();

        // Stores the answer for each query value.
        // Queries may not be sorted originally, so we map q → result.
        var res = new Dictionary<int, int>();

        int i = 0; // pointer into intervals

        // Sort queries so we can process them in increasing order.
        int[] sortedQueries = queries.OrderBy(q => q).ToArray();

        foreach (int q in sortedQueries) {

            // Add all intervals whose start <= q.
            // These intervals *might* contain q.
            while (i < intervals.Length && intervals[i][0] <= q) {
                int l = intervals[i][0];
                int r = intervals[i][1];
                int size = r - l + 1;

                // Push interval into heap, keyed by its size.
                minHeap.Enqueue((size, r), size);
                i++;
            }

            // Remove intervals that end before q.
            // They cannot contain q anymore.
            while (minHeap.Count > 0 && minHeap.Peek().End < q) {
                minHeap.Dequeue();
            }

            // The top of the heap is the smallest interval that contains q.
            res[q] = minHeap.Count == 0 ? -1 : minHeap.Peek().Size;
        }

        // Build the result array in the original query order.
        int[] result = new int[queries.Length];
        for (int j = 0; j < queries.Length; j++) {
            result[j] = res[queries[j]];
        }

        return result;
    }
}
