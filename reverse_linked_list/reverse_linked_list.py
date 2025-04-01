r"""
Leetcode: https://leetcode.com/problems/reverse-linked-list/

Given the head of a singly linked list, reverse the list, and return the reversed list.

Example 1:

    1 -> 2 -> 3 -> 4 -> 5
            |
            V
    5 -> 4 -> 3 -> 2 -> 1

Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]


Example 2:

    1 -> 2
      |
      V
    2 -> 1


Input: head = [1,2]
Output: [2,1]
Example 3:

Input: head = []
Output: []


Constraints:

The number of nodes in the list is the range [0, 5000].
-5000 <= Node.val <= 5000


"""
class ListNode:
    """Definition for singly-linked list."""
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    """Solution"""
    def reverse_list_recursive(self, head: ListNode | None) -> ListNode | None:
        """Recursive implementation of reversing linked list"""
        def recur(head: ListNode | None, prev: ListNode | None) -> ListNode | None:
            if not head:
                return prev

            new_head = head.next
            head.next = prev

            return recur(new_head, head)

        return recur(head, None)

    def reverse_list_iterative(self, head: ListNode | None) -> ListNode | None:
        """Iterative implementation of reversing linked list"""

        last = None
        while head:
            next_node = head.next
            head.next = last
            last = head
            head = next_node

        return last

    def reverse_list_recursive_gpt(self, head: ListNode | None) -> ListNode | None:
        """Recursive implementation by gpt"""
        # Base case: If the head is None or only one node, it's already reversed.
        if not head or not head.next:
            return head

        # Recursive case: reverse the rest of the list
        new_head = self.reverse_list_recursive_gpt(head.next)

        # After recursion, head.next is the new head. Fix the current node's pointer.
        head.next.next = head
        head.next = None  # Set the current node's next to None

        return new_head  # Return the new head of the reversed list


def to_list(head: ListNode | None) -> list[int]:
    """Likned list to list"""
    res = []
    while head:
        res.append(head.val)
        head = head.next
    return res


h1 = ListNode(1, ListNode(2, ListNode(3, ListNode(4, ListNode(5)))))
h2 = ListNode(1, ListNode(2))
h3 = None

s = Solution()

# print(f"[5, 4, 3, 2, 1]\n{to_list(s.reverse_list_recursive(h1))}")
# print(f"[2, 1]\n{to_list(s.reverse_list_recursive(h2))}")
# print(f"[]\n{to_list(s.reverse_list_recursive(h3))}")


# print(f"[5, 4, 3, 2, 1]\n{to_list(s.reverse_list_iterative(h1))}")
# print(f"[2, 1]\n{to_list(s.reverse_list_iterative(h2))}")
# print(f"[]\n{to_list(s.reverse_list_iterative(h3))}")



print(f"[5, 4, 3, 2, 1]\n{to_list(s.reverse_list_recursive_gpt(h1))}")
print(f"[2, 1]\n{to_list(s.reverse_list_recursive_gpt(h2))}")
print(f"[]\n{to_list(s.reverse_list_recursive_gpt(h3))}")
