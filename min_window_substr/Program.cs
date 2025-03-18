/*

Leetcode: https://leetcode.com/problems/minimum-window-substring/description/

Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window.
If there is no such substring, return the empty string "".

The testcases will be generated such that the answer is unique.



Example 1:

Input: s = "ADOBECODEBANC", t = "ABC"
Output: "BANC"
Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
Example 2:

Input: s = "a", t = "a"
Output: "a"
Explanation: The entire string s is the minimum window.
Example 3:

Input: s = "a", t = "aa"
Output: ""
Explanation: Both 'a's from t must be included in the window.
Since the largest window of s only has one 'a', return empty string.


Constraints:

m == s.length
n == t.length
1 <= m, n <= 105
s and t consist of uppercase and lowercase English letters.


Follow up: Could you find an algorithm that runs in O(m + n) time?
*/


using System.ComponentModel;

static string MinWindow_Slow(string s, string t)
{
    Dictionary<char, int> freq = t.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

    int l = 0, r = 0;
    int minl = 0, minr = 0;

    while (true)
    {
        if (freq.Values.All(f => f <= 0))
        {
            if (minr == 0 || r - l < minr - minl)
            {
                (minr, minl) = (r, l);
            }

            if (freq.TryGetValue(s[l], out var lv))
            {
                freq[s[l]]++;
            }
            l++;
        }
        else
        {
            if (r == s.Length) break;
            if (freq.TryGetValue(s[r], out var rv))
            {
                freq[s[r]] = --rv;
            }

            r++;
        }
    }

    return s[minl..minr];
}


static string MinWindow(string s, string t)
{
    Dictionary<char, int> freq = t.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

    int l = 0, r = 0;
    int minl = 0, minr = 0;
    int need_count = t.Length;
    int have_count = 0;

    while (true)
    {
        if (have_count >= need_count)
        {
            if (minr == 0 || r - l < minr - minl)
            {
                (minr, minl) = (r, l);
            }

            if (freq.TryGetValue(s[l], out var lv))
            {
                freq[s[l]] = ++lv;

                if (lv > 0) have_count--;
            }
            l++;
        }
        else
        {
            if (r == s.Length) break;
            if (freq.TryGetValue(s[r], out var rv))
            {
                if (rv > 0) have_count++;
                freq[s[r]] = --rv;
            }

            r++;
        }
    }

    return s[minl..minr];
}


Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC") == "BANC");
Console.WriteLine(MinWindow("a", "a") == "a");
Console.WriteLine(MinWindow("a", "aa") == "");
Console.WriteLine(MinWindow("ab", "A") == "");
Console.WriteLine(MinWindow("cabwefgewcwaefgcf", "cae") == "cwae");
Console.WriteLine(MinWindow("aaaaaaaaaaaabbbbbcdd", "abcdd") == "abbbbbcdd");

