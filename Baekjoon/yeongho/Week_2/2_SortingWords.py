# 입력 및 초기화
n = int(input())
words = set()

for _ in range(n):
    word = input()
    if word in words:
        continue

    words.add(word)

wordList = list(words)
wordList.sort(key = lambda x : len(x))

for elem in wordList:
    print(elem)