public class Solution {
    public string Multiply(string num1, string num2) {

        // If either number is zero, result is zero
        if (num1 == "0" || num2 == "0")
            return "0";

        int len1 = num1.Length;
        int len2 = num2.Length;

        // Maximum possible length of product is len1 + len2
        int[] result = new int[len1 + len2];

        // Multiply from right to left (like manual multiplication)
        for (int i = len1 - 1; i >= 0; i--) {
            for (int j = len2 - 1; j >= 0; j--) {

                int digit1 = num1[i] - '0';
                int digit2 = num2[j] - '0';

                int product = digit1 * digit2;

                // Position in result array
                int posLow = i + j + 1;   // Ones place
                int posHigh = i + j;      // Tens place (carry)

                // Add to existing value at posLow
                int sum = product + result[posLow];

                result[posLow] = sum % 10;        // Store single digit
                result[posHigh] += sum / 10;      // Carry to next position
            }
        }

        // Convert result array to string (skip leading zeros)
        int start = 0;
        while (start < result.Length && result[start] == 0)
            start++;

        var sb = new System.Text.StringBuilder();
        for (int i = start; i < result.Length; i++)
            sb.Append(result[i]);

        return sb.ToString();
    }
}