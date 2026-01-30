public class Solution {
    public bool IsPalindrome(string s) {
        string newStr = "";
        foreach (char i in s) {
            if (char.IsLetterOrDigit(i)) {
                newStr += char.ToLower(i);
            }
        }
        int l = 0, r = newStr.Length - 1;
        while (l < r) {
            if (newStr[l++] != newStr[r--]) return false;
        }
        return true;
    }
}