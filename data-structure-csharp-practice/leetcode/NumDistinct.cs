public class Solution {
    public int NumDistinct(string s, string t) {
int m = s.Length;
int n = t.Length;
if (n == 0) return 1;
if (n > m) return 0;

long[] dp = new long[n + 1];
dp[0] = 1;

for (int i = 1; i <= m; i++)
{
    for (int j = n; j >= 1; j--)
    {
        if (s[i - 1] == t[j - 1])
        {
            dp[j] += dp[j - 1];
        }
    }
}

return (int)dp[n];
    }
}