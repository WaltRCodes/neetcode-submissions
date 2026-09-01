public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {

        // Result list to accumulate merged intervals
        var result = new List<int[]>();

        // Iterate through all existing intervals
        for (var i = 0; i < intervals.Length; i++) {

            // Case 1: new interval ends BEFORE the current interval starts
            // → we can safely insert newInterval here and append the rest unchanged
            if (newInterval[1] < intervals[i][0]) {
                result.Add(newInterval);
                result.AddRange(intervals.AsEnumerable().Skip(i).ToArray());
                return result.ToArray();
            }

            // Case 2: new interval starts AFTER the current interval ends
            // → no overlap, so just add the current interval
            else if (newInterval[0] > intervals[i][1]) {
                result.Add(intervals[i]);
            }

            // Case 3: intervals overlap → merge them
            else {
                newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
            }
        }

        // If we finished the loop, newInterval goes at the end
        result.Add(newInterval);

        return result.ToArray();
    }
}
