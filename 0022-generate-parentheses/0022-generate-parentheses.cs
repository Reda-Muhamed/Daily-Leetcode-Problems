public class Solution {
    public IList<string> GenerateParenthesis(int n) {
           List<string> res = new List<string>();
        Backtrack(res, "", 0, 0, n);
        return res;
    }

    private void Backtrack(List<string> res, string current, int open, int close, int max)
    {
        if (current.Length == max * 2)
        {
            res.Add(current);
            return;
        }

        if (open < max)
        {
            Backtrack(res, current + "(", open + 1, close, max);
        }

        if (close < open)
        {
            Backtrack(res, current + ")", open, close + 1, max);
        }
    }
    
}