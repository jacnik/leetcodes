/*
Leetcode: https://leetcode.com/problems/maximum-depth-of-binary-tree/

Given the root of a binary tree, return its maximum depth.

A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

    3
   / \
  9  20
    /  \
   15   7

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: 3
Example 2:

Input: root = [1,null,2]
Output: 2


Constraints:

The number of nodes in the tree is in the range [0, 104].
-100 <= Node.val <= 100
*/

int MaxDepth(TreeNode root) {

    int max_level = 0;
    if (root is null) return max_level;

    Queue<TreeNode> q = [];
    q.Enqueue(root);

    while(q.Count > 0)
    {
        max_level++;
        int level_size = q.Count;

        for (int _ = 0; _ < level_size; ++_)
        {
            var node = q.Dequeue();
            if (node.left is not null) q.Enqueue(node.left);
            if (node.right is not null) q.Enqueue(node.right);
        }
    }

    return max_level;
}

TreeNode root_a = new(3)
{
    left = new(9),
    right = new(20) {left = new(15), right = new(7)},
};


Console.WriteLine(MaxDepth(root_a) == 3);


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