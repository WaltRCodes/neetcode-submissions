public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {

        // Sort intervals by their end time (ascending).
        // This allows us to greedily keep the interval that ends earliest.
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int res = 0;                     // Count of intervals we remove
        int prevEnd = intervals[0][1];   // End of the last interval we kept

        // Start from the second interval
        for (int i = 1; i < intervals.Length; i++) {

            int start = intervals[i][0];
            int end = intervals[i][1];

            // If the current interval starts before the previous kept interval ends,
            // they overlap → we must remove this interval.
            if (start < prevEnd) {
                res++;   // Remove current interval
            }
            else {
                // No overlap → keep this interval and update prevEnd
                prevEnd = end;
            }
        }

        return res;   // Total number of removed intervals
    }
}
