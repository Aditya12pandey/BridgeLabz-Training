public class Solution {
    public string WinningPlayer(int x, int y) {
        int d = y/4;
        int e = Math.Min(x,d);
        return e%2 == 0?"Bob" : "Alice";
    } 
}