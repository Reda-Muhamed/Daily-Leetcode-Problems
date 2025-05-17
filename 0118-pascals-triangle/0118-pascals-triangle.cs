public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> res = new List<IList<int>>();

        for (int i = 0; i < numRows; i++)
        {
            List<int> row = new List<int>();
            row.Add(1); 

            for (int j = 1; j < i; j++)
            {
                int val = res[i - 1][j - 1] + res[i - 1][j];
                row.Add(val);
            }

            if (i > 0)
                row.Add(1); 

            res.Add(row);
        }

        return res;
    }
}
