"""
Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

You must write an algorithm that runs in O(n) time and without using the division operation.



Example 1:

    Input: nums = [1,2,3,4]
    Output: [24,12,8,6]

Example 2:

    Input: nums = [-1,1,0,-3,3]
    Output: [0,0,9,0,0]


Constraints:

    2 <= nums.length <= 105
    -30 <= nums[i] <= 30
    The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.


Solution:
    the solution at index i is the product of all elements left of i and all elements right of i:
    [..., i = multipy all on left * right ,... ]

1. Create two arrays one with running multiple from left, second with running multiple from right. O(2*n) scan, O(n) memory.
   On third iteration result at index i is the multiple of left_multiplications[i-1] * right_multiplications[i+1]. O(n) scan, O(n) memory.

2. Improvment to previous approach is to keep running multiples from left and right. O(1) time and O(1) space.
   Create result array with same size as input, initialized with 1's. O(n) time and O(n) space.
   On 1 iteration over result, keep 2 pointers from beginning and end. Update result[beginning] with left_multiply and result[end] with right_multiply. O(n) time and O(1) space.
   Move beginning pointer to next element, end pointer to previous element. Update left and right running multiples. O(1) time and O(1) space.

"""
import unittest

class Solution:
    def productExceptSelf(self, nums: list[int]) -> list[int]:
        res = [1] * len(nums)
        l_mult, r_mult = 1, 1

        for l,r in zip(range(0, len(nums)), range(len(nums)-1, -1, -1)):
            res[l] = res[l] * l_mult
            res[r] = res[r] * r_mult

            l_mult *= nums[l]
            r_mult *= nums[r]

        return res


class ProductExceptSelfTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def test_input_01(self):
        res = self.solution.productExceptSelf([ 1, 2, 3,  4])
        self.assertListEqual([24, 12, 8, 6], res)

    def test_input_02(self):
        res = self.solution.productExceptSelf([-1, 1, 0, -3, 3] )
        self.assertListEqual([ 0,  0, 9, 0, 0], res)


if __name__ == '__main__':
    unittest.main()
