using System;
using System.Collections.Generic;

public class Solution {
    private const int MOD = 1_000_000_007;

    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {
        // add boundaries
        var h = new List<int>(hFences) { 1, m };
        var v = new List<int>(vFences) { 1, n };

        h.Sort();
        v.Sort();

        // collect all possible vertical distances
        var vertical = new HashSet<int>();
        for (int i = 0; i < h.Count; i++) {
            for (int j = i + 1; j < h.Count; j++) {
                vertical.Add(h[j] - h[i]);
            }
        }

        // collect all possible horizontal distances
        var horizontal = new HashSet<int>();
        for (int i = 0; i < v.Count; i++) {
            for (int j = i + 1; j < v.Count; j++) {
                horizontal.Add(v[j] - v[i]);
            }
        }

        int maxSide = 0;
        foreach (var d in vertical) {
            if (horizontal.Contains(d)) {
                maxSide = Math.Max(maxSide, d);
            }
        }

        if (maxSide == 0) return -1;

        return (int)((long)maxSide * maxSide % MOD);
    }
}
