/*
    # Leetcode: https://leetcode.com/problems/contains-duplicate

    Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

    Example 1:

    Input: nums = [1,2,3,1]

    Output: true

    Explanation:

    The element 1 occurs at the indices 0 and 3.

    Example 2:

    Input: nums = [1,2,3,4]

    Output: false

    Explanation:

    All elements are distinct.

    Example 3:

    Input: nums = [1,1,1,3,3,4,3,2,4,2]

    Output: true



    Constraints:

    1 <= nums.length <= 105
    -109 <= nums[i] <= 109

*/


static bool ContainsDuplicate_HashSet(int[] nums)
{
    /* Run of the mill hash set implmentation*/
    var visited = new HashSet<int>();
    foreach (var num in nums)
    {
        if (visited.Contains(num)) return true;
        visited.Add(num);
    }
    return false;
}

static bool ContainsDuplicate(int[] nums)
{
    /* Clever implementatino written not by me :)*/
    for (int i = 1; i < nums.Length; i++) {
      var current = nums[i];

      var j = i - 1;

      while (j >= 0 && nums[j] > current) {
        nums[j + 1] = nums[j];
        nums[j] = current;
        j--;
      }
      if (j >= 0 && nums[j] == nums[j + 1]) {
        return true;
      }

    }
    return false;
}


Console.WriteLine($"{ContainsDuplicate([1,2,3,1]) == true}");
Console.WriteLine($"{ContainsDuplicate([1,2,3,4]) == false}");
Console.WriteLine($"{ContainsDuplicate([1,1,1,3,3,4,3,2,4,2]) == true}");

