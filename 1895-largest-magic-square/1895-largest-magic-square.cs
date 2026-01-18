public class Solution {
    public int LargestMagicSquare(int[][] grid) {
       int rows = grid.Length;
        int cols = grid[0].Length;

        int itr = Math.Min(rows,cols);
        for(int k = itr;k>=2;k--){
           for (int i = 0; i <= rows - k; i++) {
                for (int j = 0; j <= cols - k; j++) {
                    if (IsMagic( grid, i, j, k)) {
                        return k;
                    }
                }
           }
        }
     return 1;
    }
   public bool IsMagic(int[][] grid, int row, int col, int k)
    {
        int target = 0;
        for (int j = col; j < col + k; j++)
            target += grid[row][j];

        int diag1 = 0, diag2 = 0;

        for (int i = 0; i < k; i++)
        {
            int rowSum = 0;
            int colSum = 0;

            for (int j = 0; j < k; j++)
            {
                rowSum += grid[row + i][col + j]; 
                colSum += grid[row + j][col + i]; 
            }

            if (rowSum != target || colSum != target)
                return false;

            diag1 += grid[row + i][col + i];
            diag2 += grid[row + i][col + k - 1 - i];
        }

        if (diag1 != target || diag2 != target)
            return false;

        return true;
    }

}