/*
Leetcode: https://leetcode.com/problems/longest-palindromic-substring/

Given a string s, return the longest palindromic substring in s.

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.


Example 2:

Input: s = "cbbd"
Output: "bb"


Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters.
*/

static string LongestPalindrome_Slow(string s) {

    int maxl = 0, maxr = 0;
    for (int m = 0; m < s.Length; ++m)
    {
        int r = s.Length - 1;
        while (m <= r)
        {
            if (IsPalindrome(s, m, r))
            {
                if (r-m > maxr-maxl)
                {
                    (maxr, maxl) = (r, m);
                }
                break;
            }
            r--;
        }

    }

    return s[maxl..(maxr+1)];

    static bool IsPalindrome(string s, int l, int r)
    {
        while (l <= r)
        {
            if (s[l] != s[r]) return false;
            l++;
            r--;
        }
        return true;
    }
}

static string LongestPalindrome(string s) {

    int maxl = 0, maxr = 0;
    for (int m = 0; m < s.Length; ++m)
    {
        int r = s.Length - 1;
        while (m <= r)
        {
            if (r-m <= maxr-maxl) break;
            if (IsPalindrome(s, m, r))
            {
                if (r-m > maxr-maxl)
                {
                    (maxr, maxl) = (r, m);
                }
                break;
            }
            r--;
        }

    }

    return s[maxl..(maxr+1)];

    static bool IsPalindrome(string s, int l, int r)
    {
        while (l <= r)
        {
            if (s[l] != s[r]) return false;
            l++;
            r--;
        }
        return true;
    }
}

Console.WriteLine(LongestPalindrome("babad") == "bab");
Console.WriteLine(LongestPalindrome("cbbd") == "bb");
Console.WriteLine(LongestPalindrome("a") == "a");
Console.WriteLine(LongestPalindrome("jglknendplocymmvwtoxvebkekzfdhykknufqdkntnqvgfbahsljkobhbxkvyictzkqjqydczuxjkgecdyhixdttxfqmgksrkyvopwprsgoszftuhawflzjyuyrujrxluhzjvbflxgcovilthvuihzttzithnsqbdxtafxrfrblulsakrahulwthhbjcslceewxfxtavljpimaqqlcbrdgtgjryjytgxljxtravwdlnrrauxplempnbfeusgtqzjtzshwieutxdytlrrqvyemlyzolhbkzhyfyttevqnfvmpqjngcnazmaagwihxrhmcibyfkccyrqwnzlzqeuenhwlzhbxqxerfifzncimwqsfatudjihtumrtjtggzleovihifxufvwqeimbxvzlxwcsknksogsbwwdlwulnetdysvsfkonggeedtshxqkgbhoscjgpiel") == "sknks");


