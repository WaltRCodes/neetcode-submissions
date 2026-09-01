public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {

        // If the total number of cards is not divisible by groupSize,
        // it's impossible to form complete groups.
        if (hand.Length % groupSize != 0) return false;

        // Count how many times each card value appears.
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in hand) {
            if (!count.ContainsKey(num)) count[num] = 0;
            count[num]++;
        }

        // For each card in the hand, try to form valid groups starting from it.
        foreach (int num in hand) {

            // Try to find the earliest possible start of a straight.
            int start = num;
            while (count.ContainsKey(start - 1) && count[start - 1] > 0) {
                start--;
            }

            // From this starting point, attempt to build groups.
            while (start <= num) {

                // While there are still cards of value 'start' available,
                // try to form a full group [start, start+1, ..., start+groupSize-1].
                while (count.ContainsKey(start) && count[start] > 0) {

                    // Check each card needed for the group.
                    for (int i = start; i < start + groupSize; i++) {

                        // If any required card is missing or exhausted,
                        // we cannot form a valid straight.
                        if (!count.ContainsKey(i) || count[i] == 0) {
                            return false;
                        }

                        // Use one copy of card i.
                        count[i]--;
                    }
                }

                // Move to the next possible starting point.
                start++;
            }
        }

        // If all groups were successfully formed, return true.
        return true;
    }
}
