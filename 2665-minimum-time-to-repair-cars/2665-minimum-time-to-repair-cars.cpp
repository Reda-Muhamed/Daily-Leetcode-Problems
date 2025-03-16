#include <vector>
#include <algorithm>
#include <cmath>
#include <limits>

class Solution {
public:
    long long repairCars(std::vector<int>& ranks, int cars) {
        long long left = 1;
        long long right = static_cast<long long>(*min_element(ranks.begin(), ranks.end())) * cars * cars;
        
        while (left < right) {
            long long mid = left + (right - left) / 2;
            long long n0fCars = 0;
            
            for (int rank : ranks) {
                n0fCars += static_cast<long long>(sqrt(mid / rank));
            }
            
            if (n0fCars >= cars) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
};
