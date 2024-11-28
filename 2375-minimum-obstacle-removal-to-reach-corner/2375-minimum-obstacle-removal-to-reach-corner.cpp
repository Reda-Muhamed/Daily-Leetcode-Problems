class Solution {
public:
    int minimumObstacles(vector<vector<int>>& grid) {
            int m = grid.size(), n = grid[0].size();
    // Directions: right, down, left, up
    vector<pair<int, int>> directions = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};

    // Distance array initialized to infinity
    vector<vector<int>> dist(m, vector<int>(n, INT_MAX));
    dist[0][0] = 0;

    // Deque for 0-1 BFS
    deque<pair<int, int>> dq;
    dq.push_front({0, 0});

    while (!dq.empty()) {
        auto [x, y] = dq.front();
        dq.pop_front();

        for (auto [dx, dy] : directions) {
            int nx = x + dx, ny = y + dy;

            // Check bounds
            if (nx >= 0 && nx < m && ny >= 0 && ny < n) {
                int newDist = dist[x][y] + grid[nx][ny];
                if (newDist < dist[nx][ny]) {
                    dist[nx][ny] = newDist;
                    if (grid[nx][ny] == 1) {
                        dq.push_back({nx, ny});
                    } else {
                        dq.push_front({nx, ny});
                    }
                }
            }
        }
    }
    return dist[m - 1][n - 1];
    }
};