// Leetcode: https://leetcode.com/problems/maximum-product-subarray/description/

static int MaxProduct_o2(int[] nums) {
    /* Nested loops implementation */
    var max = nums[0];
    for (int i = 0; i < nums.Length; ++i)
    {
        var acc = 1;
        for (int j = i; j < nums.Length; ++j)
        {
            acc *= nums[j];
            max = Math.Max(max, acc);
        }
    }

    return max;
}

static int MaxProduct_linear(int[] nums) {
    /*
        Modified Kadane's algorithm linear implementation.
        Tracks both runing max in min numbers becasue multiplying large negative number by other negative number will produce positive that should be considered in total max.
    */

    var total_max = nums[0];
    var curr_max = nums[0];
    var curr_min = nums[0];

    for (int i = 1; i < nums.Length; ++i)
    {
        var num = nums[i];

        var tmp_curr_max = curr_max;
        curr_max = Math.Max(num, Math.Max(tmp_curr_max * num, curr_min * num));
        curr_min = Math.Min(num, Math.Min(tmp_curr_max * num, curr_min * num));

        total_max = Math.Max(total_max, curr_max);
    }

    return total_max;
}

static int MaxProduct(int[] nums) {
    /*
        Two linear loops implemntation.
        Loops firs from the left and then from the right.
    */
    var total_max = nums[0];
    var curr_prod = total_max;

    for (int i = 1; i < nums.Length; ++i)
    {
        curr_prod *= nums[i];
        total_max = Math.Max(total_max, curr_prod);
        if (curr_prod == 0) curr_prod = 1;
    }

    curr_prod = 1;
    for (int i = nums.Length - 1; i >= 0; --i)
    {
        curr_prod *= nums[i];
        total_max = Math.Max(total_max, curr_prod);
        if (curr_prod == 0) curr_prod = 1;
    }

    return total_max;
}


Console.WriteLine($"Test 1: {MaxProduct([2,3,-2,4]) == 6}");
Console.WriteLine($"Test 2: {MaxProduct([-2,0,-1]) == 0}");
Console.WriteLine($"Test 3: {MaxProduct([-2,3,-4]) == 24}");
Console.WriteLine($"Test 4: {MaxProduct([1,0,-5,2,-3,8,-9])} => {2*-3*8*-9}");






