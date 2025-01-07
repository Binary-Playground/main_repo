#include <iostream>
#include <vector>
#include <queue>

using namespace std;

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int T;
    cin >> T;
    while (T--)
    {
        int M, N, K;
        cin >> M >> N >> K;

        vector<vector<int>> board(M, vector<int>(N, 0));
        for (int i = 0; i < K; i++)
        {
            int x, y;
            cin >> x >> y;
            board[x][y] = 1;
        }

        vector<vector<bool>> vis(M, vector<bool>(N, false));
        int cnt = 0;
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (board[i][j] == 0)
                    continue;
                if (vis[i][j] == true)
                    continue;
                cnt++;
                queue<pair<int, int>> Q;
                Q.push({i, j});
                vis[i][j] = true;

                static const int dx[4] = {-1, 0, 1, 0};
                static const int dy[4] = {0, 1, 0, -1};

                while (!Q.empty())
                {
                    auto cur = Q.front();
                    Q.pop();

                    for (int dir = 0; dir < 4; dir++)
                    {
                        int nx = cur.first + dx[dir];
                        int ny = cur.second + dy[dir];

                        if (nx < 0 || nx >= M || ny < 0 || ny >= N)
                            continue;
                        if (vis[nx][ny] == true)
                            continue;
                        if (board[nx][ny] == 0)
                            continue;

                        Q.push({nx, ny});
                        vis[nx][ny] = true;
                    }
                }
            }
        }

        cout << cnt << '\n';
    }

    return 0;
}