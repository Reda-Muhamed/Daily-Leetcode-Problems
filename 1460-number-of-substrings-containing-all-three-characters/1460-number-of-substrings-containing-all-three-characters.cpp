
class Solution {
public:
    int numberOfSubstrings(std::string s) {
        int ans = 0;
        vector<int> count(3, 0); // To store counts of 'a', 'b', 'c'
        int left = 0;

        for (int right = 0; right < s.length(); ++right) {
            ++count[s[right] - 'a'];

            // Check if the current window contains at least one 'a', 'b', and 'c'
            while (count[0] > 0 && count[1] > 0 && count[2] > 0) {
                --count[s[left] - 'a'];
                ++left;
            }

            // All substrings starting from any index before 'left' up to 'right' are valid
            ans += left;
        }

        return ans;
    }
};
