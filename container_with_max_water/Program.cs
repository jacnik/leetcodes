// Leetcode: https://leetcode.com/problems/container-with-most-water


int Area(int h1, int h2, int d)
{
    return Math.Min(h1, h2) * d;
}

int MaxArea_nice(int[] height)
{
    /* Nicer but a but minimally slower version */
    var max_so_far = 0;

    var l = 0;
    var r = height.Length - 1;

    while (l < r)
    {
        var area = Area(height[l], height[r], r - l);
        max_so_far = Math.Max(max_so_far, area);

        if (height[l] < height[r])
        {
            l++;
        }
        else
        {
            r--;
        }
    }

    return max_so_far;
}

int MaxArea(int[] height) {
    /* Slightly faster vaerion */
    var max_so_far = 0;

    var l = 0;
    var r = height.Length - 1;

    var min_heigth_to_look_for = 0;
    while (l < r)
    {
        if (height[l] <= min_heigth_to_look_for)
        {
            l++;
            continue;
        }
        if (height[r] <= min_heigth_to_look_for)
        {
            r--;
            continue;
        }

        min_heigth_to_look_for = Math.Min(height[l], height[r]);
        var area = min_heigth_to_look_for * (r - l);
        max_so_far = Math.Max(max_so_far, area);
    }

    return max_so_far;
}


Console.WriteLine($"{MaxArea([1,8,6,2,5,4,8,3,7]) == 49}");
Console.WriteLine($"{MaxArea([1,1]) == 1}");
Console.WriteLine($"{MaxArea([1,1,1,1,1,6]) == 5}");

