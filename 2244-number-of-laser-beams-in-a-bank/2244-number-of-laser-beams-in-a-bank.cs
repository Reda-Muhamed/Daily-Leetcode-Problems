public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        List<int> ones = new List<int>();

        foreach (var b in bank)
        {
            int count = b.Count(ch => ch == '1');
            if (count > 0)
                ones.Add(count);
        }

        if (ones.Count <= 1)
            return 0;

        int res = 0;
        for (int i = 1; i < ones.Count; i++)
        {
            res += ones[i] * ones[i - 1];
        }

        return res;
    }
}
