public class Solution {
    private int[] st;
    public void SegmentTree(int n){
        st = new int[4*n];
    }
    public void Update(int id,int l,int r,int u){
        if(l>r) return;
        if(l==r){
            st[id]++;
            return;
        }
        int mid=(l+r)/2;
        if(u<=mid) Update(id*2,l,mid,u);
        else Update(id*2+1,mid+1,r,u);
        st[id]=st[id*2]+st[id*2+1];
    }
    public int GetSum(int id,int l,int r,int u,int v){
        if(l>r || r<u ||l>v) return 0;
        if(u<=l && r<=v) return st[id];
        int mid=(l+r)/2;
        return GetSum(id*2,l,mid,u,v) + GetSum(id*2+1,mid+1,r,u,v);
    }
    public int TriangleNumber(int[] nums) {

        //đếm số lượng số trong (a-b,a+b);
        // không tính hai số a>b
        int ans = 0;
        int n = nums.Length;
        int max = nums.Max();
        SegmentTree(max+1);
        for(int i=0;i<n;i++){
            for(int j=i+1;j<n;j++){
                 int diff = Math.Abs(nums[i]-nums[j])+1;
                 int sum = nums[i]+nums[j]-1;
               
                 ans += GetSum(1,0,max+1,Math.Max(0,diff),Math.Min(max+1,sum));
                // Console.WriteLine(nums[i]+" " +nums[j] +" " + i +" " + j+" " +GetSum(1,0,1000,Math.Max(0,diff),Math.Min(1000,sum)) );
            }
            Update(1,0,max+1,nums[i]);
            
        }
        return ans;
    }
}