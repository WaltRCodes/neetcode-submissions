public class Solution {
    public List<List<int>> Subsets(int[] nums) {

        // Result list starts with one subset: the empty set
        List<List<int>> res = new List<List<int>>();
        res.Add(new List<int>());

        // For each number in the input array
        foreach (int num in nums) {

            // Capture the current number of subsets
            // (We only want to extend the subsets that existed before adding this number)
            int size = res.Count;

            // For each existing subset, create a new subset that includes the current number
            for (int i = 0; i < size; i++) {

                // Copy the existing subset
                List<int> subset = new List<int>(res[i]);

                // Add the current number to it
                subset.Add(num);

                // Add the new subset to the result list
                res.Add(subset);
            }
        }

        // Return the full power set
        return res;
    }
}
