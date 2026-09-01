public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {

        // If total gas is less than total cost, completing the circuit is impossible.
        if (gas.Sum() < cost.Sum()) {
            return -1;
        }

        int total = 0; // Tracks running tank balance for the current candidate start
        int res = 0;   // Index of the candidate starting station

        // Scan through all stations
        for (int i = 0; i < gas.Length; i++) {

            // Add net gain/loss at station i
            total += (gas[i] - cost[i]);

            // If we run out of gas before reaching the next station,
            // the current start is invalid. Reset and try starting at i+1.
            if (total < 0) {
                total = 0;
                res = i + 1;
            }
        }

        // Because total gas ≥ total cost, the candidate start must be valid.
        return res;
    }
}
