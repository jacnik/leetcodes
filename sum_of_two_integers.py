"""
Given two integers a and b, return the sum of the two integers without using the operators + and -.

Example 1:

    Input: a = 1, b = 2
    Output: 3

Example 2:

    Input: a = 2, b = 3
    Output: 5

Constraints:
    -1000 <= a, b <= 1000

Solution:
Bit hack:

_______
a = 1 = 001
b = 2 = 010
    3 = 011
In this case the solution is a xor b. This is because a & b == 0.

_______
a = 2 = 010
b = 3 = 011
    5 = 101
Here 1 must be carried one bit left before xor. This is because a & b != 0.
c = a&b  = 010
a = a^b  = 001
b = c<<1 = 100
After this step a&b == 0. Therefore the result is a xor b = 101.

_______
a = 10 = 1010
b =  3 = 0011
    13 = 1101
Here 1 must be carried one bit left before xor. This is because a & b != 0.
c = a&b  = 0010
a = a^b  = 1001
b = c<<1 = 0100
After this step a&b == 0. Therefore the result is a xor b = 1101.

_______
a = 6 = 0110
b = 3 = 0011
c = 9 = 1001
Here a & b != 0 -> It needs to be shifted left
c = a&b  = 0010
a = a^b  = 0101
b = c<<1 = 0100
After this step a & b != 0 -> It needs to be shifted left again
c = a&b  = 0100
a = a^b  = 0001
b = c<<1 = 1000
After this step a & b == 0 -> Result is a ^ b == 1001


----
Because python uses infinite bit ints (not 32 or 64) special mask set to 32 '1s' bits has to be used to crop the result back to 32 bits.
Because constraints for the problem are -1000 < a,b < +1000 mask can be smaller - 16 '1s'.
"""
import unittest


class Solution:
    def getSum(self, a: int, b: int) -> int:
        mask = 0xffff
        while b & mask:
            c = a&b
            a = a^b
            b = c<<1

        return a & mask if b else a


class SumOfTwoIntegersTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def test_positive_and_positive(self):
        for a, b in [(1, 2), (2, 3), (6, 3)]:
            res = self.solution.getSum(a,b)
            self.assertEqual(a+b, res)

    def test_negative_and_positive(self):
        for a, b in [(-1, 1), (-2, 3), (-1000, +1000)]:
            res = self.solution.getSum(a,b)
            self.assertEqual(a+b, res)

    def test_negative_and_negative(self):
        for a, b in [(-2, -3), (-1000, -1000)]:
            res = self.solution.getSum(a,b)
            self.assertEqual(a+b, res)

    def test_zero_and_negative(self):
        a, b = 0, -11
        res = self.solution.getSum(a,b)
        self.assertEqual(a+b, res)

    def test_zero_and_positive(self):
        a, b = 0, 55
        res = self.solution.getSum(a,b)
        self.assertEqual(a+b, res)

    def test_zero_and_zero(self):
        a, b = 0, 0
        res = self.solution.getSum(a,b)
        self.assertEqual(a+b, res)

    # def test_exhaustively_all_input_space(self):
    #  # Comment out because runs for too long
    #     for a in range(-1000, 1001):
    #         for b in range(-1000, 1001):
    #             res = self.solution.getSum(a,b)
    #             self.assertEqual(a+b, res)

if __name__ == '__main__':
    unittest.main()