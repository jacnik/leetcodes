/*
Leetcode: https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/


Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary tree and inorder is the inorder traversal of the same tree, construct and return the binary tree.

Example 1:

    3
   / \
  9   20
     /  \
    15   7

Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
Output: [3,9,20,null,null,15,7]

Example 2:

Input: preorder = [-1], inorder = [-1]
Output: [-1]


Constraints:

* 1 <= preorder.length <= 3000
* inorder.length == preorder.length
* -3000 <= preorder[i], inorder[i] <= 3000
* preorder and inorder consist of unique values.
* Each value of inorder also appears in preorder.
* preorder is guaranteed to be the preorder traversal of the tree.
* inorder is guaranteed to be the inorder traversal of the tree.

*/

static TreeNode? BuildTree_With_Dictionary_Without_Global_Variable(int[] preorder, int[] inorder) {

    Dictionary<int, int> inorderMap = inorder.Index().ToDictionary(p => p.Item, p => p.Index);
    return BuildTreeHelper(0, preorder.Length - 1, 0, inorder.Length - 1);

    // Recursive helper function
    TreeNode? BuildTreeHelper(int preStart, int preEnd, int inStart, int inEnd) {
        // Base case: If no elements to construct the tree, return null
        if (preStart > preEnd || inStart > inEnd) {
            return null;
        }

        // The first element of preorder is the root node
        int rootVal = preorder[preStart];
        TreeNode root = new(rootVal);

        // Find the root index in inorder
        int rootIndex = inorderMap[rootVal];

        // Calculate the size of the left subtree
        int leftSize = rootIndex - inStart;

        // Recursively construct the left and right subtrees
        root.left = BuildTreeHelper(preStart + 1, preStart + leftSize, inStart, rootIndex - 1);
        root.right = BuildTreeHelper(preStart + leftSize + 1, preEnd, rootIndex + 1, inEnd);

        return root;
    }
}

static TreeNode? BuildTree_With_Dict_And_Global_Var(int[] preorder, int[] inorder) {

    Dictionary<int, int> inorderMap = inorder.Index().ToDictionary(p => p.Item, p => p.Index);
    int pre_idx = 0;
    return BuildTreeHelper(ref pre_idx, 0, inorder.Length - 1);

    TreeNode? BuildTreeHelper(ref int pre_idx, int start, int end) {
        if (start > end || pre_idx >= inorder.Length) return null;

        // The first element of preorder is the root node
        int rootVal = preorder[pre_idx++];
        TreeNode root = new(rootVal);

        // Find the root index in inorder
        int rootIndex = inorderMap[rootVal];

        // Recursively construct the left and right subtrees
        root.left = BuildTreeHelper(ref pre_idx, start, rootIndex - 1);
        root.right = BuildTreeHelper(ref pre_idx, rootIndex + 1, end);

        return root;
    }
}



/*
    3
   / \
  9   20
     /  \
    15   7

Input: preorder = [3,9,20,15,7],
        inorder = [9,3,15,20,7]
Output: [3,9,20,null,null,15,7]


*/
static TreeNode? BuildTree(int[] preorder, int[] inorder) {

    int pre_idx = 0;
    int in_idx = 0;

    return BuildTreeHelper(ref pre_idx, ref in_idx, int.MaxValue);

    TreeNode? BuildTreeHelper(ref int pre_idx, ref int in_idx, int in_limit) {
        if (pre_idx >= inorder.Length) return null;

        if (inorder[in_idx] == in_limit)
        {
            in_idx++;
            return null;
        }

        int rootVal = preorder[pre_idx];
        pre_idx++;
        TreeNode root = new(rootVal);

        root.left = BuildTreeHelper(ref pre_idx, ref in_idx, rootVal);
        root.right = BuildTreeHelper(ref pre_idx, ref in_idx, in_limit);

        return root;
    }
}



