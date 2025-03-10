class Solution {
public:
    long long coloredCells(long long n) {
        return (long long) 2 * n * n - 2 * n + 1;
    }
};