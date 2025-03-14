"""
Given a reference of a node in a connected undirected graph.

Return a deep copy (clone) of the graph.

Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.

class Node {
    public int val;
    public List<Node> neighbors;
}


Test case format:

For simplicity, each node's value is the same as the node's index (1-indexed). For example, the first node with val == 1, the second node with val == 2, and so on. The graph is represented in the test case using an adjacency list.

An adjacency list is a collection of unordered lists used to represent a finite graph. Each list describes the set of neighbors of a node in the graph.

The given node will always be the first node with val = 1. You must return the copy of the given node as a reference to the cloned graph.


Example 1:
    Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
    Output: [[2,4],[1,3],[2,4],[1,3]]
    Explanation: There are 4 nodes in the graph.
    1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
    2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
    3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
    4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).

Example 2:
    Input: adjList = [[]]
    Output: [[]]
    Explanation: Note that the input contains one empty list. The graph consists of only one node with val = 1 and it does not have any neighbors.

Example 3:
    Input: adjList = []
    Output: []
    Explanation: This an empty graph, it does not have any nodes.

Constraints:
    The number of nodes in the graph is in the range [0, 100].
    1 <= Node.val <= 100
    Node.val is unique for each node.
    There are no repeated edges and no self-loops in the graph.
    The Graph is connected and all nodes can be visited starting from the given node.
"""
import unittest
from dataclasses import dataclass, field
from collections import deque


# Definition for a Node.
# class Node:
#     def __init__(self, val = 0, neighbors = None):
#         self.val = val
#         self.neighbors = neighbors if neighbors is not None else []
@dataclass
class Node:
    val: int = 0
    neighbors: list['Node'] = field(default_factory=list)


class Solution:

    def cloneGraph(self, node: Node | None) -> Node | None:
        """
        Very slow. Shorter than others.
        BFS using list instead of a hash map.
        """
        if not node: return None
        MAX_NODES = 100

        cache = [None] * MAX_NODES
        cache[node.val - 1] = Node(node.val)
        to_process = deque()
        to_process.append(node)

        while to_process:
            to_clone = to_process.popleft()
            clone = cache[to_clone.val - 1]
            for neighbor in to_clone.neighbors:
                if not cache[neighbor.val - 1]:
                    cache[neighbor.val - 1] = Node(neighbor.val)
                    to_process.append(neighbor)
                clone.neighbors.append(cache[neighbor.val - 1])

        return cache[node.val - 1]


    def cloneGraphBfsHashMap(self, node: Node | None) -> Node | None:
        """Very slow. Shorter than others. BFS"""
        if not node: return None

        cache = {node.val: Node(node.val)}
        to_process = deque()
        to_process.append(node)

        while to_process:
            to_clone = to_process.popleft()
            clone = cache[to_clone.val]
            for neighbor in to_clone.neighbors:
                if neighbor.val not in cache:
                    cache[neighbor.val] = Node(neighbor.val)
                    to_process.append(neighbor)
                clone.neighbors.append(cache[neighbor.val])

        return cache[node.val]

    def cloneGraphWithNodeCache(self, node: Node | None) -> Node | None:
        """Very slow. BFS"""
        if not node:
            return None

        cache = {}
        def get_node(val: int) -> Node:
            if val not in cache:
                cache[val] = Node(val)
            return cache[val]

        processed = set()
        processed.add(node.val)

        to_process = deque()
        to_process.append(node)

        while len(to_process) > 0:
            to_clone = to_process.popleft()
            clone = get_node(to_clone.val)
            for neighbor in to_clone.neighbors:
                clone.neighbors.append(get_node(neighbor.val))
                if neighbor.val not in processed:
                    processed.add(neighbor.val)
                    to_process.append(neighbor)

        return cache.get(1)

    def cloneGraphTurnBackToAdjList(self, node: Node | None) -> Node | None:
        """
        Long but suprisingly fast.
        Creates adjacency dictionary from graph and turns that back to copied graph.
        """
        if not node:
            return None
        adj = {}
        to_process = deque()
        to_process.append(node)
        while len(to_process) > 0:
            to_clone = to_process.popleft()
            if to_clone.val not in adj:
                adj[to_clone.val] = [n.val for n in to_clone.neighbors]
                for neighbor in (n for n in to_clone.neighbors if n.val not in adj):
                    to_process.append(neighbor)

        nodes = {v:Node(val=v) for v in adj}

        for v, adj_list in adj.items():
            for n in adj_list:
                nodes[v].neighbors.append(nodes[n])

        return nodes.get(1)


def make_graph(adj_lists: list[int]) -> Node | None:
    nodes = {i:Node(val=i) for i in range(1, len(adj_lists) + 1)}

    for i, adj_list in enumerate(adj_lists, 1):
        node = nodes[i]
        for sub_val in adj_list:
            node.neighbors.append(nodes[sub_val])

    return nodes.get(1, None)


class CloneGraphTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def are_copies(self, orig: Node | None, copy: Node | None) -> bool:
        def cmp(o: Node , c: Node) -> bool:
            return o.val == c.val and not (o is c)

        if not orig:
            return copy is None

        processed = set()
        to_process = deque()
        to_process.append((orig, copy))

        while len(to_process) > 0:
            org, cpy = to_process.popleft()
            if not cmp(org, cpy):
                return False
            processed.add(org.val)
            for i, on in enumerate(org.neighbors):
                cn = cpy.neighbors[i]
                if not cmp(on, cn):
                    return False
                if on.val not in processed:
                    to_process.append((on,cn))

        return True

    def test_input_4_nodes(self):
        orig = make_graph([[2,4],[1,3],[2,4],[1,3]])
        copy = self.solution.cloneGraph(orig)
        self.assertTrue(self.are_copies(orig, copy))

    def test_input_one_node(self):
        orig = make_graph([[]])
        copy = self.solution.cloneGraph(orig)
        self.assertTrue(self.are_copies(orig, copy))

    def test_input_none(self):
        orig = make_graph([])
        copy = self.solution.cloneGraph(orig)
        self.assertTrue(self.are_copies(orig, copy))

    def test_long_input(self):
        inp = [
            [2,3,4,14,19,35,59],[1,7,11,47,61,66],[1,24,41,52,68,98],
            [1,5,6,8,37,80],[4,9],[4,20,42,69],[2,10,17],[4,13,26,54,65,71,82],
            [5,12,16,23,38],[7,57],[2],[9,15,18,84],[8,32],[1,48],
            [12,46,58,76,85],[9,90],[7,21,30,70],[12,22],[1,27,86],[6,75,91],
            [17,49,51,99],[18,25,34,63,88],[9,40],[3,45,50,62],[22,36,72],[8,31],
            [19,28,33,55],[27,29],[28,97],[17],[26],[13],[27,64,83],[22],[1,39,44],
            [25],[4,60],[9],[35],[23,43],[3],[6],[40],[35,89],[24],[15],[2],[14,94],
            [21],[24],[21,53],[3,56,77],[51,87],[8,67],[27],[52],[10],[15],[1],[37],
            [2],[24],[22,74,79],[33,73],[8,93],[2],[54],[3,78],[6,95],[17],[8,81],
            [25],[64],[63],[20],[15,92],[52],[68],[63],[4],[71],[8],[33],[12],[15],
            [19],[53],[22],[44],[16],[20],[76],[65],[48,100],[69,96],[95],[29],[3],[21],[94]
        ]

        orig = make_graph(inp)
        copy = self.solution.cloneGraph(orig)
        self.assertTrue(self.are_copies(orig, copy))



if __name__ == '__main__':
    unittest.main()
