public class Solution {
    public int[][] Merge(int[][] intervals) {

        // Find the maximum starting point among all intervals.
        // This determines how large our "map" array needs to be.
        int max = 0;
        for (int i = 0; i < intervals.Length; i++){
            max = Math.Max(intervals[i][0], max);
        }

        // Create an array where mp[i] stores the farthest end+1
        // of any interval that starts at position i.
        // (end+1 is used so that mp[i] == 0 means "no interval starts here")
        int[] mp = new int[max + 1];

        // Populate the map with the maximum end+1 for each start index.
        for (int i = 0; i < intervals.Length; i++){
            int start = intervals[i][0];
            int end = intervals[i][1];
            mp[start] = Math.Max(end + 1, mp[start]);
        }

        var res = new List<int[]>();

        // 'have' tracks the farthest end we've seen so far while merging.
        // 'intervalStart' marks the beginning of the current merged interval.
        int have = -1;
        int intervalStart = -1;

        // Sweep line over the mp array.
        for (int i = 0; i < mp.Length; i++){

            // If an interval starts at i (mp[i] != 0)
            if (mp[i] != 0) {

                // If we are not currently inside a merged interval, start one.
                if (intervalStart == -1) intervalStart = i;

                // Extend the current merged interval as far as possible.
                have = Math.Max(mp[i] - 1, have);
            }

            // If we've reached the end of the current merged interval,
            // finalize it and reset state.
            if (have == i){
                res.Add(new int[] { intervalStart, have });
                have = -1;
                intervalStart = -1;
            }
        }

        // If an interval was still open at the end of the sweep, close it.
        if (intervalStart != -1){
            res.Add(new int[] { intervalStart, have });
        }

        return res.ToArray();
    }
}
