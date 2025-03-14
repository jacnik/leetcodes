"""
Write a function that takes an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).

Example 1:

    Input: n = 00000000000000000000000000001011
    Output: 3
    Explanation: The input binary string 00000000000000000000000000001011 has a total of three '1' bits.

Example 2:

    Input: n = 00000000000000000000000010000000
    Output: 1
    Explanation: The input binary string 00000000000000000000000010000000 has a total of one '1' bit.

Example 3:

    Input: n = 11111111111111111111111111111101
    Output: 31
    Explanation: The input binary string 11111111111111111111111111111101 has a total of thirty one '1' bits.

Constraints:

    The input must be a binary string of length 32.


Solution:
1. While the number is not 0, and it with mask 1 (00..0001 in binary), count number of ones, right shift the number by 1 bit.
2. To turn off the rightmost 1-bit use trick explained in https://catonmat.net/low-level-bit-hacks
   y = x & (x-1)
   Count how many times you did that until number is not 0.
"""
import unittest

class Solution:
    def hammingWeight(self, n: int) -> int:
        count = 0
        while n:
            n = n & (n - 1)
            count += 1

        return count


class NumberOfOneBitsTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def test_input_01(self):
        res = self.solution.hammingWeight(0b00000000000000000000000000001011)
        self.assertEqual(3, res)

    def test_input_02(self):
        res = self.solution.hammingWeight(0b00000000000000000000000010000000)
        self.assertEqual(1, res)

    def test_input_03(self):
        res = self.solution.hammingWeight(0b11111111111111111111111111111101)
        self.assertEqual(31, res)


if __name__ == '__main__':
    unittest.main()
