public class Solution {
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> result = new List<IList<string>>();
        int n = s.Length;
        bool[,] dp = new bool[n, n];

        // Fill the dp array
        for (int len = 1; len <= n; len++) {
            for (int i = 0; i <= n - len; i++) {
                int j = i + len - 1;
                if (len == 1) {
                    dp[i, j] = true;
                } else if (len == 2) {
                    dp[i, j] = (s[i] == s[j]);
                } else {
                    dp[i, j] = (s[i] == s[j] && dp[i + 1, j - 1]);
                }
            }
        }

        Backtrack(s, 0, new List<string>(), result, dp);
        return result;
    }
    private void Backtrack(string s, int start, List<string> currentList, IList<IList<string>> result, bool[,] dp) {
        if (start == s.Length) {
            result.Add(new List<string>(currentList));
            return;
        }
        for (int end = start; end < s.Length; end++) {
            if (dp[start, end]) {
                currentList.Add(s.Substring(start, end - start + 1));
                Backtrack(s, end + 1, currentList, result, dp);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }
}