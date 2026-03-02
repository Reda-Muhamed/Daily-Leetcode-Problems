public class Solution {
    public int MinSwaps(int[][] grid) {
   
        return greedy(grid,0);

    }
   private int greedy(int[][] grid, int start)
    {
        int n = grid.Length;
        var lastOne = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int pos = -1;
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                    pos = j;
            }
            lastOne.Add(pos);
        }

        int swaps = 0;

        for (int i = 0; i < n; i++)
        {
            int j = i;
            while (j < n && lastOne[j] > i)
                j++;

            if (j == n)
                return -1;

            while (j > i)
            {
                int temp = lastOne[j];
                lastOne[j] = lastOne[j - 1];
                lastOne[j - 1] = temp;

                swaps++;
                j--;
            }
        }

        return swaps;
    }
}