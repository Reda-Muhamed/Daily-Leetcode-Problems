public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
         var result = new List<string>();
        int n = words.Length;

        if (n == 0) return result;

        result.Add(words[0]);
        int lastGroup = groups[0];

        for (int i = 1; i < n; i++) {
            if (groups[i] != lastGroup) {
                result.Add(words[i]);
                lastGroup = groups[i];
            }
        }

        return result;
    }
}