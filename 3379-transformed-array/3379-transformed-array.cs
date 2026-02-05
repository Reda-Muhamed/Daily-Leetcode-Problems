public class Solution {
    public int[] ConstructTransformedArray(int[] nums) {
        int len = nums.Count();
        // 0,1,2,3
        // 1+4
        int[] res= new int[len];
        for(int i = 0 ;i<len ;i++){
            if(nums[i]==0) res[i]=0;
            else if(nums[i]>0){
                int ind = (nums[i] + i)%len;
                res[i]=nums[ind];
            }else{
                int ind = ((i + nums[i]) % len + len) % len;
                res[i]=nums[ind];
            }
            
        }
        return res;
    }
}