public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        foreach (string c in tokens){
            if (c == "+"){
                stack.Push(stack.Pop() + stack.Pop());
            } else if (c == "-"){
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push(b - a);
            } else if (c == "*"){
                stack.Push(stack.Pop() * stack.Pop());
            } else if (c == "/"){
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push((int) ((double) b/a));
            } else {
                stack.Push(int.Parse(c));
            }
        }
        return stack.Pop();
    }
}
