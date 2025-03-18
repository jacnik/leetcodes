/*
Leetcode: https://leetcode.com/problems/valid-parentheses/


Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.


Example 1:

Input: s = "()"

Output: true

Example 2:

Input: s = "()[]{}"

Output: true

Example 3:

Input: s = "(]"

Output: false

Example 4:

Input: s = "([])"

Output: true



Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
*/


static bool IsValid(string s) {
    Stack<char> stack = [];

    foreach(var c in s)
    {
        if (c == ')')
        {
            if (stack.TryPop(out var opening))
            {
                if (opening != '(') return false;
            }
            else
            {
                return false;
            }
        }
        else if (c == ']')
        {
            if (stack.TryPop(out var opening))
            {
                if (opening != '[') return false;
            }
            else
            {
                return false;
            }
        }
        else if (c == '}')
        {
            if (stack.TryPop(out var opening))
            {
                if (opening != '{') return false;
            }
            else
            {
                return false;
            }
        }
        else
        {
            stack.Push(c);
        }
    }

    return stack.Count == 0;
}

Console.WriteLine(IsValid("()"));
Console.WriteLine(IsValid("()[]{}"));
Console.WriteLine(IsValid("(]") == false);
Console.WriteLine(IsValid("([])"));
