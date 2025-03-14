// Leetcode: https://leetcode.com/problems/maximum-subarray/


static int MaxSubArray(int[] nums)
{
    // Kadane's algorithm
    var best_sum = nums[0];
    var curr_sum = best_sum;

    for (int i = 1; i < nums.Length; ++i)
    {
        // Decide if is better to add current number to the running sum,
        // or start a new running sum from this number
        curr_sum = Math.Max(nums[i], curr_sum + nums[i]);

        // Keep track of the best so far
        best_sum = Math.Max(best_sum, curr_sum);
    }

    return best_sum;
}

int[] i1 = [-2,1,-3,4,-1,2,1,-5,4];
int[] i2 = [1];
int[] i3 = [5,4,-1,7,8];
int[] i4 = [-5,-4,-1,-7,-8];


Console.WriteLine($"is: {MaxSubArray(i1)} => should be: {6}");
Console.WriteLine($"is: {MaxSubArray(i2)} => should be: {1}");
Console.WriteLine($"is: {MaxSubArray(i3)} => should be: {23}");
Console.WriteLine($"is: {MaxSubArray(i4)} => should be: {-1}");
