public class Solution {
    public int[] MinBitwiseArray(IList<int> nums) {
        List<int> res = new List<int>();
        int len = nums.Count;
        for(int i=0;i<len;i++ ){
            bool flag = false;
            for(int j = 1;j<nums[i];j++){
                int ff = j|j+1;
                if(ff==nums[i]){
                    res.Add(j);
                    flag=true;
                    break;
                }
            }
            if(flag==false){
                res.Add(-1);
            }
        }
        return res.ToArray();
    }
}