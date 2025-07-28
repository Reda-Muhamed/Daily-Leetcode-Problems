class Solution {
public:
    int countHillValley(vector<int>& nums) {
        int res = 0;
        int n = nums.size();

        // Remove consecutive duplicates
        vector<int> filtered;
        filtered.push_back(nums[0]);
        for (int i = 1; i < n; ++i) {
            if (nums[i] != nums[i - 1]) {
                filtered.push_back(nums[i]);
            }
        }

            n = filtered.size();
        for (int i = 1; i < n - 1; ++i) {
            if ((filtered[i] > filtered[i - 1] && filtered[i] > filtered[i + 1]) ||
                (filtered[i] < filtered[i - 1] && filtered[i] < filtered[i + 1])) {
                res++;
            }
        }

        return res;
    }
};
