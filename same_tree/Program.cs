/*
Leetcode: https://leetcode.com/problems/same-tree/

Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

Example 1:

    1      1
   / \    / \
  2   3  2   3

Input: p = [1,2,3], q = [1,2,3]
Output: true


Example 2:

    1      1
   /        \
  2          2


Input: p = [1,2], q = [1,null,2]
Output: false


Example 3:

    1      1
   / \    / \
  2   1  1   2

Input: p = [1,2,1], q = [1,1,2]
Output: false


Constraints:

The number of nodes in both trees is in the range [0, 100].
-104 <= Node.val <= 104

*/

static bool IsSameTree(TreeNode? p, TreeNode? q) {
    if (p is null && q is null) return true;
    if (p is null || q is null) return false;

    return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
}


TreeNode root_a = new(1) {left = new(2), right = new(3)};
TreeNode root_b = new(1) {left = new(2), right = new(3)};

Console.WriteLine(IsSameTree(root_a, root_b));

TreeNode root_c = new(1) {left = new(2)};
TreeNode root_d = new(1) {right = new(2)};

Console.WriteLine(!IsSameTree(root_c, root_d));

TreeNode root_e = new(1) {left = new(2), right = new(1)};
TreeNode root_f = new(1) {left = new(1), right = new(2)};

Console.WriteLine(!IsSameTree(root_e, root_f));


class TreeNode {
    public int val;
    public TreeNode? left = default;
    public TreeNode? right = default;
    public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
