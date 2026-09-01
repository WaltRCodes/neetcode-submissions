public class Solution {
    public int MaxArea(int[] heights) {
        int res = 0;
        int l = 0, r = heights.Length -1;

        while (l<r){
            int area = (Math.Min(heights[l],heights[r]))*(r-l);
            res = Math.Max(area,res);

            if (heights[l] <= heights[r]){
                l++;
            } else {
                r--;
            }
        }
        return res;
    }
}
