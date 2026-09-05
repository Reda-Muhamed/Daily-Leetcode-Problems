public class Solution
{
    public int FirstStableIndex(int[] nums, int k)
    {
        int len = nums.Length;

        int[] suffixMin = new int[len];
        suffixMin[len - 1] = nums[len - 1];

        for (int i = len - 2; i >= 0; i--)
        {
            suffixMin[i] = Math.Min(nums[i], suffixMin[i + 1]);
        }

        int prefMax = nums[0];

        for (int i = 0; i < len; i++)
        {
            prefMax = Math.Max(prefMax, nums[i]);

            if (prefMax - suffixMin[i] <= k)
                return i;
        }

        return -1;
    }
}