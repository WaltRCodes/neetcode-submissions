public class Solution {
    public bool CheckValidString(string s) {

        // leftMin = minimum possible number of unmatched '(' so far
        // leftMax = maximum possible number of unmatched '(' so far
        //
        // '*' can act as '(' or ')' or be ignored, so we track a RANGE.
        int leftMin = 0, leftMax = 0;

        foreach (char c in s) {

            if (c == '(') {
                // '(' increases both minimum and maximum possible opens
                leftMin++;
                leftMax++;
            }
            else if (c == ')') {
                // ')' decreases both — it closes an open parenthesis
                leftMin--;
                leftMax--;
            }
            else {
                // '*' can be:
                //   '(' → increases leftMax
                //   ')' → decreases leftMin
                //   ''  → ignored
                leftMin--;   // treat '*' as ')'
                leftMax++;   // treat '*' as '('
            }

            // If leftMax < 0, even the most optimistic interpretation
            // has more ')' than '(' — impossible to be valid.
            if (leftMax < 0) {
                return false;
            }

            // leftMin should never drop below 0.
            // If it does, clamp it — this means '*' acted as '(' or empty.
            if (leftMin < 0) {
                leftMin = 0;
            }
        }

        // If leftMin == 0, we can balance all opens.
        return leftMin == 0;
    }
}
