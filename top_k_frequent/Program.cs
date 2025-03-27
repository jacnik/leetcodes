/*
Leetcode: https://leetcode.com/problems/top-k-frequent-elements/description/

Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.



Example 1:

Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]

Example 2:

Input: nums = [1], k = 1
Output: [1]



Constraints:

    1 <= nums.length <= 105
    -104 <= nums[i] <= 104
    k is in the range [1, the number of unique elements in the array].
    It is guaranteed that the answer is unique.



Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.

*/

static int[] TopKFrequent(int[] nums, int k) {
    Dictionary<int, int> freq = [];

    foreach(var num in nums)
    {
        var f = freq.GetValueOrDefault(num, 0);
        freq[num] = f+1;
    }

    PriorityQueue<int, int> priority = new(Comparer<int>.Create((a, b) => b - a));

    foreach(var kv in freq)
    {
        priority.Enqueue(kv.Key, kv.Value);
    }

    int[] res = new int[k];

    for (int i = 0; i < k; i++)
    {
        res[i] = priority.Dequeue();
    }
    return res;
}

static string PrintArr(int[] arr)
{
    return string.Join(',', arr);
}

Console.WriteLine($"{PrintArr(TopKFrequent([1,1,1,2,2,3], 2))}\n{PrintArr([1,2])}");
Console.WriteLine($"{PrintArr(TopKFrequent([1], 1))}\n{PrintArr([1])}");
