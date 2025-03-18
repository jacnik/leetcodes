/*
Neetcode: https://neetcode.io/problems/string-encode-and-decode

Design an algorithm to encode a list of strings to a single string. The encoded string is then decoded back to the original list of strings.

Please implement encode and decode

Example 1:

Input: ["neet","code","love","you"]

Output:["neet","code","love","you"]

Example 2:

Input: ["we","say",":","yes"]

Output: ["we","say",":","yes"]

Constraints:

    0 <= strs.length < 100
    0 <= strs[i].length < 200
    strs[i] contains only UTF-8 characters.

*/

static string Encode(IList<string> strs) {
    /* Encode with Separator */

    string[] separated_strs = new string[strs.Count];
    for(int i = 0; i < strs.Count; ++i)
    {
        separated_strs[i] = (char)strs[i].Length + strs[i];
    }

    return string.Join("", separated_strs);
}

static List<string> Decode(string s) {
    /* Decode with Separator */
    int str_start = 0;
    List<string> res = [];

    while (str_start < s.Length)
    {
        int str_len = s[str_start];

        res.Add(s[(str_start + 1)..(str_start + str_len + 1)]);
        str_start += str_len + 1;
    }

    return res;
}


static string Encode_With_Header(IList<string> strs) {
    /* Encode with header */
    char n_strings = (char) strs.Count;
    char[] sizes = new char[n_strings + 1];
    sizes[0] = n_strings;
    for (int i = 0; i < strs.Count; ++i)
    {
        sizes[i+1] = (char)strs[i].Length;
    }

    var header = string.Join("", sizes);

    return header + string.Join("", strs);
}

static List<string> Decode_With_Header(string s) {
    /* Decode with header */
    int n_strings = s[0];
    List<string> res = [];

    int str_start = n_strings + 1;
    for (int i = 1; i <= n_strings; ++i)
    {
        int str_size = s[i];
        res.Add(s[str_start..(str_start + str_size)]);
        str_start += str_size;
    }

    return res;
}

static string PrintList(IList<string> l)
{
    return string.Join(',', l);
}

// Console.WriteLine(Encode(["neet","code","love","you"]));
// Console.WriteLine(Encode( ["we","say",":","yes"]));

Console.WriteLine($"{PrintList(["neet","code","love","you"])}\n{PrintList(Decode(Encode(["neet","code","love","you"])))}\n");
Console.WriteLine($"{PrintList(["we","say",":","yes"])}\n{PrintList(Decode(Encode( ["we","say",":","yes"])))}\n");
Console.WriteLine($"{PrintList([])}\n{PrintList(Decode(Encode([])))}\n");
Console.WriteLine($"{PrintList([""])}\n{PrintList(Decode(Encode([""])))}\n");

Console.WriteLine($"{PrintList(["a"])}\n{PrintList(Decode(Encode(["a"])))}\n");
Console.WriteLine($"{PrintList(["", ""])}\n{PrintList(Decode(Encode(["", ""])))}\n");



