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
    public bool CanAttendMeetings(List<Interval> intervals) {

        // Sort all meetings by their start time.
        // This ensures that any overlapping meetings will appear next to each other.
        intervals.Sort((i1, i2) => i1.start.CompareTo(i2.start));

        // Walk through the sorted list and compare each meeting
        // with the one that comes right before it.
        for (int i = 1; i < intervals.Count; i++) {

            Interval i1 = intervals[i - 1]; // previous meeting
            Interval i2 = intervals[i];     // current meeting

            // If the previous meeting ends after the current one starts,
            // the person cannot attend both.
            if (i1.end > i2.start) {
                return false;
            }
        }

        // If we never found an overlap, all meetings are attendable.
        return true;
    }
}

