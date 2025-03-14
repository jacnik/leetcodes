
/*
Solution to https://leetcode.com/problems/two-sum/description/
*/
static int[] TwoSum(int[] nums, int target)
{
    // value => index
    Dictionary<int, int> seen = [];
    for(int i = 0; i < nums.Length; ++i)
    {
        var num = nums[i];
        if (seen.ContainsKey(target - num))
        {
            return [seen[target - num], i];
        }
        seen.Add(num, i);
    }
    return [];
}

var tcA = TwoSum([2,7,11,15], 9);
var tcB = TwoSum([3,2,4], 6);
var tcC = TwoSum([3,3], 6);


Console.WriteLine($"Test case A: {ResToString(tcA)} => {ResToString([0,1])}");
Console.WriteLine($"Test case B: {ResToString(tcB)} => {ResToString([1,2])}");
Console.WriteLine($"Test case C: {ResToString(tcC)} => {ResToString([0,1])}");


static string ResToString(int[] nums)
{
    return $"[{string.Join(',', nums)}]";
}


