public class Solution {
    int count =0;
    public int ClimbStairs(int n) {
        if(n<=2)return n;
        int[] aa= new int[n+1];
        aa[0]=0;
        aa[1]=1;

        aa[2]=2;
        for(int i = 3 ;i<= n ;i++){
            aa[i]= aa[i-1] + aa[i-2];
        }
        return aa[n];
    }
    
       

}