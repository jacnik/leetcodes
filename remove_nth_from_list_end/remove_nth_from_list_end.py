r"""
Leetcode: https://leetcode.com/problems/remove-nth-node-from-end-of-list


Given the head of a linked list, remove the nth node from the end of the list and return its head.

Example 1:

 1 -> 2 -> 3 -> 4 -> 5
           |
           V
 1 -> 2 -> 3 -> 5


Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]


Example 2:

Input: head = [1], n = 1
Output: []
Example 3:

Input: head = [1,2], n = 1
Output: [1]


Constraints:

The number of nodes in the list is sz.
1 <= sz <= 30
0 <= Node.val <= 100
1 <= n <= sz


Follow up: Could you do this in one pass?
"""


class ListNode:
    "Definition for singly-linked list."
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution:
    """Solution"""
    def remove_nth_from_end_trailing_and_lagging(self, head: ListNode | None, n: int) -> ListNode | None:
        """remove from end using trailing and lagging pointers separated by n + 1 nodes"""
        dummy = ListNode(0, next=head)
        trailing = lagging = dummy

        # set trailing pointer n steps ahead of lagging pointer
        for _ in range(n + 1):
            trailing = trailing.next

        while trailing:
            lagging = lagging.next
            trailing = trailing.next

        lagging.next = lagging.next.next

        return dummy.next

    def remove_nth_from_end_fast_slow(self, head: ListNode | None, n: int) -> ListNode | None:
        """remove from end using fast and slow pointers"""
        dummy = ListNode(next=head)
        slow = fast = dummy

        slow_idx = fast_idx = 0

        while fast:
            if not fast.next:
                fast_idx += 1
                break
            slow_idx += 1
            fast_idx += 2
            slow = slow.next
            fast = fast.next.next

        n_th_from_head = fast_idx - n - 1
        if slow_idx > n_th_from_head:
            slow_idx = 0
            slow = dummy

        while slow_idx < n_th_from_head:
            slow_idx += 1
            slow = slow.next
        if slow.next:
            slow.next = slow.next.next

        return dummy.next



def to_list(l: ListNode | None) -> list[int]:
    """Linked list to regural list"""
    res = []
    while l:
        res.append(l.val)
        l = l.next
    return res


s = Solution()

list1 = ListNode(1, ListNode(2, ListNode(3, ListNode(4, ListNode(5)))))

print("---Trailing and lagging Pointers---")
print([1, 2, 3, 5], to_list(s.remove_nth_from_end_trailing_and_lagging(list1, 2)))
print([], to_list(s.remove_nth_from_end_trailing_and_lagging(ListNode(1), 1)))
print([1], to_list(s.remove_nth_from_end_trailing_and_lagging(ListNode(1, ListNode(2)), 1)))

print("---Slow and Fast Pointers---")
print([1, 2, 3, 5], to_list(s.remove_nth_from_end_fast_slow(list1, 2)))
print([], to_list(s.remove_nth_from_end_fast_slow(ListNode(1), 1)))
print([1], to_list(s.remove_nth_from_end_fast_slow(ListNode(1, ListNode(2)), 1)))
