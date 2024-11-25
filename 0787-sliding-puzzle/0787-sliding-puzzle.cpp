class Solution {
public:
    int slidingPuzzle(vector<vector<int>>& board) {
         string target = "123450";  // The solved state as a string
        string start;
        
        // Convert the board to a string representation
        for (auto& row : board) {
            for (int num : row) {
                start += to_string(num);
            }
        }
        
        // All possible swaps for 0's position (indexed from 0 to 5)
        vector<vector<int>> neighbors = {
            {1, 3},       // 0 can move to positions 1 and 3  => 0 1 2
                                                            //   3 4 5

            {0, 2, 4},    // 1 can move to positions 0, 2, 4 =>  1 0 2
                                                            //   3 4 5

            {1, 5},       
            {0, 4},       
            {1, 3, 5},    
            {2, 4}        
        };
        
        // BFS setup
        queue<pair<string, int>> q;  // {current state, steps}
        unordered_set<string> visited;
        q.push({start, 0});
        visited.insert(start);
        
        while (!q.empty()) {
            auto [cur, steps] = q.front();
            q.pop();
            
            if (cur == target) return steps;
            
            
            int zero_pos = cur.find('0');
            
           
            for (int neighbor : neighbors[zero_pos]) {
                string next = cur;
                swap(next[zero_pos], next[neighbor]);  
                
               
                if (!visited.count(next)) {
                    q.push({next, steps + 1});
                    visited.insert(next);
                }
            }
        }
        
        return -1;  
    }

};