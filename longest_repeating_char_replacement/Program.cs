/*
Leetcode: https://leetcode.com/problems/longest-repeating-character-replacement

You are given a string s and an integer k. You can choose any character of the string and change it to any other uppercase English character. You can perform this operation at most k times.

Return the length of the longest substring containing the same letter you can get after performing the above operations.



Example 1:

Input: s = "ABAB", k = 2
Output: 4
Explanation: Replace the two 'A's with two 'B's or vice versa.
Example 2:

Input: s = "AABABBA", k = 1
Output: 4
Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
The substring "BBBB" has the longest repeating letters, which is 4.
There may exists other ways to achieve this answer too.


Constraints:

1 <= s.length <= 105
s consists of only uppercase English letters.
0 <= k <= s.length

*/

static int CharacterReplacement_SLOW(string s, int k) {

    var max = 1;
    int b = 0, e = 1;
    var win = new int['Z' - 'A' + 1];
    win[0] = 1;

    var win_sum = 1;

    while (b < e && e < s.Length)
    {
        if(win_sum - win.Max() > k)
        {
            --win['Z' - s[b]];
            b++;
        }
        else
        {
            max = Math.Max(max, win_sum);
            ++win['Z' - s[e]];
            e++;
        }
        win_sum = e - b;
    }

    if(win_sum - win.Max() <= k)
    {
        max = Math.Max(max, win_sum);
    }

    return max;
}


static int CharacterReplacement_MYFAST(string s, int k) {

    var max = 1;
    int b = 0;
    Span<int> win_freq = stackalloc int['Z' - 'A' + 1];
    win_freq['Z' - s[b]] = 1;

    int win_sum = 1;
    int win_max_i = 1;
    for (int e = 1; e < s.Length; ++e)
    {
        ++win_freq['Z' - s[e]];
        win_max_i = win_freq['Z' - s[e]] > win_freq[win_max_i] ? 'Z' - s[e] : win_max_i;
        win_sum++;


        if(win_sum - win_freq[win_max_i] <= k)
        {
            max = Math.Max(max, win_sum);
        }
        else
        {
            while (win_sum - win_freq[win_max_i] > k)
            {
                var win_idx = 'Z' - s[b];
                --win_freq[win_idx];
                b++;
                win_sum--;
                if (win_idx == win_max_i)
                {
                    for (int wi = 0; wi < win_freq.Length; ++wi)
                    {
                        if (win_freq[wi] > win_freq[win_max_i])
                        {
                            win_max_i = wi;
                        }
                    }
                }
            }
        }
    }

    return max;
}

static int CharacterReplacement_Fast_Simplified(string s, int k)
{
    /* Fast and simplified. based on solution from the comments */

    var max_so_far = 1;
    int b = 0;
    Span<int> win_freq = stackalloc int['Z' - 'A' + 1];

    int max_freq = 1;

    for (int e = 0; e < s.Length; ++e)
    {
        ++win_freq['Z' - s[e]];
        max_freq = Math.Max(max_freq, win_freq['Z' - s[e]]);

        while (e - b + 1 - max_freq > k)
        {
            --win_freq['Z' - s[b]];
            b++;

            foreach (var freq in win_freq)
            {
                max_freq = Math.Max(max_freq, freq);
            }
        }

        max_so_far = Math.Max(max_so_far, e - b + 1);
    }

    return max_so_far;
}


static int CharacterReplacement(string s, int k)
{
    /*
    Fast and simplified. based on solution from the comments.
    Removed the linear search for the max frequency.
    Added chars as span to see if it improves the lookups
    */

    ReadOnlySpan<char> chars = s.AsSpan();

    var max_so_far = 0;
    int b = 0;
    Span<int> win_freq = stackalloc int['Z' - 'A' + 1];

    int max_freq = 1;

    for (int e = 0; e < chars.Length; ++e)
    {
        ++win_freq[chars[e] - 'A'];
        max_freq = Math.Max(max_freq, win_freq[chars[e] - 'A']);

        while (e - b + 1 - max_freq > k)
        {
            --win_freq[chars[b] - 'A'];
            b++;
        }

        max_so_far = Math.Max(max_so_far, e - b + 1);
    }

    return max_so_far;
}


Console.WriteLine(CharacterReplacement("ABAB", 2) == 4); // bBbB
Console.WriteLine(CharacterReplacement("AABABBA", 1) == 4); // AABbBBA

Console.WriteLine(CharacterReplacement("AABABBCCCC", 1) == 5); // AABABcCCCC

Console.WriteLine(CharacterReplacement("AABABBCCCC", 3) == 7); // AABcccCCCC
Console.WriteLine(CharacterReplacement("ABABBCCC", 2) == 5); // ABBBBBCC

Console.WriteLine(CharacterReplacement("AAOOOOXXIIIXIIIXIII", 2) == 11); // AAOOOOXXIIIiIIIiIII


