#include <string>
#include <vector>
#include <unordered_set>
#include <unordered_map>
#include <algorithm>
#include <climits>
using namespace std;

class Solution {
public:
    long long countOfSubstrings(string word, int k) {
        int n = word.size();
        unordered_set<char> vowels = {'a', 'e', 'i', 'o', 'u'};
        
        // Build prefix array X where X[i+1] = number of consonants in word[0..i].
        vector<int> X(n + 1, 0);
        for (int i = 0; i < n; i++) {
            X[i+1] = X[i] + (vowels.count(word[i]) ? 0 : 1);
        }
        
        // f[r] stores the smallest index l such that word[l...r] contains every vowel.
        // If not all vowels are present for index r, then f[r] remains -1.
        vector<int> f(n, -1);
        // last seen positions for vowels: order: a, e, i, o, u.
        vector<int> last(5, -1);
        for (int r = 0; r < n; r++) {
            char c = word[r];
            if (c == 'a') last[0] = r;
            else if (c == 'e') last[1] = r;
            else if (c == 'i') last[2] = r;
            else if (c == 'o') last[3] = r;
            else if (c == 'u') last[4] = r;
            
            bool allSeen = true;
            int minIndex = INT_MAX;
            for (int i = 0; i < 5; i++) {
                if (last[i] == -1) {
                    allSeen = false;
                    break;
                }
                minIndex = min(minIndex, last[i]);
            }
            if (allSeen) {
                f[r] = minIndex;
            }
        }
        
        // Build a mapping from each prefix sum value in X to the list of indices where it occurs.
        unordered_map<int, vector<int>> pos;
        for (int i = 0; i <= n; i++) {
            pos[X[i]].push_back(i);
        }
        // Since we filled pos in order, each vector is already sorted.
        
        // Count valid substrings.
        // For each ending index r (0-indexed), if f[r] != -1 then for any starting index l in [0, f[r]],
        // the substring word[l...r] contains every vowel if X[r+1] - X[l] == k.
        // That is, we need X[l] == X[r+1] - k.
        long long result = 0;
        for (int r = 0; r < n; r++) {
            if (f[r] == -1) continue; // vowels condition not met for this r.
            int target = X[r+1] - k;
            if (pos.find(target) == pos.end())
                continue;
            auto &vec = pos[target];
            // Count how many indices in vec are <= f[r] using binary search.
            int count = upper_bound(vec.begin(), vec.end(), f[r]) - vec.begin();
            result += count;
        }
        
        return result;
    }
};
