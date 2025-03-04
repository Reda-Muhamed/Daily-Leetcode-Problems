class Solution {
public:

    double logBase3(double x) {
        return log(x) / log(3);  
    }
    bool checkPowersOfThree(int n) {
        int num0fIndex = logBase3(n);
        for(int i = num0fIndex ; i>=0;i--){
            if(pow(3,i)<=n && n>0){
                n-=pow(3,i);
            }
        }
        if(n>0){
            return false;
        }
        return true;
    }
};