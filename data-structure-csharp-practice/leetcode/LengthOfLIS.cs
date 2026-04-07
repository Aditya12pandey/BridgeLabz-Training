public class Solution {
    public int LengthOfLIS(int[] nums) {

		int c = 0;
		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i] > nums[c])
			{
				nums[++c] = nums[i];
				continue;
			}

			var idx = Array.BinarySearch(nums, 0, c, nums[i]);
			if (idx < 0)
			{
				nums[~idx] = nums[i];
			}
		}
		return c + 1;
    }
}