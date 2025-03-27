/*
Leetcode: https://leetcode.com/problems/validate-binary-search-tree/

Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.


Example 1:

    2
  /  \
 1    3

Input: root = [2,1,3]
Output: true


Example 2:

    5
  /  \
 1    4
     / \
    3   6

Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.

Example 3:

    5
  /  \
 1    6
     / \
    3   7

Output: false


Example 4:

    2
  /  \
 2    2

Output: false


Example 5:

    45
   /
 42
   \
    44
    /
   43
  /
 41

Output: false

Example 6:

    -2147483648
               \
                2147483647

Output: true


Constraints:

The number of nodes in the tree is in the range [1, 104].
-2^31 <= Node.val <= 2^31 - 1

*/


static bool IsValidBST(TreeNode root) {
    return IsValidBST(root.left, root, null) && IsValidBST(root.right, null, root);

    static bool IsValidBST(TreeNode? root, TreeNode? smaller_than, TreeNode? greater_than)
    {
        if (root is null) return true;

        if (smaller_than is not null && root.val >= smaller_than.val) return false;
        if (greater_than is not null && root.val <= greater_than.val) return false;

        var left = IsValidBST(root.left, root, greater_than);
        var right = IsValidBST(root.right, smaller_than, root);

        return left && right;
    }
}

TreeNode tree1 = new(2) {left = new(1), right = new(3)};

TreeNode tree2 = new(5) {
    left = new(1),
    right = new(4) {left = new(3), right = new(6)},
};

TreeNode tree3 = new(5) {
    left = new(1),
    right = new(6) {left = new(3), right = new(7)},
};

TreeNode tree4 = new(2) {left = new(2), right = new(2)};

TreeNode tree5 = new(45) {
    left = new(42) {
        right = new (44) {
            left = new(43) {
                left = new(41)
            }
        }
    }
};

TreeNode tree6 = new(-2147483648) {right = new(2147483647)};


Console.WriteLine(IsValidBST(tree1));
Console.WriteLine(IsValidBST(tree2) == false);
Console.WriteLine(IsValidBST(tree3) == false);
Console.WriteLine(IsValidBST(tree4) == false);
Console.WriteLine(IsValidBST(tree5) == false);
Console.WriteLine(IsValidBST(tree6));



class TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null) {
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;
}

