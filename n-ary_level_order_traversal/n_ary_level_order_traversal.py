r"""
Leetcode: https://leetcode.com/problems/n-ary-tree-preorder-traversal

Given an n-ary tree, return the level order traversal of its nodes' values.

Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)


Example 1:

        1
     /  |  \
    3   2   4
   / \
  5   6

Input: root = [1,null,3,2,4,null,5,6]
Output: [[1],[3,2,4],[5,6]]

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
Output: [[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]

Constraints:

The number of nodes in the tree is in the range [0, 104].
0 <= Node.val <= 104
The height of the n-ary tree is less than or equal to 1000.

"""
from collections import deque


class Node:
    """Definition for a Node."""
    def __init__(self, val: int | None = None, children: list['Node'] | None = None):
        self.val = val
        if not children:
            self.children = []
        else:
            self.children = children



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


def level_order_iter(root: 'Node') -> list[list[int]]:
    """iterative implementation of level order traversal of an n-ary tree"""
    res: list[list[int]] = []
    queue = deque()
    if root:
        queue.append(root)

    while queue:
        level_size = len(queue)
        level = []
        for _ in range(level_size):
            root = queue.popleft()
            level.append(root.val)
            for c in root.children:
                queue.append(c)
        res.append(level)

    return res

print(f"[[1], [3, 2, 4], [5, 6]]\n{level_order_iter(root1)}")
print(f"[[1], [2, 3, 4, 5], [6, 7, 8, 9, 10], [11, 12, 13], [14]]\n{level_order_iter(root2)}")


def level_order_recursive(root: 'Node') -> list[list[int]]:
    """recursive implementation of level order traversal of an n-ary tree"""
    def level_order_rec(root: 'Node', level: int):
        if not root:
            return

        if len(res) <= level:
            res.append([])

        res[level].append(root.val)
        for c in root.children:
            level_order_rec(c, level + 1)


    res: list[list[int]] = []
    level_order_rec(root, 0)
    return res

print(f"[[1], [3, 2, 4], [5, 6]]\n{level_order_recursive(root1)}")
print(f"[[1], [2, 3, 4, 5], [6, 7, 8, 9, 10], [11, 12, 13], [14]]\n{level_order_recursive(root2)}")

