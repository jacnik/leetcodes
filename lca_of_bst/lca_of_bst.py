r"""
Leetcode: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST.

According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”


Example 1:
            6
        /       \
       2         8
     /   \      / \
    0     4    7   9
         / \
        3   5

Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
Output: 6
Explanation: The LCA of nodes 2 and 8 is 6.

Example 2:

            6
        /       \
       2         8
     /   \      / \
    0     4    7   9
         / \
        3   5

Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
Output: 2
Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.

Example 3:

Input: root = [2,1], p = 2, q = 1
Output: 2


Constraints:

• The number of nodes in the tree is in the range [2, 105].
• -109 <= Node.val <= 109
• All Node.val are unique.
• p != q
• p and q will exist in the BST.
"""

class TreeNode:
    """Tree node"""
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


class Solution:
    """Solution"""
    def lowestCommonAncestor(self, root: 'TreeNode', p: 'TreeNode', q: 'TreeNode') -> 'TreeNode':
        """lca of bst"""
        # make sure that p is smaller
        if p.val > q.val:
            p, q = q, p

        while not(p.val <= root.val and root.val <= q.val):
            if q.val <= root.val:
                root = root.left
            else:
                root = root.right

        return root


root1 = TreeNode(6)

root1.left = TreeNode(2)
root1.left.left = TreeNode(0)
root1.left.right = TreeNode(4)
root1.left.right.left = TreeNode(3)
root1.left.right.right = TreeNode(5)

root1.right = TreeNode(8)
root1.right.left = TreeNode(7)
root1.right.right = TreeNode(9)

root2 = TreeNode(2)
root2.left = TreeNode(1)

s = Solution()
print(s.lowestCommonAncestor(root1, TreeNode(2), TreeNode(8)).val == 6)
print(s.lowestCommonAncestor(root1, TreeNode(2), TreeNode(4)).val == 2)
print(s.lowestCommonAncestor(root2, TreeNode(2), TreeNode(1)).val == 2)

