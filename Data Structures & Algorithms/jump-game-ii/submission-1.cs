public class Solution {
    public int Jump(int[] nums) {

        // res = number of jumps taken so far
        // l, r = current "window" of indices reachable with res jumps
        int res = 0, l = 0, r = 0;

        // We stop once the right boundary reaches or passes the last index
        while (r < nums.Length - 1) {

            // farthest = the farthest index we can reach in the next jump
            int farthest = 0;

            // Explore all indices in the current window [l, r]
            // This simulates one BFS layer: all positions reachable with 'res' jumps
            for (int i = l; i <= r; i++) {
                farthest = Math.Max(farthest, i + nums[i]);
            }

            // Move to the next window:
            // new left boundary is just after the old right boundary
            l = r + 1;

            // new right boundary is the farthest we can reach from this layer
            r = farthest;

            // We used one more jump to reach this new window
            res++;
        }

        return res;
    }
}
