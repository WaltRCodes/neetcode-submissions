/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {

        // Build a list of "events":
        // +1 when a meeting starts
        // -1 when a meeting ends
        // This lets us sweep through time and track how many rooms are in use.
        List<int[]> time = new List<int[]>();
        foreach (var i in intervals) {
            time.Add(new int[] { i.start, 1 });   // meeting starts → need one more room
            time.Add(new int[] { i.end, -1 });    // meeting ends → free one room
        }

        // Sort events by time.
        // If two events happen at the same time, process the end (-1) before start (+1)
        // so we don't count an unnecessary extra room.
        time.Sort((a, b) =>
            a[0] == b[0]
                ? a[1].CompareTo(b[1])   // end (-1) comes before start (+1)
                : a[0].CompareTo(b[0])   // otherwise sort by time
        );

        int res = 0;     // maximum rooms needed at any moment
        int count = 0;   // current number of rooms in use

        // Sweep through all time events
        foreach (var t in time) {
            count += t[1];            // apply start (+1) or end (-1)
            res = Math.Max(res, count); // track the peak usage
        }

        return res;
    }
}

