public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] A = nums1;
        int[] B = nums2;
        int total = A.Length + B.Length;
        int half = (total + 1) / 2;

        if (B.Length < A.Length){
            int[] temp = A;
            A = B;
            B = temp;
        }

        int left = 0;
        int right = A.Length;

        while (left <= right){
            int i = (left + right) / 2;
            int j = half - i;

            int Aleft = i > 0 ? A[i - 1] : int.MinValue;
            int Aright = i < A.Length ? A[i] : int.MaxValue;
            int Bleft = j > 0 ? B[j - 1] : int.MinValue;
            int Bright = j < B.Length ? B[j] : int.MaxValue;

            if (Aleft <= Bright && Bleft <= Aright) {
                if (total % 2 != 0){
                    return Math.Max(Aleft,Bleft);
                }
                return (Math.Max(Aleft,Bleft) + Math.Min(Aright,Bright))/2.0;
            } else if (Aleft> Bright){
                right = i - 1;
            } else {
                left = i + 1;
            }
        }
        return -1;
    }
}
