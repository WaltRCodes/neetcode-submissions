public class CountSquares {
    // Stores how many times each point appears: (x, y) → count
    private Dictionary<(int, int), int> ptsCount;

    // Stores all points in the order they were added
    private List<int[]> pts;

    public CountSquares() {
        ptsCount = new Dictionary<(int, int), int>();
        pts = new List<int[]>();
    }
    
    public void Add(int[] point) {
        // Convert array to tuple for dictionary key
        var tuplePoint = (point[0], point[1]);

        // Initialize count if point hasn't been seen before
        if (!ptsCount.ContainsKey(tuplePoint))
            ptsCount[tuplePoint] = 0;

        // Increment count for this point
        ptsCount[tuplePoint]++;

        // Also store the point in the list for iteration
        pts.Add(point);
    }
    
    public int Count(int[] point) {
        int res = 0;

        // Coordinates of the query point
        int px = point[0];
        int py = point[1];

        // Iterate through all previously added points
        foreach (var pt in pts) {
            int x = pt[0];
            int y = pt[1];

            // Check if (x, y) can form a diagonal with (px, py)
            // Conditions for a valid diagonal:
            //   1. |Δx| == |Δy|  → same distance horizontally and vertically
            //   2. x != px       → not on same vertical line
            //   3. y != py       → not on same horizontal line
            if (Math.Abs(py - y) != Math.Abs(px - x) || x == px || y == py)
                continue;

            // If (x, y) is a diagonal corner, the other two corners are:
            //   (x, py) and (px, y)
            // Multiply their counts to account for duplicates
            res += ptsCount.GetValueOrDefault((x, py)) *
                   ptsCount.GetValueOrDefault((px, y));
        }

        return res;
    }
}
