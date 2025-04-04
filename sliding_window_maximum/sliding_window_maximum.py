r'''
Leetcode: https://leetcode.com/problems/sliding-window-maximum/

You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.

Return the max sliding window.


Example 1:

Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
Output: [3,3,5,5,6,7]
Explanation:
Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7


Example 2:

Input: nums = [1], k = 1
Output: [1]


Constraints:

1 <= nums.length <= 10^5
-10^4 <= nums[i] <= 10^4
1 <= k <= nums.length
'''
from collections import deque

import big_nums

class Solution:
    '''Solution'''
    def max_sliding_window_deque(self, nums: list[int], k: int) -> list[int]:
        '''
        Max sliding window using deque (double-ended queue)
        Queue servers as a monotonic list where element 0 is the biggest, and elements get smaller moving to the right.
        Time complexity: O(n+k)
        Space complexity: O(n+k) if result array counts, otherwise O(k)
        '''
        max_window = []
        # left most item in the queue (index 0) is the max from a window
        dq = deque()

        for i, v in enumerate(nums):
            # remove the max value if its outside of the window
            if dq and dq[0] < i-k + 1:
                dq.popleft()

            if not dq or nums[dq[0]] <= v:
                # append index of max value as the first item
                dq.clear()
            else:
                # append smaller value to the right
                while dq and nums[dq[-1]] <= v:
                    dq.pop()

            dq.append(i)
            if i >= k - 1:
                max_window.append(nums[dq[0]])

        return max_window


    def max_sliding_window_tmp_max_optim(self, nums: list[int], k: int) -> list[int]:
        '''Max sliding window with one optimization of keepint the temporaty max and only updating if the window slides off'''
        max_window = []
        max_val = nums[0]
        max_idx = 0
        # first window
        for i in range(0, k):
            v = nums[i]
            if v >= max_val:
                max_val = v
                max_idx = i

        max_window.append(max_val)
        # rest of the windows
        for i in range(k, len(nums)):
            v = nums[i]
            if v >= max_val:
                max_val = v
                max_idx = i
            if max_idx < i - k + 1:
                # linear scan to find new max and max idx
                max_val = nums[i-k + 1]
                max_idx = i-k + 1
                for j in range(i - k + 1, i + 1):
                    vtmp = nums[j]
                    if vtmp >= max_val:
                        max_val = vtmp
                        max_idx = j

            max_window.append(max_val)

        return max_window


    def max_sliding_window_brute(self, nums: list[int], k: int) -> list[int]:
        '''Max sliding window brute force edition. O(len(nums)*k) time complexity'''
        max_window = []
        for i in range(len(nums) - k + 1):
            max_window.append(max(nums[i:i+k]))
        return max_window


s = Solution()
# print([3,3,5,5,6,7], ' -> ', s.max_sliding_window_brute([1,3,-1,-3,5,3,6,7], 3))
# print([1], ' -> ', s.max_sliding_window_brute([1], 1))
# print([1, -1], ' -> ', s.max_sliding_window_brute([1,-1], 1))


# print([3,3,5,5,6,7], ' -> ', s.max_sliding_window_tmp_max_optim([1,3,-1,-3,5,3,6,7], 3))
# print([3,3,2,5,5,6,7], ' -> ', s.max_sliding_window_tmp_max_optim([1,3,-1,-3,2,5,3,6,7], 3))
# print([1], ' -> ', s.max_sliding_window_tmp_max_optim([1], 1))
# print([1, -1], ' -> ', s.max_sliding_window_tmp_max_optim([1,-1], 1))


# print([3,3,5,5,6,7], ' -> ', s.max_sliding_window_deque([1,3,-1,-3,5,3,6,7], 3))
print([3,3,2,5,5,6,7], ' -> ', s.max_sliding_window_deque([1,3,-1,-3,2,5,3,6,7], 3))
# print([1], ' -> ', s.max_sliding_window_deque([1], 1))
print([1, -1], ' -> ', s.max_sliding_window_deque([1,-1], 1))

big_res_01 = s.max_sliding_window_deque(big_nums.big_nums_01, big_nums.big_k_01)
print(big_nums.big_nums_01_validate(big_res_01))

big_res_02 = s.max_sliding_window_deque(big_nums.big_nums_02, big_nums.big_k_02)
print(big_nums.big_nums_02_validate(big_res_02))

