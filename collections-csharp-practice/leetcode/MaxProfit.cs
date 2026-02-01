public class Solution {
    public int MaxProfit(int[] prices, int fee) {
          int[][] dp = new int[prices.Length + 1][];
  for (int i = 0; i < prices.Length + 1; i++)
  {
      dp[i] = new int[2];
  }
  int res = 0;
  dp[0][0] = 0;
  dp[0][1] = int.MinValue;
  for (int i = 0; i < prices.Length; i++)
  {
      dp[i + 1][0] = Math.Max(dp[i][0], dp[i][1] + prices[i]);
      dp[i + 1][1] = Math.Max(dp[i][1], dp[i][0] - prices[i] - fee);
      res = Math.Max(res, dp[i + 1][0]);
      res = Math.Max(res, dp[i + 1][1]);
  }
  return res;
    }
}