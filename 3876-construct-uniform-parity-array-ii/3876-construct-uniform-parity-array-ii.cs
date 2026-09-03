public class Solution {
    public bool UniformArray(int[] nums1) {
       int temp = nums1.Min();
       if (temp % 2 == 0) {
            for (int i = 0 ;i<nums1.Length; i++) {
                if (nums1[i] % 2 == 0) {
                    continue;
                } else {
                    return false;
                }
            }
            return true;
       }
       else {
            return true;
        }
    }    
}