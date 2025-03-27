/*
Leetcode: https://leetcode.com/problems/invert-binary-tree/

Given the root of a binary tree, invert the tree, and return its root.


Example 1:

     4              4
   /   \          /   \
  2     7   =>   7     2
 / \   / \      / \   / \
1   3 6   9    9   6 3   1

Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]

Example 2:

     2              2
   /   \          /   \
  1     3   =>   3     1

Input: root = [2,1,3]
Output: [2,3,1]
Example 3:

Input: root = []
Output: []


Constraints:

The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100

*/

static TreeNode? InvertTree(TreeNode? root) {
    if(root is null) return root;

    var right = root.right;
    root.right = InvertTree(root.left);
    root.left = InvertTree(right);
    return root;
}

TreeNode root_a = new(4) {
    left = new(2) {left = new(1), right = new(3)},
    right = new(7) {left = new(6), right = new(9)}
};


TreeNode root_b = new(2) {left = new(1), right = new(3)};




class TreeNode {
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
