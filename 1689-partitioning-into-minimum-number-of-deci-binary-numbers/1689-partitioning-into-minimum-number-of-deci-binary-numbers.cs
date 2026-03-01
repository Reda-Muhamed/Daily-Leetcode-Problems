public class Solution {
    public int MinPartitions(string n) {
        int res = 0;
        foreach(var num in n){
            
            res = Math.Max(res,num-'0');
        }
        return res;
    }
    
}