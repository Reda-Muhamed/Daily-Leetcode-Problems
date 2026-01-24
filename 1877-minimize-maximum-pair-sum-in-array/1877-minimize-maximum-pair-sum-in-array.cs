public class Solution {
    public int MinPairSum(int[] nums) {
        Array.Sort(nums);
        int len  = nums.Length;
        int mid = len/2;
        int max = 0;
        for(int i = 0;i<mid;i++){
            max = Math.Max(max, nums[i]+nums[--len]);
        }
        return max;
    }
}
// 2,3,4,4,5,6
// 2+6,5+3,4+4
//5
// 1 ,1, 1 , 2, 4 , 4, 5, 5, 5, 5