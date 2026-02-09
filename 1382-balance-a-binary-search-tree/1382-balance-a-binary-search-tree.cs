/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode BalanceBST(TreeNode root) {

        List<int> nodes = new List<int>();
        Inorder(root, nodes);
        return BuildBalanced(nodes, 0, nodes.Count - 1);
    }


    private void Inorder(TreeNode node, List<int> nodes) {
        if (node == null) return;
        Inorder(node.left, nodes);
        nodes.Add(node.val);
        Inorder(node.right, nodes);
    }

    
    private TreeNode BuildBalanced(List<int> nodes, int left, int right) {
        if (left > right) return null;

        int mid = (left + right) / 2;
        TreeNode root = new TreeNode(nodes[mid]);

        root.left  = BuildBalanced(nodes, left, mid - 1);
        root.right = BuildBalanced(nodes, mid + 1, right);

        return root;
    }
}