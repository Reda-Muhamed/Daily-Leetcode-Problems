public class Solution {
    public int MinimumCost(int[] nums) {
        var m1 = int.MaxValue;
        var m2 = int.MaxValue;
        for (var i = 1; i < nums.Length; i++)
        {    
            if (m1 >= nums[i])
            {
                m2 = m1;
                m1 = nums[i];
            }
            else if (m2 >= nums[i])
            {
                m2 = nums[i];
            }
        }

        return nums[0] + m1 + m2;

    }
}