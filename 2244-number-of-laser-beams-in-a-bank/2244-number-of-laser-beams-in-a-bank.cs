public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        int prev = 0;
        int total = 0;

        foreach (var row in bank)
        {
            int curr = 0;
            foreach (char ch in row)
                if (ch == '1') curr++;

            if (curr > 0)
            {
                total += prev * curr;
                prev = curr;
            }
        }

        return total;
    }
}
