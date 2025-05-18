public class Solution {
    public int CoinChange(int[] coins, int amount) {
        CoinChangeDP(coins, amount, out int[] C, out int[] S);
        return C[amount] == int.MaxValue ? -1 : C[amount];
    }

    public void CoinChangeDP(int[] coins, int n, out int[] C, out int[] S) {
        C = new int[n + 1];
        S = new int[n + 1];

        for (int i = 1; i <= n; i++) {
            C[i] = int.MaxValue;
        }

        C[0] = 0;

        for (int p = 1; p <= n; p++) {
            int min = int.MaxValue;
            int coin = -1;

            for (int i = 0; i < coins.Length; i++) {
                int prev = p - coins[i];
                if (prev >= 0 && C[prev] != int.MaxValue) {
                    if (1 + C[prev] < min) {
                        min = 1 + C[prev];
                        coin = i;
                    }
                }
            }

            C[p] = min;
            S[p] = coin;
        }
    }
}
