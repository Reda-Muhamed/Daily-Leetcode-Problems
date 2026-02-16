public class Solution {
    public int ReverseBits(int n) {
        string bin = "";
        while(n>0){
            bin+=(n%2);
            n/=2;
            // 0 0 0 1 0 0 0 0
        }
        while(bin.Length<32){
            bin = bin + '0';
        }
        int res = 0;
        int u = 0;
        for(int i = 31;i>=0;i--){
            int t = bin[i]=='0'?0:1;
            res += (int)Math.Pow(2,u++)*t;
        }
        return res;
        
    }
}
// 8  4  2  1
// 0  0  0  1 0 0 0 0 0 0 0
// 0  0  0  1 0 0 0