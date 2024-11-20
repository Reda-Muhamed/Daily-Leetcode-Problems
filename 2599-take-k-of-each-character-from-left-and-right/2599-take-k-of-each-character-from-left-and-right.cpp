// #include <vector>
// #include <string>
// #include <map>
// #include <algorithm>

// class Solution {
// public:
//     int takeCharacters(std::string s, int k) {
//         std::map<char, int> mpr, mpl;
//         int a = 0, b = 0, c = 0;
//         int len = s.length();
//         if(!k)return 0;
//         for (char ch : s) {
//             if (ch == 'a') a++;
//             else if (ch == 'b') b++;
//             else c++;
//         }
//         if (a < k || b < k || c < k) return -1;

//         int right = 0, left = 0, minPath = len;

//         for (int i = 0, j = len - 1; i < len || j >= 0; ++i, --j) {
//             if (i < len) mpr[s[i]]++;  // Move from left
//             if (j >= 0) mpl[s[j]]++;  // Move from right

//             // Check conditions for right boundary
//             if (mpr['a'] >= k && mpr['b'] >= k && mpr['c'] >= k) {
//                 right = i + 1;
//                 minPath = std::min(minPath, right);
//                 break;
//             }

//             // Check conditions for left boundary
//             if (mpl['a'] >= k && mpl['b'] >= k && mpl['c'] >= k) {
//                 left = len - j;
//                 minPath = std::min(minPath, left);
//                 break;
//             }
//         }

//         mpr['a']=0,mpr['b']=0,mpr['c']=0,mpl['a']=0,mpl['b']=0,mpl['c']=0;
//         left = 0 ,right =0;
//         for(int i =0;i<len;i++){
//             mpl[s[i]]++;
//             left++;
//             for(int j = len-1;j>=0;j--){
//                 mpr[s[j]]++;
//                 right++;
//                 if(mpr['a'] + mpl['a']  >= k && mpr['b']+mpl['b'] >= k && mpr['c']+mpl['c'] >= k){
//                     minPath = std::min(minPath, left+right);
//                     right =0 ;
//                      mpr['a']=0,mpr['b']=0,mpr['c']=0;
//                      break;
//                 }
//             }

//         }

//         return minPath;
//     }
// };






#include <string>
#include <map>
#include <algorithm>

class Solution {
public:
    int takeCharacters(std::string s, int k) {
        int len = s.length();

        // Total count of 'a', 'b', and 'c'
        std::map<char, int> totalCount;
        for (char ch : s) {
            totalCount[ch]++;
        }

        // If any character occurs less than `k`, return -1
        if (totalCount['a'] < k || totalCount['b'] < k || totalCount['c'] < k) {
            return -1;
        }

        // Find the maximum length of a valid substring
        int left = 0, maxValidLength = 0;
        std::map<char, int> windowCount;

        for (int right = 0; right < len; ++right) {
            windowCount[s[right]]++;

            // Shrink the window if it becomes invalid
            while (windowCount['a'] > totalCount['a'] - k ||
                   windowCount['b'] > totalCount['b'] - k ||
                   windowCount['c'] > totalCount['c'] - k) {
                windowCount[s[left]]--;
                left++;
            }

            // Update the maximum valid length
            maxValidLength = std::max(maxValidLength, right - left + 1);
        }

        // Minimum characters to remove = total length - maximum valid length
        return len - maxValidLength;
    }
};
