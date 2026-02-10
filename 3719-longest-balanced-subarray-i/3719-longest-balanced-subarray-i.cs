
public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int n = nums.Length;
        int maxLen = 0;

        for (int l = 0; l < n; l++)
        {
            HashSet<int> evens = new HashSet<int>();
            HashSet<int> odds = new HashSet<int>();

            for (int r = l; r < n;r++)
            {
                if (nums[r] % 2 == 0)
                {
                    evens.Add(nums[r]);
                }
                else
                {
                    odds.Add(nums[r]);
                }

                if (evens.Count == odds.Count)
                {
                    maxLen = Math.Max(maxLen, r - l + 1);
                }
            }
        }

        return maxLen;
    }
}