public class Solution {
    public bool Find132pattern(int[] nums) {
         Stack<int> stack = new Stack<int>();
 int third = int.MinValue;

 for (int i = nums.Length - 1; i >= 0; i--)
 {
     if (nums[i] < third) return true;
     while (stack.Count > 0 && stack.Peek() < nums[i])
     {
         third = stack.Pop();
     }
     stack.Push(nums[i]);
 }
 return false;
    }
}