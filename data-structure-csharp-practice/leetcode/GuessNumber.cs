

public class Solution : GuessGame 
{
    public int GuessNumber(int n) 
    {
        var left = 0;
        var right = n;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var result = guess(mid);
            if (result == 0)
            {
                return mid;
            }
            else if (result == -1)
            {
                right = mid - 1;
            }
            else 
            {
                left = mid + 1;
            }
        }  

        throw new InvalidOperationException();     
    }
}