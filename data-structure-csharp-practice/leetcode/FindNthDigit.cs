public class Solution {
    public int FindNthDigit(int n) {
         if (n < 10) return n;
 long digitCount = 1;
 long count = 9;
 long start = 1;
 while (n > digitCount * count)
 {
     n -= (int)(digitCount * count);
     digitCount++;
     count *= 10;
     start *= 10;
 }
 start += (n - 1) / digitCount;
 string numStr = start.ToString();
 return int.Parse(numStr[(int)((n - 1) % digitCount)].ToString());
    }
}