public class Solution {
    Dictionary<int, int> dp = new Dictionary<int, int>();

    public int CoinChange(int[] coins, int amount) {
        int result = CoinChangeRec(coins, amount);
        return result == int.MaxValue ? -1 : result;
    }

    private int CoinChangeRec(int[] coins, int amount) {
        if (amount == 0) return 0;
        if (amount < 0) return int.MaxValue;

        if (dp.ContainsKey(amount)) return dp[amount];

        int minCoins = int.MaxValue;
        foreach (int coin in coins) {
            int res = CoinChangeRec(coins, amount - coin);
            if (res != int.MaxValue) {
                minCoins = Math.Min(minCoins, res + 1);
            }
        }

        dp[amount] = minCoins;
        return minCoins;
    }
}
