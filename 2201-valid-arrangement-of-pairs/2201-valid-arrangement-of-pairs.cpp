class Solution {
public:
    vector<vector<int>> validArrangement(vector<vector<int>>& pairs) {
        unordered_map<int, deque<int>> graph;
    unordered_map<int, int> in_degree, out_degree;

    for (auto& pair : pairs) {
        int start = pair[0], end = pair[1];
        graph[start].push_back(end);
        out_degree[start]++;
        in_degree[end]++;
    }

    int start_node = pairs[0][0];
    for (auto& [node, _] : graph) {
        if (out_degree[node] - in_degree[node] == 1) {
            start_node = node;
            break;
        }
    }

    stack<int> stack;
    vector<int> path;
    stack.push(start_node);

    while (!stack.empty()) {
        int node = stack.top();
        if (!graph[node].empty()) {
            int next_node = graph[node].front();
            graph[node].pop_front();
            stack.push(next_node);
        } else {
            path.push_back(node);
            stack.pop();
        }
    }

    reverse(path.begin(), path.end());
    vector<vector<int>> result;
    for (int i = 0; i < path.size() - 1; ++i) {
        result.push_back({path[i], path[i + 1]});
    }

    return result;
    }
};