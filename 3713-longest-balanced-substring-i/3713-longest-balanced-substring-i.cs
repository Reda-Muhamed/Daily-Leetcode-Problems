public class Solution {
    public int LongestBalanced(string s) {
        int len = s.Length;
        int maxlen = 0;

        for (int i = 0; i < len; i++) {
            var dic = new Dictionary<char, int>();

            for (int j = i; j < len; j++) {

                if (!dic.ContainsKey(s[j]))
                    dic[s[j]] = 0;

                dic[s[j]]++;

                int count = dic[s[i]];
                bool balanced = true;

                foreach (var kv in dic) {
                    if (kv.Value != count) {
                        balanced = false;
                        break;
                    }
                }

                if (balanced)
                    maxlen = Math.Max(maxlen, j - i + 1);
            }
        }

        return maxlen;
    }
}
