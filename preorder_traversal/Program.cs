/*
Leetcode: https://leetcode.com/problems/binary-tree-preorder-traversal

Given the root of a binary tree, return the preorder traversal of its nodes' values.



Example 1:

Input: root = [1,null,2,3]

Output: [1,2,3]

Explanation:


    1
     \
      2
     /
    3


Example 2:

Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]

Output: [1,2,4,5,6,7,3,8,9]

Explanation:

              1
           /    \
          /      \
         2        3
        / \        \
       4   5        8
          / \      /
         6   7    9


Example 3:

Input: root = []

Output: []

Example 4:

Input: root = [1]

Output: [1]



Constraints:

The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100

*/

TreeNode r1 = new(1) {right = new(2) {left = new(3)}};
TreeNode r2 = new(1) {
    left = new(2) {
        left = new(4),
        right = new(5) {
            left = new(6),
            right = new(7)
        }
    },
    right = new(3) {
        right = new(8) {
            left = new(9)
        },
    }
};
TreeNode? r3 = null;
TreeNode r4 = new(1);


Console.WriteLine($"1,2,3\n{PrintList(PreorderTraversal(r1))}");
Console.WriteLine($"1,2,4,5,6,7,3,8,9\n{PrintList(PreorderTraversal(r2))}");
Console.WriteLine($"\n{PrintList(PreorderTraversal(r3))}");
Console.WriteLine($"1\n{PrintList(PreorderTraversal(r4))}");



static IList<int> PreorderTraversal(TreeNode? root) {
    List<int> res = [];
    Stack<TreeNode> stack = [];

    while(root is not null || stack.Count > 0)
    {
        while (root is not null)
        {
            res.Add(root.val);
            stack.Push(root);
            root = root.left;
        }

        root = stack.Pop();
        root = root.right;
    }

    return res;
}

static IList<int> PreorderTraversal_Recursion(TreeNode? root) {
    List<int> res = [];

    PreorderTraversalRec(root);
    return res;
    void PreorderTraversalRec(TreeNode? root)
    {
        if (root is null) return;
        res.Add(root.val);
        PreorderTraversalRec(root.left);
        PreorderTraversalRec(root.right);
    }
}


static string PrintList(IEnumerable<int> l)
{
    return string.Join(',', l);
}

class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;
}

