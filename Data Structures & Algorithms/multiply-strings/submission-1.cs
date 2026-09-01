public class Solution {
    public string Multiply(string num1, string num2) {

        // If either number is "0", the product is "0"
        if (new string[] { num1, num2 }.Contains("0")) {
            return "0";
        }

        // Result array large enough to hold the maximum possible digits
        // (len1 + len2 is the upper bound for multiplication)
        int[] res = new int[num1.Length + num2.Length];

        // Reverse both strings so we can multiply from least significant digits
        num1 = new string(num1.Reverse().ToArray());
        num2 = new string(num2.Reverse().ToArray());

        // Multiply each digit of num1 by each digit of num2
        for (int i1 = 0; i1 < num1.Length; i1++) {
            for (int i2 = 0; i2 < num2.Length; i2++) {

                // Convert characters to digits and multiply
                int digit = (num1[i1] - '0') * (num2[i2] - '0');

                // Add the product to the correct position in the result array
                res[i1 + i2] += digit;

                // Carry over to the next position
                res[i1 + i2 + 1] += res[i1 + i2] / 10;

                // Keep only the last digit in the current position
                res[i1 + i2] %= 10;
            }
        }

        // Reverse back to normal order (most significant digit first)
        Array.Reverse(res);

        // Skip leading zeros
        int beg = 0;
        while (beg < res.Length && res[beg] == 0) {
            beg++;
        }

        // Convert digits to strings and join them
        string[] result = res.Skip(beg).Select(x => x.ToString()).ToArray();
        return string.Join("", result);
    }
}
