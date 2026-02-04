public class Solution {
    public bool IsTrionic(int[] nums) {
        int len = nums.Count();
        int ind1 = 0;
        int ind2 = 0;
        for (int i=0; i<len-1 ;i++){
            if(nums[i]>=nums[i+1]){
                ind1 = i;
                break;
            }
        }
        for (int i=ind1; i<len-1 ;i++){
            if(nums[i]<=nums[i+1]){
                ind2 = i;
                break;
            }
        }
        int l ;
        for (l=ind2; l<len-1 ;l++){
            if(nums[l]>=nums[l+1]){
               return false;
            }
        }
        if(ind1!=0 &&ind2!=0)
        return true;
        return  false;
        
        
    }
}