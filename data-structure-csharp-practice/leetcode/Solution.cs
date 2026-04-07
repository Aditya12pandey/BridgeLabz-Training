
public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int left = 1;
        int right = n;
        while(left <= right){
            int middle = (right - left)/2 + left;
            if(!IsBadVersion(middle)){
                left = middle + 1;
            }else{
                right = middle - 1;
            }
        }
        return left;
    }
}