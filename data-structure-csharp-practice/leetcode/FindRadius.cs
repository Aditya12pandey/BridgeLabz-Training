public class Solution {
    public int FindRadius(int[] houses, int[] heaters) {
        int j=0;
        int maxRadius = int.MinValue;

        Array.Sort(houses);
        Array.Sort(heaters);

        for(int i=0; i<houses.Length; i++)
        {
            int currRadius = Math.Abs(houses[i] - heaters[j]);

            while(j < heaters.Length-1 && Math.Abs(houses[i] - heaters[j+1]) <= currRadius)
            {
                j++;
                currRadius = Math.Abs(houses[i] - heaters[j]);
            }

            maxRadius = Math.Max(currRadius, maxRadius);
        }

        return maxRadius;
    }
}