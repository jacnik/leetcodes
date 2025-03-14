/*
Leetcode: https://leetcode.com/problems/longest-substring-without-repeating-characters/description/

Given a string s, find the length of the longest substring without duplicate characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.


Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/


static int LengthOfLongestSubstring(string s) {

    HashSet<char> seen = [];
    var max = 0;
    var bi = 0;

    for(int ei = 0; ei < s.Length; ++ei)
    {
        var c = s[ei];
        if (!seen.Add(c))
        {
            while(s[bi] != c)
            {
                seen.Remove(s[bi]);
                bi++;
            }
            bi++;
        }

        max = Math.Max(max, seen.Count);
    }

    return max;
}

Console.WriteLine(LengthOfLongestSubstring("abcabcbb") == 3);
Console.WriteLine(LengthOfLongestSubstring("bbbbb") == 1);
Console.WriteLine(LengthOfLongestSubstring("pwwkew") == 3);
