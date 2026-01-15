using System;
public class Solution {
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        int mh= maxConsecutive(hBars) , mv=maxConsecutive(vBars);
        
        return Math.Min(mv,mh)*Math.Min(mv,mh);
    }
    private int maxConsecutive( int[] hBars)
    {
        if (hBars.Length == 0) return 1;

        Array.Sort(hBars);
         int temp =1,mh=1;
        //2,3,5
        for(int i = 1 ;i<hBars.Length;i++){  
            if(hBars[i]-hBars[i-1]==1){
                temp++;               
            }else {
            temp=1;
            }
            mh=Math.Max(mh,temp);
        }
        return ++mh;

    }       
}