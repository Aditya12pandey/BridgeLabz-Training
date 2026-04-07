public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
         int i = 0, j = 0;
 Array.Sort(nums1);
 Array.Sort(nums2);

 int[] res = new int[nums1.Length > nums2.Length ? nums2.Length : nums1.Length];
 int k = 0;

 while (i < nums1.Length && j < nums2.Length)
 {
     if (nums1[i] == nums2[j])
     {
         res[k++] = nums1[i++];
         j++;
     }
     else
     {
         int t = nums1[i] > nums2[j] ? j++ : i++;
     }
 }

 Array.Resize(ref res, k);
 return res;
    }
}