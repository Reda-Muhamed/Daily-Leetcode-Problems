class Solution {
public:
    int areaOfMaxDiagonal(vector<vector<int>>& dimensions) {
        int maxDiagSq = 0; 
        int maxArea = 0;

        for (auto &d : dimensions) {
            int w = d[0], h = d[1];
            int diagSq = w * w + h * h;
            int area = w * h;

            if (diagSq > maxDiagSq || (diagSq == maxDiagSq && area > maxArea)) {
                maxDiagSq = diagSq;
                maxArea = area;
            }
        }

        return maxArea;
    }
};
