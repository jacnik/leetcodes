/*
Level order traversal
*/


static IList<IList<int>> LevelOrderBinary(BinNode root)
{
    Queue<BinNode> curr_nodes = [];
    curr_nodes.Enqueue(root);

    List<IList<int>> levels = [];

    int curr_level = 0;

    while (curr_nodes.Count > 0)
    {
        levels.Add([]);
        int n_nodes = curr_nodes.Count;
        for (int _ = 0; _ < n_nodes; ++_)
        {
            var node = curr_nodes.Dequeue();
            levels[curr_level].Add(node.Val);
            if (node.Left is not null)
            {
                curr_nodes.Enqueue(node.Left);
            }
            if (node.Right is not null)
            {
                curr_nodes.Enqueue(node.Right);
            }
        }

        curr_level++;
    }

    return levels;
}

static void TestLevelOrderTraversalBinaryTree()
{
    /*  Level-order traversal of a binary tree
        Create binary tree
          1
         / \
        3   2
             \
              4
             / \
            6   5
    */

    var root = new BinNode(1)
    {
        Left = new BinNode(3),
        Right = new BinNode(2)
        {
            Right = new BinNode(4)
            {
                Left = new BinNode(6),
                Right = new BinNode(5)
            }
        }
    };

    var level_order = LevelOrderBinary(root);

    Console.WriteLine("---> Level Order Traversal of a Binary Tree");

    foreach (var level in level_order)
    {
        Console.WriteLine(string.Join(',', level));
    }
}

TestLevelOrderTraversalBinaryTree();


static IList<IList<int>> LevelOrderNary(NNode root)
{
    List<IList<int>> level_order = [];
    Queue<NNode> queue = [];
    queue.Enqueue(root);

    while (queue.Count > 0)
    {
        var level_len = queue.Count;
        List<int> curr_level = [];

        for(int _ = 0; _ < level_len; ++_)
        {
            var node = queue.Dequeue();
            curr_level.Add(node.Val);
            foreach(var child in node.Children)
            {
                queue.Enqueue(child);
            }
        }
        level_order.Add(curr_level);
    }

    return level_order;
}

static void TestLevelOrderTraversalNaryTree()
{
    /* Level order traversal of an N-ary tree
       Create n-ary tree

                5
                |
              1,2,3
             /  |  \
          -1,0  4   6,7,8
            /         |
          -2         9,10
    */

    NNode root = new(5)
    {
        Children = [
            new(1) {Children = [new(-1), new(0) {Children = [new(-2),]},]},
            new(2) {Children = [new(4),]},
            new(3) {Children = [
                new(6),
                new(7) {Children = [new(9), new(10),]},
                new(8),
            ]},
        ]
    };

    var level_order = LevelOrderNary(root);

    Console.WriteLine("---> Level Order Traversal of a N-ary Tree");

    foreach (var level in level_order)
    {
        Console.WriteLine(string.Join(',', level));
    }
}

TestLevelOrderTraversalNaryTree();


static IList<float> AverageOfLevelsInBinaryTree(BinNode root)
{
    /*
    *  Given the root of a binary tree return the average value if the ndoes on each level in the form of an array.
    */
    List<float> averages = [];
    Queue<BinNode> queue = [];
    queue.Enqueue(root);

    while (queue.Count > 0)
    {
        int level_size = queue.Count;
        float average_acc = 0;
        for (int _ = 0; _ < level_size; ++_)
        {
            var node = queue.Dequeue();
            average_acc += (float) node.Val / level_size;
            if (node.Left is not null) queue.Enqueue(node.Left);
            if (node.Right is not null) queue.Enqueue(node.Right);
        }
        averages.Add(average_acc);
    }

    return averages;
}

static void TestAverageOfLevelsInBinaryTree()
{
    /*
        Create binary tree
           1
         /   \
        2     3
       / \   / \
      4   5 6   7
     /
    8
    */

    BinNode root = new (1)
    {
        Left = new(2) {Left = new(4) {Left = new(8)}, Right = new(5)},
        Right = new(3) {Left = new(6), Right = new(7)}
    };

    Console.WriteLine("---> Average of levels in binary tree");

    var averages = AverageOfLevelsInBinaryTree(root);

    foreach (var av in averages)
    {
        Console.WriteLine(av);
    }
}

TestAverageOfLevelsInBinaryTree();


static IList<IList<int>> ZigZagBinary(BinNode root)
{
    /*
    *   Given the root of a binary tree, return the zigzag order traversal of it's nodes' values.
    *   i.e. from left to right, then from right to left for the next level and alternate between them.
    */
    List<IList<int>> zigzag = [];
    Queue<BinNode> queue = [];
    queue.Enqueue(root);

    bool flip = true;
    while (queue.Count > 0)
    {
        int level_count = queue.Count;
        List<int> level = [];
        for (var _ = 0; _ < level_count; ++_)
        {
            var node = queue.Dequeue();
            level.Add(node.Val);

            if (flip)
            {
                if (node.Right is not null) queue.Enqueue(node.Right);
                if (node.Left is not null) queue.Enqueue(node.Left);
            }
            else
            {
                if (node.Left is not null) queue.Enqueue(node.Left);
                if (node.Right is not null) queue.Enqueue(node.Right);
            }
        }
        zigzag.Add(level);
        flip = !flip;
    }

    return zigzag;
}
static void TestZigZagBinary()
{
    /*
        Create binary tree
           3
         /   \
        9     20
             / \
            15  7
    */

    BinNode root = new(3)
    {
        Left = new(9),
        Right = new(20) {Left = new(15), Right = new(7)}
    };

    Console.WriteLine("---> ZigZag traversal of a binary tree");

    var zigzag = ZigZagBinary(root);

    foreach (var level in zigzag)
    {
        Console.WriteLine(string.Join(',', level));
    }
}

TestZigZagBinary();


static IList<int> LargestValueInEachRow(BinNode root)
{
    /*
    *   Given the root of a binary tree, return an array of the largest value in each row of the tree.
    */
    List<int> maxes = [];
    Queue<BinNode> nodes = [];
    nodes.Enqueue(root);

    while(nodes.Count > 0)
    {
        int row_len = nodes.Count;
        int max_so_far = int.MinValue;
        for (var _ = 0; _ < row_len; ++_)
        {
            var node = nodes.Dequeue();
            max_so_far = Math.Max(max_so_far, node.Val);

            if (node.Left is not null) nodes.Enqueue(node.Left);
            if (node.Right is not null) nodes.Enqueue(node.Right);
        }
        maxes.Add(max_so_far);
    }

    return maxes;
}
static void TestLargestValueInEachRow()
{
    /*
        Create binary tree
           3
         /   \
        9     20
             / \
            15  7
    */

    BinNode root = new(3)
    {
        Left = new(9),
        Right = new(20) {Left = new(15), Right = new(7)}
    };

    Console.WriteLine("---> Largest value in each row.");

    var largest_vals = LargestValueInEachRow(root);

    foreach (var lv in largest_vals)
    {
        Console.WriteLine(lv);
    }
}
TestLargestValueInEachRow();


class BinNode
{
    /* Binay Node */
    public  int Val {get; init;}
    public BinNode? Left {get; set;}
    public BinNode? Right {get; set;}

    public BinNode(int value)
    {
        Val = value;
        Left = Right = null;
    }
}

class NNode
{
    /* N-ary Node */
    public  int Val {get; init;}
    public IList<NNode> Children {get; init;} = [];

    public NNode(int value)
    {
        Val = value;
    }
}



