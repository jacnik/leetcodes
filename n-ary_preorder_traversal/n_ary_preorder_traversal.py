r"""
Leetcode: https://leetcode.com/problems/n-ary-tree-preorder-traversal

Given the root of an n-ary tree, return the preorder traversal of its nodes' values.

Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)


Example 1:

        1
     /  |  \
    3   2   4
   / \
  5   6

Input: root = [1,null,3,2,4,null,5,6]
Output: [1,3,5,6,2,4]

Example 2:
            1
     /   /     \        \
    2   3       4        5
       / \      |       / \
      6   7     8      9  10
          |     |      |
          11    12     13
          |
          14

Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [1,2,3,6,7,11,14,4,8,12,5,9,13,10]

Constraints:

The number of nodes in the tree is in the range [0, 104].
0 <= Node.val <= 104
The height of the n-ary tree is less than or equal to 1000.

"""


class Node:
    """Definition for a Node."""
    def __init__(self, val: int | None = None, children: list['Node'] | None = None):
        self.val = val
        if not children:
            self.children = []
        else:
            self.children = children


def preorder(root: 'Node') -> list[int]:
    """Iterative version of preorder traversal"""
    res = []
    stack = []

    if root:
        stack.append(root)

    while stack:
        root = stack.pop()
        res.append(root.val)

        for i in range(len(root.children) -1, -1, -1):
            c = root.children[i]
            stack.append(c)

    return res


def preorder_recursive(root: 'Node') -> list[int]:
    """Recursive version of preorder traversal"""
    def preorder_rec(root: 'Node'):
        if not root:
            return
        res.append(root.val)
        for c in root.children:
            preorder_rec(c)


    res = []
    preorder_rec(root)
    return res



root1 = Node(1, [
    Node(3, [Node(5), Node(6)]),
    Node(2),
    Node(4)]
)

root2 = Node(1, [
    Node(2),
    Node(3, [Node(6), Node(7, [Node(11, [Node(14)])])]),
    Node(4, [Node(8, [Node(12)])]),
    Node(5, [Node(9, [Node(13)]), Node(10)]),
    ]
)

print(f"[1, 3, 5, 6, 2, 4]\n{preorder(root1)}")
print(f"[1, 2, 3, 6, 7, 11, 14, 4, 8, 12, 5, 9, 13, 10]\n{preorder(root2)}")

