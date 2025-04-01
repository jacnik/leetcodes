r"""
Leetcode: https://leetcode.com/problems/linked-list-cycle/

Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.


Example 1:
    3 -> 2 -> 0 -> -4
         ^          |
         +----------+

Input: head = [3,2,0,-4], pos = 1
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).


Example 2:
    1 -> 2
    ^    |
    +----+


Input: head = [1,2], pos = 0
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.


Example 3:


Input: head = [1], pos = -1
Output: false
Explanation: There is no cycle in the linked list.


Constraints:

The number of the nodes in the list is in the range [0, 10^4].
-10^5 <= Node.val <= 10^5
pos is -1 or a valid index in the linked-list.


Follow up: Can you solve it using O(1) (i.e. constant) memory?

"""


class ListNode:
    "Definition for singly-linked list."
    def __init__(self, x):
        self.val = x
        self.next = None


class Solution:
    """Solution"""
    def has_cycle_with_set(self, head: ListNode | None) -> bool:
        """Detect cycle using set to track visited nodes"""
        visited = set()
        while head:
            if head in visited:
                return True
            visited.add(head)
            head = head.next
        return False

    def has_cycle_slow_fast(self, head: ListNode | None) -> bool:
        """Detect cycle using a slow and fast pointer"""
        slow = fast = head
        while fast and fast.next:
            slow = slow.next
            fast = fast.next.next

            if slow == fast:
                return True

        return False

    def has_cycle_destructive(self, head: ListNode | None) -> bool:
        """Detect cycle setting visited nodes value to a sentinel"""
        sentinel = 10**5 + 1
        while head:
            if head.val == sentinel:
                return True
            head.val = sentinel
            head = head.next
        return False



s = Solution()

list1 = ListNode(3)
list1.next = ListNode(2)
list1.next.next = ListNode(0)
list1.next.next.next = ListNode(-4)
list1.next.next.next.next = list1.next


list2 = ListNode(1)
list2.next = ListNode(2)
list2.next.next = list2

print("---Using Set---")
print(s.has_cycle_with_set(list1))
print(s.has_cycle_with_set(list2))
print(not s.has_cycle_with_set(ListNode(1)))

print("---Using Slow and fast pointers---")
print(s.has_cycle_slow_fast(list1))
print(s.has_cycle_slow_fast(list2))
print(not s.has_cycle_slow_fast(ListNode(1)))

print("---Using sentinel---")
print(s.has_cycle_destructive(list1))
print(s.has_cycle_destructive(list2))
print(not s.has_cycle_destructive(ListNode(1)))
