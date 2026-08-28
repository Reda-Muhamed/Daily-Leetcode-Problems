public class Solution
{
    public string LexGreaterPermutation(string s, string target)
    {
        int[] count = new int[26];

        foreach (char c in s)
        {
            count[c - 'a']++;
        }

        StringBuilder result = new StringBuilder();
        int lastMatchedIndex = 0;
        for (int i = 0; i < target.Length; i++)
        {
           
            if (count[target[i] - 'a'] == 0)
            {
                // check the bigger one
                int start = target[i] - 'a';

                for (int j = start + 1; j < 26; j++)
                {
                    if (count[j] > 0)
                    {
                        result.Append((char)('a' + j));
                        count[j]--;

                        // append the remaining letters in sorted order
                        for (int k = 0; k < 26; k++)
                        {
                            while (count[k] > 0)
                            {
                                result.Append((char)('a' + k));
                                count[k]--;
                            }
                        }

                        return result.ToString();
                    }
                }

                break;
                // No bigger letter → need to go back
            }
            else
            {
                 lastMatchedIndex = i;
                result.Append(target[i]);
                count[target[i] - 'a']--;
            }
        }

        // target itself was possible, so we need to backtrack
        for (int i = lastMatchedIndex; i >= 0; i--)
        {
            int current = target[i] - 'a';

            count[current]++;

            for (int j = current + 1; j < 26; j++)
            {
                if (count[j] > 0)
                {
                    StringBuilder answer = new StringBuilder();

                    // prefix before i
                    for (int k = 0; k < i; k++)
                    {
                        answer.Append(target[k]);
                    }

                    // make this position bigger
                    answer.Append((char)('a' + j));
                    count[j]--;

                    // remaining letters sorted
                    for (int k = 0; k < 26; k++)
                    {
                        while (count[k] > 0)
                        {
                            answer.Append((char)('a' + k));
                            count[k]--;
                        }
                    }

                    return answer.ToString();
                }
            }
        }

        return "";
    }
}