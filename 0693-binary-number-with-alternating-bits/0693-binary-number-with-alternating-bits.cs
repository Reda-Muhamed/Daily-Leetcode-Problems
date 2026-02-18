public class Solution {
    public bool HasAlternatingBits(int n) {
        var s = new StringBuilder();
        int len = -1;
        while(n>0){
            // 1-> odd
            if((n&1)==1){
                s.Append('1');
            }else{
                s.Append('0');
            }
            len++;
            
            if(len>0){
              if(s[len]==s[len-1])
                return false;
            }
            n/=2;
        }
        return true;

    }

}
// 8
// 1 0 0 0