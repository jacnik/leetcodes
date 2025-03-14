/*
Leetcode: https://leetcode.com/problems/search-in-rotated-sorted-array-ii

There is an integer array nums sorted in non-decreasing order (not necessarily with distinct values).

Before being passed to your function, nums is rotated at an unknown pivot index k (0 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed).
For example, [0,1,2,4,4,4,5,6,6,7] might be rotated at pivot index 5 and become [4,5,6,6,7,0,1,2,4,4].

Given the array nums after the rotation and an integer target, return true if target is in nums, or false if it is not in nums.

You must decrease the overall operation steps as much as possible.



Example 1:

Input: nums = [2,5,6,0,0,1,2], target = 0
Output: true
Example 2:

Input: nums = [2,5,6,0,0,1,2], target = 3
Output: false


Constraints:

1 <= nums.length <= 5000
-104 <= nums[i] <= 104
nums is guaranteed to be rotated at some pivot.
-104 <= target <= 104
*/

static bool Search_First_attempt(int[] nums, int target)
{
    int l = 0, r = nums.Length-1;

    while (l <= r)
    {
        var m = l + (r-l)/2;
        if (nums[m] == target) return true;

        if (nums[l] == nums[m])
        {
            l++;
            continue;
        }
        if (nums[m] == nums[r])
        {
            r--;
            continue;
        }

        if (nums[l] <= nums[m]) // left side is sorted
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
        else // right side is sorted
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

    return false;
}


static bool Search(int[] nums, int target)
{
    /* this solution was with the help of the editorial. Simplifies the previous one slightly.*/
    int l = 0, r = nums.Length-1;

    while (l <= r)
    {
        var m = l + (r-l)/2;
        if (nums[m] == target) return true;

        if (nums[l] < nums[m]) // left side is sorted
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
        else if (nums[l] > nums[m]) // right side is sorted
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
        else
        {
            l++;
        }
    }

    return false;
}

/*
[0,1,1,1,1]
[1,1,1,1,0]
[1,1,1,0,1]
[1,1,0,1,1]
[1,0,1,1,1]
[0,1,1,1,1]

*/
Console.WriteLine($"{Search([2,5,6,0,0,1,2], 0)}");
Console.WriteLine($"{Search([2,5,6,0,0,1,2], 3) == false}");
Console.WriteLine($"{Search([1,0,1,1,1], 0)}");


