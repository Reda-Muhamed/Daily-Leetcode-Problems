public class Solution
{
    public int MinimumDeletions(int[] nums)
    {
        int n = nums.Length;

        int minIndex = 0;
        int maxIndex = 0;

        for (int i = 1; i < n; i++)
        {
            if (nums[i] < nums[minIndex])
                minIndex = i;

            if (nums[i] > nums[maxIndex])
                maxIndex = i;
        }

        // Both from the front
        int removeBothFront =
            Math.Max(minIndex, maxIndex) + 1;

        // Both from the back
        int removeBothBack =
            n - Math.Min(minIndex, maxIndex);

        // Min from front, max from back
        int minFrontMaxBack =
            minIndex + 1 + (n - maxIndex);

        // Max from front, min from back
        int maxFrontMinBack =
            maxIndex + 1 + (n - minIndex);

        return Math.Min(
            Math.Min(removeBothFront, removeBothBack),
            Math.Min(minFrontMaxBack, maxFrontMinBack)
        );
    }
}