static string PrintTree(TreeNode root)
{
    List<List<int?>> level_order = [];
    Bfs(root, level_order, 0);

    return PrintAsList(level_order);

    static string PrintAsList(List<List<int?>> level_order)
    {
        return $"""
                [{string.Join(',', level_order.SkipLast(1).SelectMany(l => l.Select(i => i?.ToString() ?? "null")))}]
                """;
    }

    // static string PrintInLevels(List<List<int?>> level_order)
    // {
    //     return string.Join('\n', level_order.Select(l => PrintList(l)));
    // }

    // static string PrintList(List<int?> l)
    // {
    //     return string.Join(',', l.Select(i => i?.ToString() ?? "null"));
    // }

    static void Bfs(TreeNode? root, List<List<int?>> values, int level)
    {
        if (values.Count == level)
        {
            values.Add([]);
        }
        values[level].Add(root?.val);

        if (root is null) return;

        Bfs(root.left, values, level + 1);
        Bfs(root.right, values, level + 1);
    }
}


/*
    3
   / \
  9   20
     /  \
    15   7
*/
TreeNode root1 = new(3){
    left = new(9),
    right = new(20) {
        left = new(15),
        right = new(7)
    }
};

TreeNode root2 = new(-1);

/*
---

    3
   / \
  9   20
     /  \
    15   7


preorder = [3,9,20,15,7]
inorder  = [9,3,15,20,7]
output   = [3,9,20,null,null,15,7]

---
    1
     \
      2

    Input: preorder = [1,2]
            inorder = [1,2]

    Output: [1,null,2]
*/


/* Test BuildTree */
Console.WriteLine($"[3,9,20,null,null,15,7]\n{PrintTree(BuildTree([3,9,20,15,7], [9,3,15,20,7]))}");
Console.WriteLine($"[1,null,2]\n{PrintTree(BuildTree([1,2],[1,2]))}");


/* Test print tree */
// Console.WriteLine(PrintTree(root1) == "[3,9,20,null,null,15,7]");
// Console.WriteLine(PrintTree(root2) == "[-1]");


/* Prelim Excersices */
static TreeNode BuildFromPreorder(int[] pre)
{
    // value => idx
    Dictionary<int, int> value_indexes = pre.Index().ToDictionary(v => v.Item, k => k.Index);
    Queue<TreeNode> queue = [];

    int root_idx = 0;
    TreeNode root = new(pre[root_idx]);
    queue.Enqueue(root);

    while (queue.Count > 0)
    {
        var node = queue.Dequeue();
        int node_idx = value_indexes[node.val];

        int left_idx = node_idx*2 + 1;
        if (left_idx < pre.Length)
        {
            TreeNode left = new(pre[left_idx]);
            node.left = left;
            queue.Enqueue(left);
        }

        int right_idx = node_idx*2 + 2;
        if (right_idx < pre.Length)
        {
            TreeNode right = new(pre[right_idx]);
            node.right = right;
            queue.Enqueue(right);
        }
    }

    return root;
}

static TreeNode BuildFromInorder(int[] pre)
{
/*
    level 0:            0
    level 1:    1,            2
    level 2:  3,   4,     5,     6
    level 3: 7,8, 9,10, 11,12, 13,14
*/
    return BuildSubNode(in pre, 0, pre.Length);

    static TreeNode BuildSubNode(in int[] arr, int l, int r)
    {
        int mid = l + (r - l) / 2;
        TreeNode root = new(arr[mid]);

        if (mid > l)
        {
            root.left = BuildSubNode(in arr, l, mid);
        }
        if (mid < r - 1)
        {
            root.right = BuildSubNode(in arr, mid + 1, r);
        }

        return root;
    }
}

// Console.WriteLine($"[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14]\n{PrintTree(BuildFromPreorder([0, 1,2, 3,4,5,6, 7,8,9,10,11,12,13,14]))}");
// Console.WriteLine($"[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14]\n{PrintTree(BuildFromInorder([7,3,8, 1, 9,4,10,  0, 11,5,12, 2, 13,6,14]))}");

class TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null)
{
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;
}
