/*
Leetcode: https://leetcode.com/problems/n-ary-tree-postorder-traversal

Given the root of an n-ary tree, return the postorder traversal of its nodes' values.

Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)


Example 1:

        1
     /  |  \
    3   2   4
   / \
  5   6

Input: root = [1,null,3,2,4,null,5,6]
Output: [5,6,3,2,4,1]

Example 2:
             1
     /  /      \        \
    2   3       4        5
       / \      |       / \
      6   7     8      9  10
          |     |      |
          11    12     13
          |
          14

Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [2,6,14,11,7,3,12,8,4,13,9,10,5,1]

Constraints:

The number of nodes in the tree is in the range [0, 104].
0 <= Node.val <= 104
The height of the n-ary tree is less than or equal to 1000.

*/

Node r1 = new(1)
{
    children = [
        new(3)
        {
            children = [new(5), new(6)]
        },
        new(2),
        new(4),
    ]
};


Node r2 = new(1)
{
    children = [
        new(2),
        new(3)
        {
            children = [
                new(6),
                new(7) {children = [new(11) {children = [new(14)]}]}
            ]
        },
        new(4) {children = [new(8) {children = [new(12)]}]},
        new(5) {children = [
            new(9) {children = [new(13)]},
            new(10)
        ]},
    ]
};



static IList<int> Postorder_Recursive(Node root) {
    List<int> res = [];
    PostorderRec(root);
    return res;

    void PostorderRec(Node root) {
        if (root is null) return;
        foreach(var c in root.children)
        {
            PostorderRec(c);
        }
        res.Add(root.val);
    }
}

static IList<int> Postorder(Node root) {
    List<int> res = [];
    Stack<Node> stack = [];

    if (root is not null)
    {
        stack.Push(root);
    }

    while(stack.Count > 0)
    {
        root = stack.Pop();
        res.Add(root.val);

        foreach(var c in root.children)
        {
            stack.Push(c);
        }
    }

    res.Reverse();
    return res;
}


Console.WriteLine($"[5,6,3,2,4,1]\n{PrintList(Postorder(r1))}");
Console.WriteLine($"[2,6,14,11,7,3,12,8,4,13,9,10,5,1]\n{PrintList(Postorder(r2))}");


/*
Helper excercise is to write a function that would retun postorder traversal but reversed
Example 1:

        1
     /  |  \
    3   2   4
   / \
  5   6

Input: root = [1,null,3,2,4,null,5,6]
Output: [1,4,2,3,6,5]

Example 2:
             1
     /  /      \        \
    2   3       4        5
       / \      |       / \
      6   7     8      9  10
          |     |      |
          11    12     13
          |
          14

Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [1,5,10,9,13,4,8,12,3,7,11,14,6,2]
*/

Console.WriteLine($"[1,4,2,3,6,5]\n{PrintList(PostorderReversed(r1))}");
Console.WriteLine($"[1,5,10,9,13,4,8,12,3,7,11,14,6,2]\n{PrintList(PostorderReversed(r2))}");


static IList<int> PostorderReversed(Node root) {
    List<int> res = [];
    Stack<Node> stack = [];

    if (root is not null)
    {
        stack.Push(root);
    }

    while(stack.Count > 0)
    {
        root = stack.Pop();
        res.Add(root.val);

        foreach(var c in root.children)
        {
            stack.Push(c);
        }
    }

    return res;
}



static string PrintList(IEnumerable<int> l)
{
    return $"[{string.Join(',', l)}]";
}



class Node {
    public int val;
    public IList<Node> children {get; set;} = [];

    public Node(int _val) {
        val = _val;
    }
}
