r'''
Leetcode: https://leetcode.com/problems/merge-two-sorted-lists/

You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.

Example 1:
 1 -> 2 -> 4
 1 -> 3 -> 4
 ----------
 1 -> 1 -> 2 -> 3 -> 4 -> 4

Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]

Example 2:

Input: list1 = [], list2 = []
Output: []

Example 3:

Input: list1 = [], list2 = [0]
Output: [0]


Constraints:

The number of nodes in both lists is in the range [0, 50].
-100 <= Node.val <= 100
Both list1 and list2 are sorted in non-decreasing order.
'''


class ListNode:
    '''Definition for singly-linked list.'''
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    """Solution"""
    def merge_two_lists_recur(self, list1: ListNode | None, list2: ListNode | None) -> ListNode | None:
        '''Merges two sorted linked lists recursively'''
        if not list1:
            return list2
        if not list2:
            return list1

        if list1.val < list2.val:
            list1.next = self.merge_two_lists_recur(list1.next, list2)
            return list1

        list2.next = self.merge_two_lists_recur(list1, list2.next)
        return list2


    def merge_two_lists_iter_with_dummy(self, list1: ListNode | None, list2: ListNode | None) -> ListNode | None:
        '''Merges two sorted linked lists iteratively using dummy node to sinplyfy egde cases'''
        dummy = ListNode()
        current = dummy
        while list1 and list2:
            if list1.val < list2.val:
                current.next = list1
                list1 = list1.next
            else:
                current.next = list2
                list2 = list2.next
            current = current.next

        if list1:
            current.next = list1
        if list2:
            current.next = list2

        return dummy.next

    def merge_two_lists_iter(self, list1: ListNode | None, list2: ListNode | None) -> ListNode | None:
        '''Merges two sorted linked lists iteratively'''
        if not list1:
            return list2
        if not list2:
            return list1

        last = list1
        if list1.val < list2.val:
            list1 = list1.next
        else:
            last = list2
            list2 = list2.next

        head = last
        while list1 and list2:
            if list1.val < list2.val:
                last.next = list1
                list1 = list1.next
            else:
                last.next = list2
                list2 = list2.next
            last = last.next

        if list1:
            last.next = list1
        if list2:
            last.next = list2

        return head


def to_list(l: ListNode | None) -> list[int]:
    """Linked list to regular list"""
    res = []
    while l:
        res.append(l.val)
        l = l.next
    return res


ll1 = ListNode(1, ListNode(2, ListNode(4)))
ll2 = ListNode(1, ListNode(3, ListNode(4)))

s = Solution()
print([1,1,2,3,4,4], to_list(s.merge_two_lists_iter(ll1, ll2)))
print([], to_list(s.merge_two_lists_iter(None, None)))
print([0], to_list(s.merge_two_lists_iter(None, ListNode(0))))
print([1, 2], to_list(s.merge_two_lists_iter(ListNode(2), ListNode(1))))


# Previous linked lists where modified during merging
ll3 = ListNode(1, ListNode(2, ListNode(4)))
ll4 = ListNode(1, ListNode(3, ListNode(4)))

print([1,1,2,3,4,4], to_list(s.merge_two_lists_iter_with_dummy(ll3, ll4)))
print([], to_list(s.merge_two_lists_iter_with_dummy(None, None)))
print([0], to_list(s.merge_two_lists_iter_with_dummy(None, ListNode(0))))
print([1, 2], to_list(s.merge_two_lists_iter_with_dummy(ListNode(2), ListNode(1))))

# Previous linked lists where modified during merging
ll5 = ListNode(1, ListNode(2, ListNode(4)))
ll6 = ListNode(1, ListNode(3, ListNode(4)))

print([1,1,2,3,4,4], to_list(s.merge_two_lists_recur(ll5, ll6)))
print([], to_list(s.merge_two_lists_recur(None, None)))
print([0], to_list(s.merge_two_lists_recur(None, ListNode(0))))
print([1, 2], to_list(s.merge_two_lists_recur(ListNode(2), ListNode(1))))

