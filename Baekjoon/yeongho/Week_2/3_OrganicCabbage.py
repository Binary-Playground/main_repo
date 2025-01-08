import sys
from collections import deque


class OrganicCabbage:
    def __init__(self):
        self.simulations = deque()

    # 입력 및 초기화
    def initialize(self):
        n = int(input())
        for _ in range(n):
            width, height, cabbage_cnt = map(int, sys.stdin.readline().split())
            field = [[0] * width for _ in range(height)]

            for _ in range(cabbage_cnt):
                x, y = map(int, sys.stdin.readline().split())
                field[y][x] = 1

            self.simulations.append(FieldSimulation(field, width, height))

    def Play(self):
        for simulation in self.simulations:
            simulation.Start()
            simulation.print_result()


class FieldSimulation:
    dx = [0, 0, -1, 1]
    dy = [1, -1, 0, 0]

    def __init__(self, field, width, height):
        self.field = field
        self.width = width
        self.height = height
        self.visited = [[False] * width for _ in range(height)]
        self.ans = 0

    def Start(self):
        for r in range(self.height):
            for c in range(self.width):
                if self.Movable(c, r):
                    self.DFS(c, r)

    def DFS(self, colum, row):
        qCabbages = deque()
        qCabbages.append((colum, row))
        self.visited[row][colum] = True

        while qCabbages:
            (x, y) = qCabbages.popleft()
            for i in range(4):
                nx, ny = (x + self.dx[i], y + self.dy[i])
                if self.InRange(nx, ny) and self.Movable(nx, ny):
                    self.visited[ny][nx] = True
                    qCabbages.append((nx, ny))

        self.ans += 1

    def InRange(self, x, y):
        return 0 <= x < self.width and 0 <= y < self.height

    def Movable(self, x, y):
        return not self.visited[y][x] and self.field[y][x] == 1

    def print_result(self):
        print(self.ans)


if __name__ == "__main__":
    tool = OrganicCabbage()

    tool.initialize()

    tool.Play()
