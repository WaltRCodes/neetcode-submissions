public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

        var minHeap = new PriorityQueue<(int Size, int End), int>();
        var res = new Dictionary<int, int>();
        int i = 0;

        int[] sortedQueries = queries.OrderBy(q => q).ToArray();
        foreach (int q in sortedQueries){
            while (i < intervals.Length && intervals[i][0] <= q){
                int l = intervals[i][0];
                int r = intervals[i][1];
                minHeap.Enqueue((r - l + 1, r), r - l + 1);
                i++;
            }
            while (minHeap.Count > 0 && minHeap.Peek().End < q){
                minHeap.Dequeue();
            }
            res[q] = minHeap.Count == 0 ? -1 : minHeap.Peek().Size;
        }
        int[] result = new int[queries.Length];
        for (int j = 0; j < queries.Length; j++) {
            result[j] = res[queries[j]];
        }
        return result;
    }
}
