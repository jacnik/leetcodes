"""
You are climbing a staircase. It takes n steps to reach the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:

    Input: n = 2
    Output: 2
    Explanation: There are two ways to climb to the top.
    1. 1 step + 1 step
    2. 2 steps

Example 2:

    Input: n = 3
    Output: 3
    Explanation: There are three ways to climb to the top.
    1. 1 step + 1 step + 1 step
    2. 1 step + 2 steps
    3. 2 steps + 1 step


Constraints:

1 <= n <= 45
"""
import unittest
import math


class Solution:
    def climbStairs(self, n: int) -> int:
        def fib_iter(i: int, j: int, n: int) -> int:
            while n > 2:
                i,j = j,i+j
                n -= 1

            if n == 1: return i
            if n == 2: return j
            return 0

        return fib_iter(1, 2, n)

    def climbStairsFibRecur(self, n: int) -> int:
        def fib_recur(i: int, j: int, n: int) -> int:
            if n == 1: return i
            if n == 2: return j
            return fib_recur(j, i+j, n-1)

        return fib_recur(1, 2, n)

    def climbStairsDyna(self, n: int) -> int:
        interm = [0] * n
        interm[0] = 1
        if n != 1:
            interm[1] = 2
            for i in range(2, n):
                interm[i] = interm[i-1] + interm[i-2]

        return interm[n-1]

    def climbStairsRecurs(self, n: int) -> int:
        if n == 1: return 1
        if n == 2: return 2
        return self.climbStairs(n-1) + self.climbStairs(n-2)

    def climbStairsFib(self, n: int) -> int:
        def nth_fib(n: int) -> int:
            PSI = 1.61803398874989
            SQRT_5 = 2.23606797749979
            return int((math.pow(PSI, n) / SQRT_5) + 0.5)

        return nth_fib(n+1)


class ClimbingStairsTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def test_input_1(self):
        res = self.solution.climbStairs(1)
        self.assertEqual(1, res)

    def test_input_2(self):
        res = self.solution.climbStairs(2)
        self.assertEqual(2, res)

    def test_input_3(self):
        res = self.solution.climbStairs(3)
        self.assertEqual(3, res)

    def test_input_4(self):
        res = self.solution.climbStairs(4)
        self.assertEqual(5, res)

    def test_input_5(self):
        res = self.solution.climbStairs(5)
        self.assertEqual(8, res)

    def test_input_6(self):
        res = self.solution.climbStairs(6)
        self.assertEqual(13, res)

    def test_input_7(self):
        res = self.solution.climbStairs(7)
        self.assertEqual(21, res)

    def test_input_8(self):
        res = self.solution.climbStairs(8)
        self.assertEqual(34, res)

    def test_input_44(self):
        res = self.solution.climbStairs(44)
        self.assertEqual(1134903170, res)

if __name__ == '__main__':
    unittest.main()
