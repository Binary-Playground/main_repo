# 입력 및 초기화
n = int(input())
words = set()

for _ in range(n):
    word = input()
    words.add(word)

wordList = list(words)
wordList.sort()
wordList.sort(key=lambda x: len(x))

for elem in wordList:
    print(elem)