public class Solution {  
    // Generates all combinations of n pairs of valid parentheses
public List<string> GenerateParenthesis(int n) {
    List<string> res = new List<string>();  // Result list to store valid parentheses strings
    string stack = "";                      // Temporary string to build current combination
    Backtrack(0, 0, n, res, stack);        // Start backtracking with 0 open and 0 closed parentheses
    return res;
}

// Recursive helper method to build valid parentheses combinations
// openN: number of '(' used so far
// closedN: number of ')' used so far
// n: total pairs of parentheses to generate
// res: list storing valid combinations
// stack: current combination being built
public void Backtrack(int openN, int closedN, int n, List<string> res, string stack) {
    // Base case: when the number of open and closed parentheses both equal n,
    // a valid combination is formed and added to result
    if (openN == closedN && openN == n) {
        res.Add(stack);
        return;
    }

    // If we can still add an opening parenthesis '(' (openN < n),
    // recurse with one more '(' added
    if (openN < n) {
        Backtrack(openN + 1, closedN, n, res, stack + '(');
    }

    // If we can add a closing parenthesis ')' without violating validity
    // (closedN < openN), recurse with one more ')' added
    if (closedN < openN) {
        Backtrack(openN, closedN + 1, n, res, stack + ')');
    }
}
}
