public class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int end = nums.Length;
       for(int i = 0;i<end;i++) {
     
        if(nums.Take(i+1).Max() - nums.Skip(i).Min() <= k)
            return i;
        }
        return -1;
    }
}