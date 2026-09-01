public class Solution {

    // Function to calculate the minimum intervals to finish all tasks
    public int LeastInterval(char[] tasks, int n) {

        // Count the frequency of each task (A-Z)
        int[] count = new int[26];
        foreach (char task in tasks) {
            count[task - 'A']++;
        }

        // Find the maximum frequency among tasks
        int maxf = count.Max();

        // Count how many tasks have the maximum frequency
        int maxCount = 0;
        foreach (int i in count) {
            if (i == maxf) {
                maxCount++;
            }
        }

        // Calculate the minimum intervals using the formula:
        // (max frequency - 1) * (cooldown + 1) + number of tasks with max frequency
        int time = (maxf - 1) * (n + 1) + maxCount;

        // Return the larger of the total tasks or the calculated time
        // Ensures we account for cases where tasks fill all idle slots
        return Math.Max(tasks.Length, time);
    }
}
