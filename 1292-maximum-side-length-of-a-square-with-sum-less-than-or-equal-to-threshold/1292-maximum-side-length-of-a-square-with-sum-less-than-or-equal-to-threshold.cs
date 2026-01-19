public class Solution {
    public int MaxSideLength(int[][] mat, int threshold)
    {
        int rows = mat.Length;
        int cols = mat[0].Length;
        int left = 0;
        int right = Math.Min(rows, cols);
        int ans = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (IsValid(mid, mat, threshold))
            {
                ans = mid;        
                left = mid + 1; 
            }
            else
            {
                right = mid - 1; 
            }
        }

        return ans;
    }

    private bool IsValid(int k, int[][] mat, int threshold)
    {
        int rows = mat.Length;
        int cols = mat[0].Length;

        for (int i = 0; i + k <= rows; i++) {
            for (int j = 0; j + k <= cols; j++) {
                if (IsLessOrEqual(i, j, k, mat, threshold)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool IsLessOrEqual(int row, int col, int k, int[][] mat, int threshold) {
        int sum = 0;
        for (int i = 0; i < k; i++) {
            for (int j = 0; j < k; j++) {
                sum += mat[row + i][col + j];
                if (sum > threshold)
                    return false;
            }
        }
        return true;
    }
}
