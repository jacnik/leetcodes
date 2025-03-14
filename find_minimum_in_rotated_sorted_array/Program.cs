// Leetcode: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/


static int FindMin(int[] nums) {
    //           V
    // [0 ,1 ,2 ,4 ,5 ,6 ,7] ^ | ^
    // [7 ,0 ,1 ,2 ,4 ,5 ,6] V | ^
    // [6 ,7 ,0 ,1 ,2 ,4 ,5] V | ^
    // [5 ,6 ,7 ,0 ,1 ,2 ,4] V | ^
    // [4 ,5 ,6 ,7 ,0 ,1 ,2] ^ | V
    // [2 ,4 ,5 ,6 ,7 ,0 ,1] ^ | V
    // [1 ,2 ,4 ,5 ,6 ,7 ,0] ^ | V

    //          V
    // [1  ,11  ,23  ,115,217] ^ | ^
    // [217,1   ,11  ,23 ,115] V | ^
    // [115,217 ,1   ,11 ,23 ] V | ^
    // [23 ,115 ,217 ,1  ,11 ] ^ | V
    // [11 ,23  ,115 ,217,1  ] ^ | V


    var l = 0;
    var r = nums.Length - 1;

    while (l < r)
    {
        int m = l + (r - l) / 2;
        if (nums[m] > nums[r])
        {
            l = m + 1;
        }
        else
        {
            r = m;
        }

    }

    return nums[l];
}

//  l        m        r
// [4 ,5 ,6 ,7 ,0 ,1 ,2]

// m > r
//              l  m  r
// [4 ,5 ,6 ,7 ,0 ,1 ,2]

// m < r
//              m
//              l  r
// [4 ,5 ,6 ,7 ,0 ,1 ,2]

// m < r
//              r
//              l
// [4 ,5 ,6 ,7 ,0 ,1 ,2]



Console.WriteLine($"Test 1: {FindMin([3,4,5,1,2]) == 1}");
Console.WriteLine($"Test 2: {FindMin([4,5,6,7,0,1,2]) == 0}");
Console.WriteLine($"Test 3: {FindMin([11,13,15,17]) == 11}");

