public class Solution {
    public int[] RunningSum(int[] nums) {
        int len =nums.Length;
        int[] res = new int[len];
        res[0]=nums[0];
        for(int i=1;i<len;i++){
            res[i]=nums[i]+res[i-1];
        }
        return res;
    }
}