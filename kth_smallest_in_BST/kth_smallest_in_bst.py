r"""
Leetcode: https://leetcode.com/problems/kth-smallest-element-in-a-bst/

Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.


Example 1:
     3
   /   \
  1     4
   \
    2

Input: root = [3,1,4,null,2], k = 1
Output: 1

Example 2:

        5
       / \
      3   6
     / \
    2   4
   /
  1

Input: root = [5,3,6,2,4,null,null,1], k = 3
Output: 3


Constraints:

The number of nodes in the tree is n.
1 <= k <= n <= 104
0 <= Node.val <= 104


Follow up: If the BST is modified often (i.e., we can do insert and delete operations) and you need to find the kth smallest frequently, how would you optimize?
"""

class TreeNode:
    """Tree Node"""
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    """Solution"""
    def kth_smallest_iterative(self, root: TreeNode | None, k: int) -> int:
        """iterative in order traversal kth smallest"""
        stack = []
        count = 0
        while root or stack:
            while root:
                stack.append(root)
                root = root.left

            root = stack.pop()
            count += 1
            if count == k:
                return root.val
            root = root.right


    def kth_smallest_recursive(self, root: TreeNode | None, k: int) -> int:
        """recursive in order traversal kth smallest"""
        found_value = -1
        def in_order(root: TreeNode | None, idx: int) -> int:
            nonlocal found_value
            if not root or found_value != -1:
                return idx

            idx = 1 + in_order(root.left, idx)

            if idx == k:
                found_value = root.val
                return idx

            idx = in_order(root.right, idx)

            return idx

        in_order(root, 0)
        return found_value


r1 = TreeNode(3, left=TreeNode(1, right=TreeNode(2)), right=TreeNode(4))
r2 = TreeNode(
    5,
    left=TreeNode(
        3,
        left=TreeNode(2, left=TreeNode(1)),
        right=TreeNode(4)),
    right=TreeNode(6)
)


s = Solution()
print('recursive:')
print(s.kth_smallest_recursive(r1, 1) == 1)
print(s.kth_smallest_recursive(r2, 3) == 3)

print('iterative:')
print(s.kth_smallest_iterative(r1, 1) == 1)
print(s.kth_smallest_iterative(r2, 3) == 3)

