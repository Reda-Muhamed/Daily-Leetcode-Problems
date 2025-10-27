public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        int prev = 0, total = 0;

        foreach (var row in bank)
        {
            int curr = row.Count(ch => ch == '1');
            if (curr > 0)
            {
                total += prev * curr;
                prev = curr;
            }
        }

        return total;
    }
}
