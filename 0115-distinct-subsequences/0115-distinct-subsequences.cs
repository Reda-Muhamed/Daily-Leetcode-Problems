public class Solution
{
    public int NumDistinct(string s, string t)
    {
        int[,] dp = new int[s.Length + 1, t.Length + 1];

        for (int i = 0; i <= s.Length; i++)
        {
            dp[i, t.Length] = 1;
        }

        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int j = t.Length - 1; j >= 0; j--)
            {
                if (s[i] == t[j])
                {
                    dp[i, j] = dp[i + 1, j + 1] + dp[i + 1, j];
                }
                else
                {
                    dp[i, j] = dp[i + 1, j];
                }
            }
        }

        return dp[0, 0];
    }
}