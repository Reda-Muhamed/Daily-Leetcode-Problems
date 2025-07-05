using System;
using System.Collections.Generic;

public class Solution {
    public int FindLucky(int[] arr) {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int num in arr) {
            if (freq.ContainsKey(num)) {
                freq[num]++;
            } else {
                freq[num] = 1;
            }
        }

        int result = -1;
        foreach (var item in freq) {
            if (item.Key == item.Value) {
                result = Math.Max(result, item.Key);
            }
        }

        return result;
    }
}
