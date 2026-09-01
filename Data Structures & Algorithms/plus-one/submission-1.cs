public class Solution {
    public int[] PlusOne(int[] digits) {

        int n = digits.Length;

        // Traverse the digits from right to left (least significant → most significant)
        for (int i = n - 1; i >= 0; i--) {

            // If the current digit is less than 9, we can simply increment it.
            // No carry is produced, so we return immediately.
            if (digits[i] < 9) {
                digits[i]++;
                return digits;
            }

            // If the digit is 9, it becomes 0 and we continue the loop
            // to propagate the carry to the next digit.
            digits[i] = 0;
        }

        // If we reach this point, all digits were 9.
        // Example: 999 → 000, but we need 1000.
        // Create a new array with an extra leading 1.
        int[] result = new int[n + 1];
        result[0] = 1;

        return result;
    }
}
