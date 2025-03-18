/*
Leetcode: https://leetcode.com/problems/valid-palindrome/

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters,
it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.



Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.


Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.

*/

static bool IsPalindrome(string s) {

    int l = 0, r = s.Length - 1;

    while (l <= r)
    {
        while (l < r && !IsAlpha(s[l])) l++;
        while (l < r && !IsAlpha(s[r])) r--;

        if (ToLower(s[l]) != ToLower(s[r])) return false;
        l++;
        r--;
    }

    return true;

    static bool IsAlpha(char c)
    {
        return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
    }

    static char ToLower(char c)
    {

        var base_diff = 'A' - 'a';
        if (c >= 'A' && c <= 'Z')
        {
            return (char)(c - base_diff);
        }
        return c;
    }
}


Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
Console.WriteLine(IsPalindrome("race a car") == false);
Console.WriteLine(IsPalindrome(" "));

Console.WriteLine(IsPalindrome("a bcba"));
Console.WriteLine(IsPalindrome("abccb a"));
Console.WriteLine(IsPalindrome("0P") == false);





