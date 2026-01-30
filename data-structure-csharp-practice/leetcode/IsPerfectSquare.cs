public class Solution {
    public bool IsPerfectSquare(int num)
    {
        switch (num)
        {
            case < 0:
                return false;
            case 0:
            case 1:
                return true;
        }

        var left = 0;
        var right = num / 2;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var square = (long)mid * mid;
            if (square == num)
                return true;
            if (square < num)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        return false;
    }
}