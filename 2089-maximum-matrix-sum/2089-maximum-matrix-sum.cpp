#include<iostream>
using namespace std;
class Solution {
public:
    long long maxMatrixSum(vector<vector<int>>& matrix) {
        int maxN = -10000000;
        int minP =  10000000;
        int c = 0;
        int z=0;
        int len = matrix.size();
        long long res = 0;
        for(int i = 0;i<len;i++){
            for(int j = 0;j<len;j++){
                if(matrix[i][j]<0){
                    c++;
                    maxN = max(maxN,matrix[i][j]);
                    res+=(-1*matrix[i][j]);
                }else if(matrix[i][j]>0)
                {
                    res+=matrix[i][j];
                    minP = min(minP , matrix[i][j]);
                }
                else z++;
            }
        }

        if(c%2!=0 && z== 0)
             {
                if(minP > -1*maxN)
                     res+=2*maxN;
                else {
                    res-=2*minP;
                }
                }
    
        return res;
    }
};