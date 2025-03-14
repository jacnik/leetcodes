"""
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.


Example 1:

    Input: numCourses = 2, prerequisites = [[1,0]]
    Output: true
    Explanation: There are a total of 2 courses to take.
    To take course 1 you should have finished course 0. So it is possible.

Example 2:

    Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
    Output: false
    Explanation: There are a total of 2 courses to take.
    To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.


Constraints:

    1 <= numCourses <= 2000
    0 <= prerequisites.length <= 5000
    prerequisites[i].length == 2
    0 <= ai, bi < numCourses
    All the pairs prerequisites[i] are unique.
"""
import unittest


class Solution:
    def canFinish(self, numCourses: int, prerequisites: list[list[int]]) -> bool:
        def init_graph(numCourses: int, prerequisites: list[list[int]]) -> list[list[int]]:
            prereq_graph = [[0]] * numCourses
            for i in range(numCourses):
                prereq_graph[i] = [0] * numCourses

            for a, b in prerequisites:
                prereq_graph[a][b] = 1

            return prereq_graph

        graph = init_graph(numCourses, prerequisites)
        finished = set()

        def can_finish_course(course: int) -> bool:
            if course in finished:
                return True
            curr_path = set()
            curr_path.add(course)

            prerequisites = [p for p, v in enumerate(graph[course]) if v == 1]
            while prerequisites:
                p = prerequisites.pop()
                if p in finished:
                    break
                if p in curr_path:
                    return False
                curr_path.add(p)
                prerequisites.extend((p for p, v in enumerate(graph[p]) if v == 1))

            finished.add(course)
            return True

        return all(can_finish_course(c) for c in range(numCourses))



class CourseScheduleTests(unittest.TestCase):
    def setUp(self) -> None:
        self.solution = Solution()
        return super().setUp()

    def test_input_2_with_one_prereq(self):
        res = self.solution.canFinish(2, [[1,0]])
        self.assertTrue(res)

    def test_input_2_with_two_prereq(self):
        res = self.solution.canFinish(2, [[1,0],[0,1]])
        self.assertFalse(res)

    def test_input_3_with_two_prereq(self):
        res = self.solution.canFinish(3, [[1,0],[2,0]])
        self.assertTrue(res)

    def test_input_4_with_three_prereq(self):
        res = self.solution.canFinish(4, [[1,3],[2,1],[3,0]])
        self.assertTrue(res)

    def test_input_3_with_cyclical_prereq(self):
        res = self.solution.canFinish(3, [[1,0],[1,2],[0,1]])
        self.assertFalse(res)

    def test_input_3_with_double_prereq(self):
        res = self.solution.canFinish(3, [[0,1],[0,2],[1,2]])
        self.assertTrue(res)

if __name__ == '__main__':
    unittest.main()
