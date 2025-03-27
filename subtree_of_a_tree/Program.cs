/*
Leetcode: https://leetcode.com/problems/subtree-of-another-tree/

Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.

A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.


Example 1:

 root:             subRoot:
       3                4
     /  \             /  \
    4    5           1    2
   / \
  1   2

Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true


Example 2:

 root:             subRoot:
       3                4
     /  \             /  \
    4    5           1    2
   / \
  1   2
     /
    0

Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false


Constraints:

The number of nodes in the root tree is in the range [1, 2000].
The number of nodes in the subRoot tree is in the range [1, 1000].
-104 <= root.val <= 104
-104 <= subRoot.val <= 104


Example 3: true

 root:             subRoot:
       3                3
     /  \             /  \
    3    5           1    2
   / \
  1   2


Example 4: false

 root:             subRoot:
       3                3
     /  \             /  \
    4    5           1    2
   /    /
  1    2
*/


/*
 root:             subRoot:
       3                3
     /  \             /  \
    3    5           1    2
   / \
  1   2

*/

using System.ComponentModel;

static bool IsSubtree_WithParam(TreeNode? root, TreeNode? subRoot) {

    return IsSubtree(root, subRoot, false);

    static bool IsSubtree(TreeNode? root, TreeNode? subRoot, bool is_expanded)
    {
        if (root is null &&  subRoot is null) return true;
        if (root is null ||  subRoot is null) return false;

        if (root.val == subRoot.val)
        {
            if (IsSubtree(root.left, subRoot.left, true) && IsSubtree(root.right, subRoot.right, true))
            {
                return true;
            }
        }
        if (is_expanded)
        {
            return false;
        }

        return IsSubtree(root.left, subRoot, false) || IsSubtree(root.right, subRoot,false);
    }
}


static bool IsSubtree(TreeNode? root, TreeNode subRoot) {

    if (root is null) return false;
    if (AreEqual(root, subRoot)) return true;

    return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);


    static bool AreEqual(TreeNode? root, TreeNode? subRoot)
    {
        if (root is null && subRoot is null) return true;
        if (root is null || subRoot is null) return false;

        return root.val == subRoot.val && AreEqual(root.left, subRoot.left) && AreEqual(root.right, subRoot.right);
    }
}


TreeNode root_a = new(3)
{
    left = new(4) {left = new(1), right = new(2)},
    right = new(5),
};
TreeNode subroot_a = new(4) {left = new(1), right = new(2)};


TreeNode root_b = new(3)
{
    left = new(4) {left = new(1), right = new(2) {left = new(0)}},
    right = new(5),
};
TreeNode subroot_b = new(4) {left = new(1), right = new(2)};

/*
 root:             subRoot:
       3                3
     /  \             /  \
    3    5           1    2
   / \
  1   2

*/


TreeNode root_c = new(3)
{
    left = new(3) {left = new(1), right = new(2)},
    right = new(5),
};
TreeNode subroot_c = new(3) {left = new(1), right = new(2)};

/*
 root:             subRoot:
       3                3
     /  \             /  \
    4    5           1    2
   /    /
  1    2

*/

TreeNode root_d = new(3)
{
    left = new(4) {left = new(1)},
    right = new(5) {left = new(2)},
};
TreeNode subroot_d = new(3) {left = new(1), right = new(2)};


Console.WriteLine(IsSubtree(root_a, subroot_a));
Console.WriteLine(!IsSubtree(root_b, subroot_b));
Console.WriteLine(IsSubtree(root_c, subroot_c));
Console.WriteLine(IsSubtree(root_d, subroot_d) == false);



class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;
}
