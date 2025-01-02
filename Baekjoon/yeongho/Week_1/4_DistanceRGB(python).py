import sys
MAX_VALUE = sys.maxsize
n = int(input())
minSumList = [[MAX_VALUE, MAX_VALUE, MAX_VALUE] for _ in range(n)]
rgbSet = []  # 빨, 초, 파 순으로 입력됨.
for _ in range(n):
    r, g, b = map(int, input().split())
    rgbSet.append([r, g, b])

# 조건
# 1. [1번 집]의 색 != [2번 집]의 색
# 2. [N번 집]의 색 != [N-1번 집]의 색
# 3. [i(2 <= i <= N-1)번 집]의 색 != [i-1번 집]의 색,  != [i+1번 집]의 색

# 첫째줄 미리 세팅
for i in range(3):
    minSumList[0][i] = rgbSet[0][i]

# i번째 선택 시퀀스에서, j번째 집을 선택 했을때 최소 cost 없데이트
for i in range(1, n):
    for j in range(3):
        for k in range(3):
            if j == k:
                continue

            minSumList[i][j] = min(minSumList[i][j], rgbSet[i][j] + minSumList[i-1][k])

print(min(minSumList[n-1]))