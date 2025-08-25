class Solution {
public:
    string longestPalindrome(string s) {
        if (s.empty()) return "";
        int len = s.size();
        int start = 0;
        int end = 0;
        for(int i=0;i<len;i++){
            int len1 =checkLongestsub(s,i,i);
            int len2 =checkLongestsub(s,i,i+1);
            int maxLen = max(len1,len2);
            if(maxLen>(end - start)){
                start = i - (maxLen - 1)/2;
                end = i+maxLen/2;

            }

        }
        return s.substr(start,end - start + 1);    
    }
    int checkLongestsub(string s ,int b,int e){
        int len = s.size(); 
        while(b>=0 && e<len && s[b]==s[e]){
            b--;
            e++;
        }
        return e-b-1;
    }
};