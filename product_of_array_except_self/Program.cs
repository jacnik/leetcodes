// Leetcode: https://leetcode.com/problems/product-of-array-except-self/


static int[] ProductExceptSelf_Linear_Space(int[] nums)
{
    var l = new int[nums.Length];
    var r = new int[nums.Length];

    l[0] = nums[0];
    r[^1] = nums[^1];

    for (int i = 1; i < nums.Length; ++i)
    {
        l[i] = l[i-1] * nums[i];

        var ri = nums.Length - i;
        r[ri - 1] = r[ri] * nums[ri - 1];
    }

    var res = new int[nums.Length];

    res[0] = r[1];
    res[^1] = l[^2];
    for (int i = 1; i < nums.Length - 1; ++i)
    {
        res[i] = l[i-1] * r[i+1];
    }

    return res;
}

static int[] ProductExceptSelf(int[] nums)
{
    var res = Enumerable.Repeat(1, nums.Length).ToArray();
    var left_mult = 1;
    var rigth_mult = 1;

    for (int i = 0; i < nums.Length; ++i)
    {
        res[i] = res[i] * left_mult;
        res[^(i+1)] = res[^(i+1)] * rigth_mult;

        left_mult *= nums[i];
        rigth_mult *= nums[^(i+1)];

    }

    return res;
}

int[] i1 = [1,2,3,4];
int[] o1 = [24,12,8,6];

int[] i2 = [-1,1,0,-3,3];
int[] o2 = [0,0,9,0,0];

Console.WriteLine($"{PrintArr(o1)} => {PrintArr(ProductExceptSelf(i1))}");
Console.WriteLine($"{PrintArr(o2)} => {PrintArr(ProductExceptSelf(i2))}");


static string PrintArr(int[] arr)
{
    return string.Join(',', arr);
}


