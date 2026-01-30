public class Solution {
    public int CountNodes(TreeNode root) {
        if(root==null){
            return 0;
        }
        var leftHeight = ComputeLeftHeight(root);
        var rightHeight = ComputeRightHeight(root);

        if(leftHeight==rightHeight){
            return (int) Math.Pow(2,leftHeight)-1;
        }
        
        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }
    private int ComputeLeftHeight(TreeNode node){
        int height=0;
        while(node!=null){
            node=node.left;
            height++;
        }
        return height;
    }
    private int ComputeRightHeight(TreeNode node){
        int height=0;
        while(node!=null){
            node=node.right;
            height++;
        }
        return height;
    }
}