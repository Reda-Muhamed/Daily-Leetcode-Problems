public class Solution {
    public int BinaryGap(int n) {
        var s = new StringBuilder();
        while(n>0){
            // 1-> odd
            if((n&1)==1){
                s.Append('1');
            }else{
                s.Append('0');
            }
            n/=2;
        }
        int maxgap = -1;
        int len = s.Length;
        var h = new List<int>();
        for(int i = 0;i<len;i++){
           if(s[i]=='1' && h.Count == 0){
            h.Add(s[i]);
           }else if (s[i]=='0' && h.Count == 0)
                continue;
           else if(s[i]=='0' && h.Count != 0)
                h.Add(s[i]);
            else if(s[i]=='1' && h.Count>0){
                maxgap = Math.Max(maxgap,h.Count);
                h.Clear();
                h.Add(s[i]);
            }
        }
        return maxgap !=-1 ? maxgap:0 ;
    }
}