public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        Array.Sort(nums);
        int len = nums.Length;
        int minsum = 1000000000;
        for(int i = 0;i<=len-k;i++){
            
            minsum= Math.Min(nums[k+i-1]-nums[i],minsum);
        }
        return minsum;
    }
}
// 1 4 7 9
