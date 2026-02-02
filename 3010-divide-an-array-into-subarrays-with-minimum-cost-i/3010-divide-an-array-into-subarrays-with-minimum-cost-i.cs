public class Solution {
    public int MinimumCost(int[] nums) {
        int res = nums[0];
        int[] part = new int[nums.Length-1];
        Array.Copy(nums, 1, part, 0,nums.Length-1 );
        Array.Sort(part);
        return res+part[0]+part[1];
      

    }
}