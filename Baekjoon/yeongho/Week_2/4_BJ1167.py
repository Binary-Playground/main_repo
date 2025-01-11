from collections import deque, defaultdict

class Node:
    def __init__(self, index):
        self.index = index
        self.accumulated_sum = 0
        self.is_visited = False
        self.linked_nodes = {}  # key: node index, value: distance

    def add_linked_node(self, node, dist):
        self.linked_nodes[node] = dist

class BJ1167:
    def __init__(self):
        self.best_far_node = None
        self.distance_value = 0
        self.node_dict = {}

    def initialize(self):
        node_count = int(input())
        self.node_dict = {i: Node(i) for i in range(1, node_count + 1)}

        for _ in range(node_count):
            dimensions = list(map(int, input().split()))
            node_idx = dimensions[0]
            j = 1
            while dimensions[j] != -1:
                self.node_dict[node_idx].add_linked_node(dimensions[j], dimensions[j + 1])
                j += 2

    def start_simulation(self):
        # 1. Start BFS from node 1 to find the farthest node
        self.bfs(self.node_dict[1])

        # Reset node states
        self.reset_nodes()

        # 2. Start BFS from the farthest node to calculate the diameter
        self.bfs(self.best_far_node)

        print(self.distance_value)

    def bfs(self, node):
        queue = deque([node])
        node.is_visited = True

        while queue:
            current_node = queue.popleft()

            for key, distance in current_node.linked_nodes.items():
                next_node = self.node_dict[key]
                if next_node.is_visited:
                    continue

                next_node.is_visited = True
                next_node.accumulated_sum = current_node.accumulated_sum + distance

                if self.distance_value < next_node.accumulated_sum:
                    self.distance_value = next_node.accumulated_sum
                    self.best_far_node = next_node

                queue.append(next_node)

    def reset_nodes(self):
        for node in self.node_dict.values():
            node.is_visited = False
            node.accumulated_sum = 0

if __name__ == "__main__":
    simulation = BJ1167()
    simulation.initialize()
    simulation.start_simulation()
