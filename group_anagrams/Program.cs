/*
Leetcode: https://leetcode.com/problems/group-anagrams


Given an array of strings strs, group the anagrams together. You can return the answer in any order.

Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]

Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Explanation:

There is no string in strs that can be rearranged to form "bat".
The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.

Example 2:

Input: strs = [""]

Output: [[""]]

Example 3:

Input: strs = ["a"]

Output: [["a"]]



Constraints:

1 <= strs.length <= 104
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.
*/


static IList<IList<string>> GroupAnagrams(string[] strs) {

    Dictionary<int, IList<string>> hashes = [];

    for(int i = 0; i < strs.Length; ++i)
    {
        var s = strs[i];
        var sorted_list = s.ToList();
        sorted_list.Sort();
        var sorted = string.Join("", sorted_list);

        var hc = sorted.GetHashCode();

        if (hashes.TryGetValue(hc, out var group))
        {
            group.Add(s);
        }
        else
        {
            hashes.Add(hc, [s]);
        }

    }

    return [.. hashes.Values];
}



static string PrintArr(IEnumerable<string> arr)
{
    return $"""[{string.Join(",", arr)}]""";
}

static string PrintRes(IList<IList<string>> res)
{
    return $"""[{string.Join(",", res.Select(PrintArr))}]""";
}

Console.WriteLine($"{PrintRes([["bat"],["nat","tan"],["ate","eat","tea"]])}\n{PrintRes(GroupAnagrams(["eat","tea","tan","ate","nat","bat"]))}\n");
Console.WriteLine($"{PrintRes([[""]])}\n{PrintRes(GroupAnagrams([""]))}\n");
Console.WriteLine($"{PrintRes([["a"]])}\n{PrintRes(GroupAnagrams(["a"]))}\n");

