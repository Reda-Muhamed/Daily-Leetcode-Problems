public class Solution {
    public bool UniformArray(int[] nums1) {
       int temp = nums1.Min();
       if ((temp & 1) == 0) {
            for (int i = 0 ;i<nums1.Length; i++) {
                if ((nums1[i] & 1) == 1) 
                    return false;
            }
            return true;
       }
        return true;
    }    
}