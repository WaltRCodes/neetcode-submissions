public class Solution {
    public int ClimbStairs(int n) {     

        // sqrt(5) is used in Binet’s Formula for Fibonacci numbers.
        double sqrt5 = Math.Sqrt(5);

        // φ (phi) = golden ratio ≈ 1.618...
        double phi = (1 + sqrt5) / 2;

        // ψ (psi) = conjugate of the golden ratio ≈ -0.618...
        double psi = (1 - sqrt5) / 2;

        // The number of ways to climb n stairs is the (n+1)-th Fibonacci number.
        n++;

        // Binet’s Formula:
        //     F(n) = (φ^n – ψ^n) / sqrt(5)
        // Math.Round is used to correct floating‑point precision errors.
        return (int)Math.Round((Math.Pow(phi, n) - Math.Pow(psi, n)) / sqrt5);
    }
}
