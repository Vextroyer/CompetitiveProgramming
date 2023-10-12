/*
//Check for more nice solutions at https://github.com/Vextroyer/CompetitiveProgramming

https://leetcode.com/problems/path-sum-ii/

Calculate the sums of the nodes from the root to the leaves and store the path itself.
*/

 //Definition for a binary tree node.
 public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

class PathSum{
    public IList<IList<int>> CalculatePathSum(TreeNode root, int targetSum) {
        IList<IList<int>> store = new List<IList<int>>();//For storing solutions
        if(root == null)return store;
        IList<int> partial = new List<int>();//For storing partial sums
        Calculate(root,targetSum,root.val,partial,store);
        return store;
    }
    //A tree traversal
    private void Calculate(TreeNode node,int targetSum,int partialSum,IList<int> partial,IList<IList<int>> store){
        if(IsLeaf(node)){
            if(targetSum == partialSum)store.Add(new List<int>(partial));
            return;
        }
        if(node.left != null){
            partial.Add(node.left.val);
            Calculate(node.left,targetSum,partialSum + node.left.val,partial,store);
            partial.RemoveAt(partial.Count - 1);
        }
        if(node.right != null){
            partial.Add(node.right.val);
            Calculate(node.right,targetSum,partialSum + node.right.val,partial,store);
            partial.RemoveAt(partial.Count - 1);
        }
    }
    private bool IsLeaf(TreeNode node){
        return node.left == null && node.right == null;
    }
}