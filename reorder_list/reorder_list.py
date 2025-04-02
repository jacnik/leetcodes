r"""
Leetcode: https://leetcode.com/problems/reorder-list/

You are given the head of a singly linked-list. The list can be represented as:

L0 → L1 → … → Ln - 1 → Ln
Reorder the list to be on the following form:

L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
You may not modify the values in the list's nodes. Only nodes themselves may be changed.

Example 1:

1 -> 2 -> 3 -> 4
        |
        V
1 -> 4 -> 2 -> 3

Input: head = [1,2,3,4]
Output: [1,4,2,3]


Example 2:

1 -> 2 -> 3 -> 4 -> 5
        |
        V
1 -> 5 -> 2 -> 4 -> 3


Input: head = [1,2,3,4,5]
Output: [1,5,2,4,3]


Constraints:

The number of nodes in the list is in the range [1, 5 * 10^4].
1 <= Node.val <= 1000
"""


class ListNode:
    """Definition for singly-linked list."""
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    """Solution"""
    def reorderList(self, head: ListNode | None) -> None:
        """
        Do not return anything, modify head in-place instead.
        """
        # Find last and middle nodes
        #           m               l
        # 1 -> 2 -> 3 -> 4 -> 5 -> null
        mid = last = head
        while last and last.next:
            mid = mid.next
            last = last.next.next

        # reverse all nodes after mid to point in opposite directions.
        # Point last to the last node.
        # This splits the list into two.
        #           m           l
        # 1 -> 2 -> 3      4 <- 5
        curr = mid.next
        mid.next = None
        prev = None
        while curr:
            tail = curr.next
            curr.next = prev
            prev = curr
            curr = tail

        # zip two new linked lists head and prev.
        # head = 1 -> 2 -> 3
        # prev = 5 -> 4
        while prev:
            tail = prev.next
            prev.next = head.next
            head.next = prev
            head = prev.next
            prev = tail


def to_list(l: ListNode) -> list[int]:
    """Linked list to regular list"""
    res = []
    while l:
        res.append(l.val)
        l = l.next
    return res



s = Solution()

list1 = ListNode(1, ListNode(2, ListNode(3, ListNode(4))))
s.reorderList(list1)
print([1, 4, 2, 3], to_list(list1))

list2 = ListNode(1, ListNode(2, ListNode(3, ListNode(4, ListNode(5)))))
s.reorderList(list2)
print([1, 5, 2, 4, 3], to_list(list2))

list3 = ListNode(1)
s.reorderList(list3)
print([1], to_list(list3))

list4 = ListNode(1, ListNode(2))
s.reorderList(list4)
print([1, 2], to_list(list4))

list5 = ListNode(1, ListNode(2, ListNode(3)))
s.reorderList(list5)
print([1, 3, 2], to_list(list5))
