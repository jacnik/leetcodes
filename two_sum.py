"""
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

Example 1:

    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:

    Input: nums = [3,2,4], target = 6
    Output: [1,2]

Example 3:

    Input: nums = [3,3], target = 6
    Output: [0,1]

Solution:
Use dictionary to add pair of value, index for each value in input -> O(n) scan, O(n) memory
Scan array again for each value checking in dictionary if compliment value (target - value) exists, if it does that value and it's compliment are the solution. -> O(n) list scan + O(1) dictionary lookup, O(1) memory
Additionally check if index returned from dictionary is not the same as current index.
"""
import unittest

class Solution(object):
    def twoSum(self, nums: list[int], target: int) -> list[int]:
        compliments = dict((v,i) for i,v in enumerate(nums))
        for i,v in enumerate(nums):
            if (cmp_i := compliments.get(target - v, i)) != i:
                 return [i, cmp_i]

        return []



class TwoSumTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def test_input_01(self):
        res = self.solution.twoSum([1,3,4,2], 6)
        self.assertListEqual([2,3], res)

    def test_input_02(self):
        res = self.solution.twoSum([2,7,11,15], 9)
        self.assertListEqual([0,1], res)

    def test_input_03(self):
        res = self.solution.twoSum([3,2,4], 6)
        self.assertListEqual([1, 2], res)

    def test_input_04(self):
        res = self.solution.twoSum([3,3], 6)
        self.assertListEqual([0,1], res)

if __name__ == '__main__':
    unittest.main()

