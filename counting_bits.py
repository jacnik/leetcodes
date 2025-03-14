"""
Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), ans[i] is the number of 1's in the binary representation of i.

Example 1:

    Input: n = 2
    Output: [0,1,1]
    Explanation:
        0 --> 0
        1 --> 1
        2 --> 10

Example 2:

    Input: n = 5
    Output: [0,1,1,2,1,2]
    Explanation:
        0 --> 0
        1 --> 1
        2 --> 10
        3 --> 11
        4 --> 100
        5 --> 101

Constraints:

    0 <= n <= 105


            1       2               3                                4
    0,  1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12, 13, 14, 15, 16, 17
   [0,  1,  1,  2,  1,  2,  2,  3,  1,  2,   2,  3,  2,  3,  3,  4,  1,  2]
        1*2         2*2            4*2                              8*2


  [0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4, 1, 2]
+ [   1, 2, 2, 3, 2, 3, 3, 4, 2, 3, 3, 4, 3, 4, 4, 5, 2, 3]

pw+ [1, 2, 2, 4, 4, 4, 4, 8, 8, 8, 8, 8, 8, 8, 8, 16, 16]

"""
from typing import Callable
import unittest
import itertools


class Solution:
    def countBits(self, n: int) -> list[int]:
        """
        Super functional dynamic programming solution
        """
        def next_offset(i:int, p:int) -> int:
            return i if 2*p == i else p

        def pw_fn(i:int) -> Callable[[int], int]:
            return lambda o: next_offset(i,o)

        def get_offset(prev_o:int, o_fn: Callable[[int], int]) -> int:
            return o_fn(prev_o)

        offset_fns = (pw_fn(i) for i in range(1, n+1))
        offsets = itertools.accumulate(offset_fns, get_offset, initial=1)

        res = [0] * (n + 1)
        for i, o in itertools.dropwhile(lambda x: x[0] == 0, enumerate(offsets, 0)):
            res[i] = res[i-o] + 1

        return res

    def countBitsFunctional(self, n: int) -> list[int]:
        """
        More functional dynamic programming solution
        """
        def pw_gen(i:int, p:int):
            while True:
                p = i if 2*p == i else p
                yield (i, p)
                i += 1

        res = [0] * (n + 1)

        for i, p in itertools.takewhile(lambda x: x[0] <= n, pw_gen(1, 1)):
            res[i] = res[i-p] + 1

        return res

    def countBitsDynamic(self, n: int) -> list[int]:
        """
        Dynamic programming solution
        """
        res = [0] * (n + 1)
        pw = 1
        for i in range(1, n+1):
            if 2 * pw == i:
                pw = i
            res[i] = res[i-pw] + 1

        return res


    def countBitsWithMap(self, n: int) -> list[int]:
        """
        Slower solution but still in O(n) time complexity
        """
        def count_1_bits(i: int) -> int:
            count = 0
            while i:
                i = i & (i - 1)
                count += 1
            return count

        return [count_1_bits(i) for i in range(n+1)]


class CountBitsTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def test_input_2(self):
        res = self.solution.countBits(2)
        self.assertListEqual([0,1,1], res)

    def test_input_5(self):
        res = self.solution.countBits(5)
        self.assertListEqual([0,1,1,2,1,2], res)

    def test_input_9(self):
        res = self.solution.countBits(9)
        self.assertListEqual([0, 1, 1, 2, 1, 2, 2, 3, 1, 2], res)

    def test_input_17(self):
        res = self.solution.countBits(17)
        self.assertListEqual([0,1,1,2,1,2,2,3,1,2,2,3,2,3,3,4,1,2], res)

    def test_input_85723(self):
        """This is just for performance testing"""
        res = self.solution.countBits(85723)
        self.assertListEqual(self.solution.countBitsDynamic(85723), res)

    def test_input_0(self):
        """This is just for performance testing"""
        res = self.solution.countBits(0)
        self.assertListEqual(self.solution.countBitsDynamic(0), res)

if __name__ == '__main__':
    unittest.main()
