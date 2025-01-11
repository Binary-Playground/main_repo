from enum import Enum, auto
import sys

class Color(Enum):
    White = auto()
    Black = auto()


# 입력 및 초기화
RowSize, ColSize = map(int, input().split())
inputBoard = [input() for _ in range(RowSize)]
boardRrr = [[Color.White if inputBoard[r][c] == 'W' else Color.Black for c in range(ColSize)] for r in range(RowSize)]
W_ChessBoard = [[0 for _ in range(ColSize)] for _ in range(RowSize)] # 하얀색으로 시작하는 체스 블럭
B_ChessBoard = [[0 for _ in range(ColSize)] for _ in range(RowSize)] # 검은색으로 시작하는 체스 블럭
minCost = sys.maxsize

def GetOppositeColor(color):
    return Color.White if color is Color.Black else Color.Black


def CalculateCost(r, c, startWithWhite):
    totalCost = W_ChessBoard[r][c] if startWithWhite else B_ChessBoard[r][c]

    if r >= 8:
        totalCost -= W_ChessBoard[r-8][c] if startWithWhite else B_ChessBoard[r-8][c]
    if c >= 8:
        totalCost -= W_ChessBoard[r][c-8] if startWithWhite else B_ChessBoard[r][c-8]
    if r >= 8 and c >= 8:
        totalCost += W_ChessBoard[r-8][c-8] if startWithWhite else B_ChessBoard[r-8][c-8]

    return totalCost


# Row * Col 만큼 탐색 하면서 칠해야 하는 Block 누적량 계산 해주기
# 1. 흰색 부터 칠해 졌을때
# 2. 검은색 부터 칠해 졌을떄
for r in range(RowSize):
    for c in range(ColSize):
        expectedColorWhite = Color.White if (r+c) % 2 == 0 else Color.Black # 하얀색으로 시작했을때
        expectedColorBlack = GetOppositeColor(expectedColorWhite)           # 검은색으로 사작했을때

        W_ChessBoard[r][c] = ((W_ChessBoard[r-1][c] if r > 0 else 0) +
                              (W_ChessBoard[r][c-1] if c > 0 else 0) -
                              (W_ChessBoard[r-1][c-1] if r > 0 and c > 0 else 0) +
                              (0 if boardRrr[r][c] == expectedColorWhite else 1))

        B_ChessBoard[r][c] = ((B_ChessBoard[r-1][c] if r > 0 else 0) +
                              (B_ChessBoard[r][c-1] if c > 0 else 0) -
                              (B_ChessBoard[r-1][c-1] if r > 0 and c > 0 else 0) +
                              (0 if boardRrr[r][c] == expectedColorBlack else 1))

# 최소값 찾기
for r in range(7, RowSize):
    for c in range(7, ColSize):
        whiteCost = CalculateCost(r, c, True)
        blackCost = CalculateCost(r, c, False)

        minCost = min(minCost, whiteCost, blackCost)

print(minCost)