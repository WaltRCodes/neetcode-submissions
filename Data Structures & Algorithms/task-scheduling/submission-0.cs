public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        foreach (char task in tasks) {
            count[task - 'A']++;
        }

        int maxf = count.Max();
        int maxCount = 0;
        foreach (int i in count) {
            if (i == maxf) {
                maxCount++;
            }
        }

        int time = (maxf - 1) * (n + 1) + maxCount;
        return Math.Max(tasks.Length, time);
    }
}
