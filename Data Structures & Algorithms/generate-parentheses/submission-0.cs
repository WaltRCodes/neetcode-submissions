public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        List<string> res = new List<string>();
        string stack = "";
        Backtrack(0,0,n,res,stack);
        return res;
    }
    public void Backtrack(int openN, int closedN, int n, List<string> res, string stack){
        if(openN == closedN && openN == n){
            res.Add(stack);
            return;
        }
        if (openN < n){
            Backtrack(openN+1,closedN,n,res,stack+'(');
        }
        if (closedN<openN){
            Backtrack(openN,closedN+1,n,res,stack+')');
        }
    }
}
