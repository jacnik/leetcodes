/*
* Solution to:
* https://leetcode.com/problems/the-skyline-problem/
*/

using Rect = (int l, int r, int h);


static IList<IList<int>> GetSkyline(int[][] buildings)
{
    PriorityQueue<Rect, int> q = new(Comparer<int>.Create((x, y) => y - x));

    List<IList<int>> points = [];

    Rect prevBuild = (buildings[0][0], buildings[0][1], buildings[0][2]);
    q.Enqueue(prevBuild, prevBuild.h);

    foreach (var building in buildings.Skip(1))
    {
        Rect newBuild = (building[0], building[1], building[2]);
        if (newBuild.h > prevBuild.h) // UP Transition
        {
            if (newBuild.l > prevBuild.l)
            {
                points.Add([prevBuild.l, prevBuild.h]);
            }
            prevBuild = newBuild;
            q.Enqueue(prevBuild, prevBuild.h);
        }
        else if (newBuild.h < prevBuild.h) // DOWN Transition
        {
            while (q.Count > 0)
            {
                var qBuld = q.Peek();
                if (qBuld.h > newBuild.h) // queued is higher
                {
                    q.Dequeue();
                    points.Add([qBuld.l, qBuld.h]); // TODO
                }
                if (!HorizontalOverlap(qBuld, newBuild)) // are not overlapping
                {
                    q.Dequeue();
                }
                // if (qBuld == prevBuild)
                // {
                //     q.Dequeue();
                //     continue;
                // }
                // else if ()
                q.Dequeue();
            }

            // ***
            points.Add([prevBuild.l, prevBuild.h]);

            if (HorizontalOverlap(prevBuild, newBuild))
            {
                prevBuild = (prevBuild.r, newBuild.r, newBuild.h);
            }
            else
            {
                points.Add([prevBuild.r, 0]);
                prevBuild = newBuild;
            }
        }
        else // NO Transition
        {
            if (HorizontalOverlap(prevBuild, newBuild))
            {
                prevBuild = (prevBuild.l, Math.Max(prevBuild.r, newBuild.r), newBuild.h);
            }
            else
            {
                points.Add([prevBuild.r, 0]);
                prevBuild = newBuild;
            }
        }
    }

    points.Add([prevBuild.l, prevBuild.h]);
    points.Add([prevBuild.r, 0]);

    return points;
}

static IList<IList<int>> GetSkyline_no_q(int[][] buildings)
{
    List<IList<int>> points = [];

    Rect prevBuild = (buildings[0][0], buildings[0][1], buildings[0][2]);

    foreach (var building in buildings.Skip(1))
    {
        Rect newBuild = (building[0], building[1], building[2]);
        if (newBuild.h > prevBuild.h) // UP Transition
        {
            if (newBuild.l > prevBuild.l)
            {
                points.Add([prevBuild.l, prevBuild.h]);
            }
            // q.Enqueue(newBuild, newBuild.h);
            prevBuild = newBuild;
        }
        else if (newBuild.h < prevBuild.h) // DOWN Transition
        {
            points.Add([prevBuild.l, prevBuild.h]);

            if (HorizontalOverlap(prevBuild, newBuild))
            {
                prevBuild = (prevBuild.r, newBuild.r, newBuild.h);
            }
            else
            {
                points.Add([prevBuild.r, 0]);
                prevBuild = newBuild;
            }
        }
        else // NO Transition
        {
            if (HorizontalOverlap(prevBuild, newBuild))
            {
                prevBuild = (prevBuild.l, Math.Max(prevBuild.r, newBuild.r), newBuild.h);
            }
            else
            {
                points.Add([prevBuild.r, 0]);
                prevBuild = newBuild;
            }
        }
    }

    points.Add([prevBuild.l, prevBuild.h]);
    points.Add([prevBuild.r, 0]);

    return points;
}

static bool HorizontalOverlap(Rect first, Rect second)
{
    return first.r >= second.l;
}

static bool AssertResults(IList<IList<int>> res, IList<IList<int>> expected)
{
    if(res.Count != expected.Count)
    {
        return false;
    }

    foreach (var (First, Second) in res.Zip(expected))
    {
        if(First[0] != Second[0] || First[1] != Second[1])
        {
            return false;
        }
    }

    return true;
}

static string WriteRes(IList<IList<int>> res)
{
    return $"""[{String.Join(",", res.Select(x => $"[{String.Join(",", x)}]"))}]""";
}

static void TestCase(int[][] input, IList<IList<int>> expected, string label)
{
    Console.WriteLine($"Running Test Case: {label}");
    var result = GetSkyline(input);
    Console.WriteLine($"Expected: {WriteRes(expected)}");
    Console.WriteLine($"Actual:   {WriteRes(result)}" );
    Console.WriteLine($"Test case {label} passed: {AssertResults(result, expected)}");

}

int[][] inputA = [[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]];
IList<IList<int>> expectedA = [[2,10],[3,15],[7,12],[12,0],[15,10],[20,8],[24,0]];

int[][] inputB = [[0,2,3],[2,5,3]];
IList<IList<int>> expectedB = [[0,3],[5,0]];

int[][] inputC = [[2,14,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]];
IList<IList<int>> expectedC = [[2,10],[3,15],[7,12],[12,10],[14,0],[15,10],[20,8],[24,0]];

TestCase(inputA, expectedA, "A");
TestCase(inputB, expectedB, "B");
TestCase(inputC, expectedC, "C");

