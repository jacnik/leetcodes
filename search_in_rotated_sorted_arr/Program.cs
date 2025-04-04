﻿/*
Leetcode: https://leetcode.com/problems/search-in-rotated-sorted-array

There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.



Example 1:

Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4
Example 2:

Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1
Example 3:

Input: nums = [1], target = 0
Output: -1


Constraints:

1 <= nums.length <= 5000
-104 <= nums[i] <= 104
All values of nums are unique.
nums is an ascending array that is possibly rotated.
-104 <= target <= 104

*/


static int Search(int[] nums, int target)
{
    var l = 0;
    var r = nums.Length - 1;

    while (l <= r)
    {
        var m = l + (r - l) / 2;
        if (nums[m] == target) return m;

        if (nums[l] <= nums[m]) // left half is sorted
        {
            if (nums[l] <= target && target < nums[m])
            {
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }
        else // right half is sorted
        {
            if (nums[m] < target && target <= nums[r])
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }
    }

    return -1;
}

Console.WriteLine($"{Search([4,5,6,7,0,1,2], 0) == 4}");
Console.WriteLine($"{Search([4,5,6,7,0,1,2], 3) == -1}");
Console.WriteLine($"{Search([1], 0) == -1}");
Console.WriteLine($"{Search([1], 1) == 0}");
Console.WriteLine($"{Search([6,7,1,2,3,4,5], 7) == 1}");
Console.WriteLine($"{Search([1,3], 3) == 1}");
Console.WriteLine($"{Search([3,1], 1) == 1}");



