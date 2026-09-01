public class CountSquares {
    private Dictionary<(int, int), int> ptsCount;
    private List<int[]> pts;

    public CountSquares() {
        ptsCount = new Dictionary<(int, int), int>();
        pts = new List<int[]>();
    }
    
    public void Add(int[] point) {
        var tuplePoint = (point[0],point[1]);
        if (!ptsCount.ContainsKey(tuplePoint))
            ptsCount[tuplePoint] = 0;
        ptsCount[tuplePoint]++;
        pts.Add(point);
    }
    
    public int Count(int[] point) {
        int res = 0;
        int px = point[0];
        int py = point[1];

        foreach (var pt in pts){
            int x = pt[0];
            int y = pt[1];

            if(Math.Abs(py - y) != Math.Abs(px - x) || x == px || y == py)
                continue;
            res += (ptsCount.GetValueOrDefault((x, py)) * ptsCount.GetValueOrDefault((px,y)));
        }
        return res;
    }
}
