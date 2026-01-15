using System;
public class Solution {
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        int mh=0 , mv=0;
        Array.Sort(hBars);
        Array.Sort(vBars);

        int temp =1;
        if(hBars.Length==1){
            mh=2;
        }
                // 2,4,8,22,23,26
        for(int i = 1 ;i<hBars.Length;i++){  
            if(hBars[i]-hBars[i-1]==1){
                temp++;
                if(i==hBars.Length - 1|| hBars[i+1]-hBars[i]!=1)
                    temp++;
                mh = Math.Max(temp,mh);
                
            }else {
                temp=1;
                if(i==hBars.Length - 1|| hBars[i+1]-hBars[i]!=1 )
                    temp++;
                mh = Math.Max(temp,mh);
                
            }
        }
        if(vBars.Length==1){
            mv=2;
        }
        temp=1;
        //6,33,34,36
        for(int i = 1 ;i<vBars.Length;i++){  
            if(vBars[i]-vBars[i-1]==1){
                temp++;
                if(i==vBars.Length - 1 || vBars[i+1]-vBars[i]!=1 )
                    temp++;
                mv = Math.Max(temp,mv);
                
            }else {
                temp=1;
                if(i==vBars.Length - 1|| vBars[i+1]-vBars[i]!=1)
                    temp++;
                mv = Math.Max(temp,mv);
            }
        }
        return Math.Min(mv,mh)*Math.Min(mv,mh);
        
    }
}