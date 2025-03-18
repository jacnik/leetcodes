/*
Leetcode: https://leetcode.com/problems/palindromic-substrings/

Given a string s, return the number of palindromic substrings in it.

A string is a palindrome when it reads the same backward as forward.

A substring is a contiguous sequence of characters within the string.


Example 1:

Input: s = "abc"
Output: 3
Explanation: Three palindromic strings: "a", "b", "c".

Example 2:

Input: s = "aaa"
Output: 6
Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".


Constraints:

1 <= s.length <= 1000
s consists of lowercase English letters.
*/

static int CountSubstrings_TwoLoops(string s) {
    var n_palindromes = s.Length;

    for (int m = 0; m < s.Length; ++m)
    {
        int l = m - 1 , r = m + 1;
        while (l >= 0 && r < s.Length)
        {
            if (s[l] != s[r]) break;
            n_palindromes++;
            l--;
            r++;
        }

        l = m; r = m + 1;
        while (l >= 0 && r < s.Length)
        {
            if (s[l] != s[r]) break;
            n_palindromes++;
            l--;
            r++;
        }
    }

    return n_palindromes;
}

static int CountSubstrings(string s) {
    var n_palindromes = s.Length;

    for (int m = 0; m < s.Length; ++m)
    {
        int l_inc = 1;
        int prev_l_inc = 1;
        int l = m, r = m + 1;
        while (l >= 0 && r < s.Length)
        {
            if (s[l] != s[r]) l_inc = 0;
            if (l - 1 < 0 || s[l-1] != s[r]) prev_l_inc = 0;

            if (l_inc + prev_l_inc == 0) break;

            n_palindromes = n_palindromes + l_inc + prev_l_inc;
            l--;
            r++;
        }
    }

    return n_palindromes;
}

Console.WriteLine(CountSubstrings("abc") == 3);
Console.WriteLine(CountSubstrings("aaa") == 6);
Console.WriteLine(CountSubstrings("bbbb") == 10);
Console.WriteLine(CountSubstrings("fdsklf") == 6);


/*
fdsklf
m = 0:
0 1
-1 1

m = 1:
1 2
0 3

0 2

m = 2
2 3
1 4
0 5
1 3
0 4
*/