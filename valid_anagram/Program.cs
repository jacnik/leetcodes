/*
Leectode: https://leetcode.com/problems/valid-anagram

Given two strings s and t, return true if t is an anagram of s, and false otherwise.

Example 1:

Input: s = "anagram", t = "nagaram"

Output: true

Example 2:

Input: s = "rat", t = "car"

Output: false



Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.


Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?

*/

static bool IsAnagram(string s, string t) {

    if (s.Length != t.Length) return false;

    Dictionary<char, int> freqs = [];

    for (int i = 0; i < s.Length; ++i)
    {
        if (freqs.TryGetValue(s[i], out var sv))
        {
            freqs[s[i]] = ++sv;
        }
        else
        {
            freqs[s[i]] = 1;
        }

        if (freqs.TryGetValue(t[i], out var tv))
        {
            freqs[t[i]] = --tv;
        }
        else
        {
            freqs[t[i]] = -1;
        }
    }

    return freqs.All(kv => kv.Value == 0);
}


Console.WriteLine(IsAnagram("anagram", "nagaram"));
Console.WriteLine(IsAnagram("rat", "car") == false);
Console.WriteLine(IsAnagram("a", "ab") == false);

