# 입력
n = int(input())
caseList = [int(input()) for _ in range(n)]
memoization = dict() # 피보나치 함수를 돌리때 쓸 해쉬맵


# Fibonacci 함수
def fibonacci(num):
    if num in memoization:
        return memoization[num]

    if num == 0:
        memoization[num] = (1, 0)
    elif num == 1:
        memoization[num] = (0, 1)
    else:
        value1 = fibonacci(num-2)
        value2 = fibonacci(num-1)
        value = (value1[0] + value2[0], value1[1] + value2[1])
        memoization[num] = value
    return memoization[num]


for elem in caseList:
    ans = fibonacci(elem)
    print(ans[0], ans[1])