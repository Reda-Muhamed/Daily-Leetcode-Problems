#include <vector>
class Solution {
public:
    int countUnguarded(int m, int n, vector<vector<int>>& guards, vector<vector<int>>& walls) {
        vector<vector<int>> grid(m, vector<int>(n, 0));

        // Mark the guards with 1
        for (const auto& guard : guards) {
            int x = guard[0], y = guard[1];
            grid[x][y] = 1;
        }
        // Mark the walls with -1
        for (const auto& wall : walls) {
            int x = wall[0], y = wall[1];
            grid[x][y] = -1;
        }
        int res = 0;
         for (const auto& guard : guards) {
            int x = guard[0], y = guard[1];
            for(int j = y-1;j>=0;j--){
                if(grid[x][j]==1 || grid[x][j]==-1)break;
                if(grid[x][j]==2)
                    continue;
                
                 res++;
                grid[x][j]=2;
            }
             for(int j = y+1;j<n;j++){
                if(grid[x][j]==1 || grid[x][j]==-1)break;
                   if(grid[x][j]==2)
                    continue;
                   res++;
                grid[x][j]=2;
            }
              for(int j = x-1;j>=0;j--){
                if(grid[j][y]==1 || grid[j][y]==-1)break;
                   if(grid[j][y]==2)
                    continue;
                 res++;
                grid[j][y]=2;
            }
             for(int j = x+1;j<m;j++){
                if(grid[j][y]==1 || grid[j][y]==-1)break;
                  if(grid[j][y]==2)
                    continue;
                res++;
                grid[j][y]=2;
            }
         }
         
    return (n*m) - res - guards.size() - walls.size();
    }
};