public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        HashSet<int> good = new HashSet<int>();

        foreach(var t in triplets){
            if(t[0] > target[0] || t[1] > target[1] || t[2] > target[2]){
                continue;
            }
            for (int i = 0; i < t.Length; i++){
                if(t[i] == target[i]){
                    good.Add(i);
                }
            }
        }
        return good.Count == 3;
    }
}
