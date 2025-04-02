r"""
Leetcode: https://leetcode.com/problems/merge-k-sorted-lists/

You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

Merge all the linked-lists into one sorted linked-list and return it.

Example 1:

Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted list:
1->1->2->3->4->4->5->6

Example 2:

Input: lists = []
Output: []

Example 3:

Input: lists = [[]]
Output: []


Constraints:

k == lists.length
0 <= k <= 10^4
0 <= lists[i].length <= 500
-10^4 <= lists[i][j] <= 10^4
lists[i] is sorted in ascending order.
The sum of lists[i].length will not exceed 10^4.
"""

import heapq


class ListNode:
    """Definition for singly-linked list."""
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    """Solution"""
    def merge_k_lists_using_heap(self, lists: list[ListNode | None]) -> ListNode | None:
        """Iterative solution using heap"""
        curr = dummy = ListNode()
        heap = []
        for i, node in enumerate(lists):
            if node:
                heapq.heappush(heap, (node.val, i))

        while heap:
            _, curr_idx = heapq.heappop(heap)
            next_node = lists[curr_idx]
            curr.next = next_node
            curr = curr.next
            lists[curr_idx] = next_node.next
            if next_node.next:
                heapq.heappush(heap, (next_node.next.val, curr_idx))

        return dummy.next

    def merge_k_lists_two_at_a_time(self, lists: list[ListNode | None]) -> ListNode | None:
        """Iterative solution merging two list at a time"""
        def merge_two_lists(l1: ListNode | None, l2: ListNode | None) -> ListNode | None:
            """Merge two sorted linked lists into one linked list"""
            curr = dummy = ListNode()
            while l1 and l2:
                if l1.val < l2.val:
                    curr.next = l1
                    l1 = l1.next
                else:
                    curr.next = l2
                    l2 = l2.next
                curr = curr.next

            if l1:
                curr.next = l1
            if l2:
                curr.next = l2

            return dummy.next

        if not lists:
            return None

        l1 = lists.pop()
        for l in lists:
            l1 = merge_two_lists(l1, l)

        return l1


def to_list(l: ListNode) -> list[int]:
    """Linked list to regular list"""
    res = []
    while l:
        res.append(l.val)
        l = l.next
    return res

def from_list(*args: list[int]) -> ListNode | None:
    """Create linked list from regular list"""
    curr = dummy = ListNode()
    for v in args:
        curr.next = ListNode(v)
        curr = curr.next
    return dummy.next

s = Solution()

print("---Merge using heap---")
print(
    [1, 1, 2, 3, 4, 4, 5, 6],
    to_list(s.merge_k_lists_using_heap(
    [
        from_list(1, 4, 5),
        from_list(1, 3, 4),
        from_list(2, 6)
    ]
)))


print(
    [],
    to_list(s.merge_k_lists_using_heap([]))
)

print(
    [],
    to_list(s.merge_k_lists_using_heap([None]))
)


print("---Merge by merging 2 lists at a time---")
print(
    [1, 1, 2, 3, 4, 4, 5, 6],
    to_list(s.merge_k_lists_two_at_a_time(
    [
        from_list(1, 4, 5),
        from_list(1, 3, 4),
        from_list(2, 6)
    ]
)))


print(
    [],
    to_list(s.merge_k_lists_two_at_a_time([]))
)

print(
    [],
    to_list(s.merge_k_lists_two_at_a_time([None]))
)
