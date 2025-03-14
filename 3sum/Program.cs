/*
Leetcode: https://leetcode.com/problems/3sum/

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.



Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation:
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.
Example 2:

Input: nums = [0,1,1]
Output: []
Explanation: The only possible triplet does not sum up to 0.
Example 3:

Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: The only possible triplet sums up to 0.


Constraints:

3 <= nums.length <= 3000
-105 <= nums[i] <= 105

*/

static (int a, int b, int c) Sort(int a, int b, int c)
{
/*
    (a, b, c)
    (a, c, b)

    (b, a, c)
    (b, c, a)

    (c, a, b)
    (c, b, a)
*/
    if (a <= b && a <= c)
    {
        if (b < c) return (a, b, c);
        return (a, c, b);
    }
    if (b <= a && b <= c)
    {
        if (a < c) return (b, a, c);
        return (b, c, a);
    }

    if (c <= a && c <= b)
    {
        if (a < b) return (c, a, b);
        return (c, b, a);
    }

    return (a, b, c);
}

static IList<IList<int>> ThreeSum_WithHashSets(int[] nums) {

    /* This implementatino uses a hash set to eliminate duplicates */
    HashSet<int> visited = [nums[0]];
    HashSet<(int a, int b, int c)> triplets = [];

    for (int ai = 1; ai < nums.Length; ++ai)
    {
        var a = nums[ai];
        for (int bi = ai + 1; bi < nums.Length; ++bi)
        {
            var b = nums[bi];
            var c = -1*(a+b);
            if (visited.Contains(c))
            {
                triplets.Add(Sort(a, b, c));
            }
        }

        visited.Add(a);
    }

    return [.. triplets.Select(t => new List<int>() {t.a, t.b, t.c})];
}



static void Swap( int[] nums, int i, int j)
{
    (nums[j], nums[i]) = (nums[i], nums[j]);
}

static int Partition( int[] nums, int lo, int hi)
{
    var pivot = nums[lo];

    var l = lo - 1;
    var r = hi + 1;

    while (l < r) {
        while (nums[++l] < pivot);
        while (nums[--r] > pivot);

        if (l >= r) return r;

        Swap(nums, l, r);
    }

    return r;
}

static void QSort(int[] nums, int lo, int hi)
{
    if (lo >= 0 && hi >= 0 && lo < hi) {
        var p = Partition(nums, lo, hi);
        QSort(nums, lo , p);
        QSort(nums, p+1, hi);
    }
}

static int BSearch(int[] nums, int look_for, int start, int end)
{
    while (start < end)
    {
        var mid = start + (end - start) / 2;
        if (nums[mid] == look_for) return mid;
        if (nums[mid] < look_for)
        {
            start = mid + 1;
        }
        else
        {
            end = mid - 1;
        }
    }
    return start;
}

static IList<IList<int>> ThreeSum_With_Binary_Sort(int[] nums) {
/*
    O(2*N)*logN approach with sorting and binary search
      a  b   look for 5
    [-4,-1,-1,0,1,2]

      a       b   look for 4
    [-4,-1,-1,0,1,2]

      a         b   look for 3
    [-4,-1,-1,0,1,2]

      a           b   skip
    [-4,-1,-1,0,1,2]

         a  b       look for 2 => (-1, -1, 2)
    [-4,-1,-1,0,1,2]

         a    b       look for 1 => (-1, 0, 1)
    [-4,-1,-1,0,1,2]

         a      b       look for 0 but since b > 0 move a to new different number
    [-4,-1,-1,0,1,2]

              a b      look for -1 but b > -1 skip
    [-4,-1,-1,0,1,2]
*/
    QSort(nums, 0, nums.Length - 1);
    List<IList<int>> res = [];

    for (int ai = 0; ai < nums.Length - 2; ++ai)
    {
        var a = nums[ai];
        for (int bi = ai + 1; bi < nums.Length - 1; ++bi)
        {
            var b = nums[bi];
            var c = -1*(a+b);

            if (b > c) break;

            var ci = BSearch(nums, c, bi+1, nums.Length - 1);

            if (nums[ci] == c)
            {
                res.Add([a, b, c]);
            }
            while (bi < nums.Length - 2 && nums[bi] == nums[bi + 1]) bi++;

        }
        while (ai < nums.Length - 3 && nums[ai] == nums[ai + 1]) ai++;
    }

    return res;
}


static IList<IList<int>> ThreeSum(int[] nums)
{
    QSort(nums, 0, nums.Length - 1);
    List<IList<int>> res = [];

    for (int ia = 0; ia < nums.Length - 1; ++ia)
    {
        var a = nums[ia];
        if (ia > 0 && a == nums[ia - 1]) continue;
        var l = ia + 1;
        var r = nums.Length - 1;
        while (l < r)
        {
            if (a + nums[l] + nums[r] == 0)
            {
                res.Add([a, nums[l], nums[r]]);
            }

            if (a + nums[l] + nums[r] > 0)
            {
                r--;
            }
            else
            {
                while(nums[l] == nums[++l] && l < r);
            }
        }
    }

    return res;
}

static string PrintRes(IList<IList<int>> res)
{
    return $"""[{string.Join(',',
        res.Select(l =>  $"[{string.Join(',', l)}]"))}]""";
}

Console.WriteLine($"{PrintRes(ThreeSum([-1,0,1,2,-1,-4]))}\n{PrintRes([[-1,-1,2],[-1,0,1]])}\n\n");
Console.WriteLine($"{PrintRes(ThreeSum([2,-1,0,1,-1,-4]))}\n{PrintRes([[-1,-1,2],[-1,0,1]])}\n\n");

Console.WriteLine($"{PrintRes(ThreeSum([0,1,1]))}\n{PrintRes([])}\n\n");
Console.WriteLine($"{PrintRes(ThreeSum([0,0,0]))}\n{PrintRes([[0,0,0]])}\n\n");
Console.WriteLine($"{PrintRes(ThreeSum([0,0,0,0,0]))}\n{PrintRes([[0,0,0]])}\n\n");
Console.WriteLine($"{PrintRes(ThreeSum([1,2,-2,-1]))}\n{PrintRes([])}\n\n");

Console.WriteLine($"{PrintRes(ThreeSum([2,-3,0,-2,-5,-5,-4,1,2,-2,2,0,2,-4,5,5,-10]))}\n{PrintRes([[-10,5,5],[-5,0,5],[-4,2,2],[-3,-2,5],[-3,1,2],[-2,0,2]])}\n\n");




