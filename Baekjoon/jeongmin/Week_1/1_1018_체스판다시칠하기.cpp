// Date: 2024.12.30
// https://www.acmicpc.net/problem/1018

#include <iostream>
#include <vector>
#include <string>

using namespace std;

vector<string> wFirst = {
	"WBWBWBWB",
	"BWBWBWBW",
	"WBWBWBWB",
	"BWBWBWBW",
	"WBWBWBWB",
	"BWBWBWBW",
	"WBWBWBWB",
	"BWBWBWBW"
};
vector<string> bFfirst = {
	"BWBWBWBW",
	"WBWBWBWB",
	"BWBWBWBW",
	"WBWBWBWB",
	"BWBWBWBW",
	"WBWBWBWB",
	"BWBWBWBW",
	"WBWBWBWB"
};

int main() {
	cin.tie(0); ios_base::sync_with_stdio(0);

	int N, M;
	cin >> N >> M;

	vector<string> board(N);
	for (int i = 0; i < N; i++) {
		for (int j = 0; j < M; j++) {
			char c;
			cin >> c;
			board[i].push_back(c);
		}
	}

	int ans = 9999;
	for (int i = 0; i <= N - 8; i++) {
		for (int j = 0; j <= M - 8; j++) {

			int blackCnt = 0;
			int whiteCnt = 0;

			for (int row = i; row < i + 8; row++) {
				for (int col = j; col < j + 8; col++) {
					if (board[row][col] != wFirst[row - i][col - j]) whiteCnt++;
					if (board[row][col] != bFfirst[row - i][col - j]) blackCnt++;
				}
			}

			ans = min(ans, min(blackCnt, whiteCnt));
		}
	}

	cout << ans << '\n';


	return 0;
}