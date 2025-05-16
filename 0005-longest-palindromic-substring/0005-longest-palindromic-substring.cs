public class Solution
{
    public string LongestPalindrome(string s)
    {
        int n = s.Length;
        if (n == 0) return "";
        bool[,] dp = new bool[n, n];
        int maxLength = 1;
        int start = 0;

        for (int i = 0; i < n; i++)
            dp[i, i] = true;

        for (int i = 0; i < n - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                dp[i, i + 1] = true;
                start = i;
                maxLength = 2;
            }
        }

        for (int len = 3; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    dp[i, j] = true;
                    if (len > maxLength)
                    {
                        start = i;
                        maxLength = len;
                    }
                }
            }
        }

        return s.Substring(start, maxLength);
    }
}
