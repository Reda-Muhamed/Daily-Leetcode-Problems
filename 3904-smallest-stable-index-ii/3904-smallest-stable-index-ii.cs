public class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int len = nums.Length;
        int[] prefMax = new int[len];
        prefMax[0] = nums[0];
        
        for (int i = 1; i < len ; i++) {
            if (nums[i] > prefMax[i-1]) {
                prefMax[i] = nums[i];
            } else {
                prefMax[i] = prefMax[i - 1];
            }
        }

        int[] suffixMin = new int[len];

        suffixMin[len - 1] = nums[len - 1];

        for (int i = len - 2; i >= 0; i--)
        {
            if (nums[i] < suffixMin[i + 1])
            {
                suffixMin[i] = nums[i];
            }
            else
            {
                suffixMin[i] = suffixMin[i + 1];
            }
        }
        for (int i = 0; i < len; i++) {
            if(prefMax[i] - suffixMin[i] <= k)
                return i;
        }
        return -1;
    }
    
}