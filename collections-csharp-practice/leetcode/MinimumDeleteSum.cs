public class Solution {
    public int MinimumDeleteSum(string s1, string s2) {
        int m = s1.Length;
        int n = s2.Length;

        int[,] dp = new int[m + 1, n + 1];

        // Base case: delete all characters from s1
        for (int i = 1; i <= m; i++) {
            dp[i, 0] = dp[i - 1, 0] + s1[i - 1];
        }

        // Base case: delete all characters from s2
        for (int j = 1; j <= n; j++) {
            dp[0, j] = dp[0, j - 1] + s2[j - 1];
        }

        // Fill DP table
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (s1[i - 1] == s2[j - 1]) {
                    dp[i, j] = dp[i - 1, j - 1];
                } else {
                    dp[i, j] = Math.Min(
                        dp[i - 1, j] + s1[i - 1],  // delete from s1
                        dp[i, j - 1] + s2[j - 1]   // delete from s2
                    );
                }
            }
        }

        return dp[m, n];
    }
}