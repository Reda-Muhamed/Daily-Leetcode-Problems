using System;
using System.Collections.Generic;

public class Solution
{
    public int IntersectionSizeTwo(int[][] intervals)
    {
        Array.Sort(intervals, (x, y) =>
        { 
            if (x[1] != y[1])
                return x[1].CompareTo(y[1]);        
            return y[0].CompareTo(x[0]);            
        });
        /*
            [1,3],[2,4] 
            or
            [2,3],[1,3]
        
        */

        int a = -1;  
        int b = -1;  
        int answer = 0;

        foreach (var interval in intervals)
        {
            int start = interval[0];
            int end   = interval[1];

            // [1,4],[5,8]
            if (start > b)
            {
                answer += 2;
                a = end - 1;
                b = end;
            }
            // start > a but start <= b
             // [1,6],[6,8]
            else if (start > a)
            {
                // we already have b inside, need one more point
                answer += 1;
                a = b;
                b = end;
            }
            // if the both nums inside the interval do nothing
        }

        return answer;
    }
}
