#include <vector>
#include <unordered_map>
#include <algorithm>

using namespace std;

class Solution {
public:
    long long maximumSubarraySum(vector<int>& nums, int k) {
        int n = nums.size();
        if (n < k) return 0; 

        unordered_map<int, int> freq; 
        long long maxSum = 0, currentSum = 0;

        int left = 0;
        for (int right = 0; right < n; ++right) {
            
            freq[nums[right]]++;
            currentSum += nums[right];

            // If duplicates exist or window size exceeds k, adjust the window
            while (freq[nums[right]] > 1 || (right - left + 1) > k) {
                freq[nums[left]]--;
                if (freq[nums[left]] == 0) {
                    freq.erase(nums[left]);
                }
                currentSum -= nums[left];
                left++;
            }

            if (right - left + 1 == k) {
                maxSum = max(maxSum, currentSum);
            }
        }

        return maxSum;
    }
};
