"""
Given an integer array nums, return the length of the longest strictly increasing subsequence.

A subsequence is a sequence that can be derived from an array by deleting some or no elements without changing the order of the remaining elements. For example, [3,6,2,7] is a subsequence of the array [0,3,1,6,2,2,7].


Example 1:

    Input: nums = [10,9,2,5,3,7,101,18]
    Output: 4
    Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.

Example 2:

    Input: nums = [0,1,0,3,2,3]
    Output: 4

Example 3:

    Input: nums = [7,7,7,7,7,7,7]
    Output: 1


Constraints:

1 <= nums.length <= 2500
-104 <= nums[i] <= 104


Solution:
1.
    for each value left of i find max of all values smaller then i and add 1
    ex:
    [10, 9, 2,              5, 3, 7, 101, 18]
    [ 1, 1, 1, val(2) + 1 = 2, ...]

    [10, 9, 2, 5,              3, 7, 101, 18]
    [ 1, 1, 1, 2, val(2) + 1 = 2, ...]

    [10, 9, 2, 5, 3,                   7, 101, 18]
    [ 1, 1, 1, 2, 2, val(5 or 3) + 1 = 3, ...]

    [10, 9, 2, 5, 3, 7,            101, 18]
    [ 1, 1, 1, 2, 2, 3, val(7) + 1 = 4,...]

    [10, 9, 2, 5, 3, 7, 101,             18]
    [ 1, 1, 1, 2, 2, 3,   4, val(7) + 1 = 4]

    end: [ 1, 1, 1, 2, 2, 3, 4, 4]
2.
    Keep sorted list of subsequence, while iterating over nums binary search over subsequence to get index of next num.
    If index is inside subsequence, replace existing element.
    If index is bigger then len of subsequence, add num to subsequenece.
    ex:
    subs = [0]
    nums = [0, 1, 0, 3, 2, 3]
            ^
    index = 0 -> replace subs[0] with 0

    subs = [0]
    nums = [0, 1, 0, 3, 2, 3]
               ^
    index = 1 -> add 1 to subs

    subs = [0, 1]
    nums = [0, 1, 0, 3, 2, 3]
                  ^
    index = 0 -> replace subs[0] with 0

    subs = [0, 1]
    nums = [0, 1, 0, 3, 2, 3]
                     ^
    index = 2 -> add 3 to subs

    subs = [0, 1, 3]
    nums = [0, 1, 0, 3, 2, 3]
                        ^
    index = 2 -> replace subs[2] with 2

    subs = [0, 1, 2]
    nums = [0, 1, 0, 3, 2, 3]
                           ^
    index = 3 -> add 3 to subs

    subs = [0, 1, 2, 3]
    return len(subs)s
"""
import unittest

class Solution:
    def lengthOfLIS(self, nums: list[int]) -> int:
        """
        O(n*log(n)) time and O(n) space.
        Keep sorted list of subsequence, while iterating over nums binary search over subsequence to get index of next num.
        If index is inside subsequence, replace existing element.
        If index is bigger then len of subsequence, add num to subsequenece.
        """
        def get_sorted_pos(arr: list[int], num: int) -> int:
            """Binary search arr for position to where num should go to keep it sorted"""
            l,r = 0, len(arr) - 1
            while l <= r:
                m = (l+r) // 2
                if arr[m] >= num:
                    r = m - 1
                else:
                    l = m + 1

            return l

        subs = []
        for num in nums:
            idx = get_sorted_pos(subs, num)
            if idx >= len(subs):
                subs.append(num)
            else:
                subs[idx] = num

        return len(subs)

    def lengthOfLIS_DoubleLoop(self, nums: list[int]) -> int:
        """O(n^2) time and O(n) space"""
        intem = [1] * len(nums)
        for i in range(1, len(nums)):
            max_so_far = 0
            for j in range(i):
                if nums[j] < nums[i]:
                    max_so_far = max(max_so_far, intem[j])
            intem[i] = 1 + max_so_far

        return max(intem)


class LongestIncreasingSubsequenceTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def test_input_mixed_4(self):
        res = self.solution.lengthOfLIS([2,5,3,4])
        self.assertEqual(3, res)

    def test_input_mixed_8(self):
        res = self.solution.lengthOfLIS([10,9,2,5,3,7,101,18])
        self.assertEqual(4, res)

    def test_input_mixed_6(self):
        res = self.solution.lengthOfLIS([0,1,0,3,2,3])
        self.assertEqual(4, res)

    def test_input_another_mixed_6(self):
        res = self.solution.lengthOfLIS([10,9,2,5,3,4])
        self.assertEqual(3, res)

    def test_input_7_7s(self):
        res = self.solution.lengthOfLIS([7,7,7,7,7,7,7])
        self.assertEqual(1, res)


if __name__ == '__main__':
    unittest.main()
