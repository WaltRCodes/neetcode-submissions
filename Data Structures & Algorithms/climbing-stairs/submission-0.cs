public class Solution {
    public int ClimbStairs(int n) {     
        double sqrt5 = Math.Sqrt(5);
        double phi = (1 + sqrt5) / 2;
        double psi = (1 - sqrt5) / 2;
        n++;
        return (int) Math.Round((Math.Pow(phi, n) - Math.Pow(psi, n)) / sqrt5);
    }
}
