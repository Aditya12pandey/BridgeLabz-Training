public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
          var set1 = new HashSet<int>(nums1);
  var set2 = new HashSet<int>(nums2);

  var result = new List<int>();
  foreach (var num in set1)
      if (set2.Contains(num)) result.Add(num);

  return result.ToArray();
    }
}