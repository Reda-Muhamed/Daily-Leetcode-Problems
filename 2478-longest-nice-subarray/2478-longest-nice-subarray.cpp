#include <vector>
#include <algorithm>

class Solution {
public:
    int longestNiceSubarray(std::vector<int>& nums) {
        int current_and = 0;
        int left = 0;
        int max_length = 0;
        int n = nums.size();

        for (int right = 0; right < n; ++right) {
            while ((current_and & nums[right]) != 0) {
                current_and ^= nums[left];
                ++left;
            }
            current_and |= nums[right];
            max_length = std::max(max_length, right - left + 1);
        }

        return max_length;
    }
};
