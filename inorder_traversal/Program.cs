/*
Leetcode: https://leetcode.com/problems/binary-tree-inorder-traversal

Given the root of a binary tree, return the inorder traversal of its nodes' values.



Example 1:

Input: root = [1,null,2,3]

Output: [1,3,2]

Explanation:

    1
     \
      2
     /
    3


Example 2:

Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]

Output: [4,2,6,5,7,1,3,9,8]

Explanation:
              1
           /     \
          /       \
         2         3
        / \         \
       4   5         8
          / \       /
         6   7     9


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


Console.WriteLine($"1,3,2\n{PrintList(InorderTraversal(r1))}");
Console.WriteLine($"4,2,6,5,7,1,3,9,8\n{PrintList(InorderTraversal(r2))}");
Console.WriteLine($"\n{PrintList(InorderTraversal(r3))}");
Console.WriteLine($"1\n{PrintList(InorderTraversal(r4))}");


static IList<int> InorderTraversal(TreeNode? root)
{
    List<int> res = [];
    Stack<TreeNode> stack = [];

    while (root is not null || stack.Count > 0)
    {
        while(root is not null)
        {
            stack.Push(root);
            root = root.left;
        }

        root = stack.Pop();
        res.Add (root.val);
        root = root.right;
    }

    return res;
}

static IList<int> InorderTraversal_Rec(TreeNode? root) {

    List<int> res = [];
    InorderTraversalRec(root, res);
    return res;

    static void InorderTraversalRec(TreeNode? root, List<int> res)
    {
        if (root == null) return;
        InorderTraversalRec(root.left, res);
        res.Add(root.val);
        InorderTraversalRec(root.right, res);
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

