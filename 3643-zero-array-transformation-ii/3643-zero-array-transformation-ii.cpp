#include <vector>
using namespace std;

class Solution {
public:
    int minZeroArray(vector<int>& nums, vector<vector<int>>& queries) {
        int n = nums.size();
        int q = queries.size();
        int left = 0, right = q;
        int ans = -1;
        
        while (left <= right) {
            int mid = left + (right - left) / 2;
        
            vector<long long> diff(n , 0);
            for (int i = 0; i < mid; i++) {
                int l = queries[i][0], r = queries[i][1], val = queries[i][2];
                diff[l] += val;
                if (r + 1 < n) {
                    diff[r + 1] =diff[r + 1] - val;
                }
            }
            
            bool allZero = true;
            long long curr = 0;
            for (int i = 0; i < n; i++) {
                curr += diff[i];
                if (curr < nums[i]) {
                    allZero = false;
                    break;
                }
            }
            
            if (allZero == true) {
                ans = mid;     
                right = mid - 1;
            } else {
                left = mid + 1; 
            }
        }
        return ans;
    }
};
