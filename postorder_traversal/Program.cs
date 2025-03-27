/*
Leetcode: https://leetcode.com/problems/binary-tree-postorder-traversal


Given the root of a binary tree, return the postorder traversal of its nodes' values.


Example 1:

Input: root = [1,null,2,3]

Output: [3,2,1]

Explanation:

    1
     \
      2
     /
    3


Example 2:

Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]

Output: [4,6,7,5,2,9,8,3,1]

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

The number of the nodes in the tree is in the range [0, 100].
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


Console.WriteLine($"3,2,1\n{PrintList(PostorderTraversal(r1))}");
Console.WriteLine($"4,6,7,5,2,9,8,3,1\n{PrintList(PostorderTraversal(r2))}");
Console.WriteLine($"\n{PrintList(PostorderTraversal(r3))}");
Console.WriteLine($"1\n{PrintList(PostorderTraversal(r4))}");


IList<int> PostorderTraversal(TreeNode? root) {
    List<int> res = [];
    Stack<TreeNode> stack = [];

    if (root is not null)
    {
        stack.Push(root);
    }

    while(stack.Count > 0)
    {
        root = stack.Pop();
        res.Add(root.val);

        if (root.left is not null)
        {
            stack.Push(root.left);
        }
        if (root.right is not null)
        {
            stack.Push(root.right);
        }
    }

    res.Reverse();
    return res;
}



IList<int> PostorderTraversal_Recursive(TreeNode? root) {
    List<int> res = [];
    PostorderTraversalRec(root);
    return res;

    void PostorderTraversalRec(TreeNode? root)
    {
        if (root is null) return;
        PostorderTraversalRec(root.left);
        PostorderTraversalRec(root.right);
        res.Add(root.val);
    }
}


/* Helper excercise: Reversed postorder traversal

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
Output: [1,3,8,9,2,5,7,6,4]

Explanation:

              1
           /    \
          /      \
         2        3
        / \        \
       4   5        8
          / \      /
         6   7    9
*/



Console.WriteLine($"1,2,3\n{PrintList(ReversedPostorderTraversal(r1))}");
Console.WriteLine($"1,3,8,9,2,5,7,6,4\n{PrintList(ReversedPostorderTraversal(r2))}");


IList<int> ReversedPostorderTraversal(TreeNode? root) {
    List<int> res = [];
    Stack<TreeNode> stack = [];

    if (root is not null)
    {
        stack.Push(root);
    }

    while(stack.Count > 0)
    {
        root = stack.Pop();
        res.Add(root.val);

        if (root.left is not null)
        {
            stack.Push(root.left);
        }
        if (root.right is not null)
        {
            stack.Push(root.right);
        }
    }

    return res;
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