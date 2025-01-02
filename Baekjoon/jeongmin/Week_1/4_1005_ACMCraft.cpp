// https://www.acmicpc.net/problem/1005

#include <iostream>
#include <vector>
#include <queue>

using namespace std;

const int VISITED = -1;

int boj1005()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int T;
    cin >> T;

    while (T--)
    {
        int N, K;
        cin >> N >> K;

        vector<int> buildTimes(N + 1);
        for (int i = 0; i < N; i++)
            cin >> buildTimes[i + 1];

        // build order
        vector<int> in(N + 1, 0);
        vector<vector<int>> nodes(N + 1);
        vector<vector<int>> outNodes(N + 1);
        for (int i = 0; i < K; i++)
        {
            int X, Y;
            cin >> X >> Y;

            nodes[X].push_back(Y);
            in[Y]++;

            outNodes[Y].push_back(X);
        }

        // build to win
        int W;
        cin >> W;

        int startNode = -1;
        queue<int> Q;
        Q.push(W);

        while (!Q.empty())
        {
            int cur = Q.front();
            Q.pop();

            if (in[cur] == 0)
            {
                startNode = cur;
                break;
            }

            for (int i = 0; i < outNodes[cur].size(); i++)
            {
                Q.push(outNodes[cur][i]);
            }
        }

        while (!Q.empty())
            Q.pop();

        Q.push(startNode);
        queue<int> timeQ;
        timeQ.push(buildTimes[startNode]);

        vector<int> dp(N + 1, -1);
        dp[startNode] = buildTimes[startNode];

        while (!Q.empty())
        {
            int cur = Q.front();
            Q.pop();
            int curTime = timeQ.front();
            timeQ.pop();

            for (int i = 0; i < nodes[cur].size(); i++)
            {
                int nxt = nodes[cur][i];

                in[nxt]--;
                int timeAcc = curTime + buildTimes[nxt];
                dp[nxt] = max(dp[nxt], timeAcc);

                if (in[nxt] == 0)
                {
                    Q.push(nxt);
                    timeQ.push(dp[nxt]);
                }
            }
        }

        cout << dp[W] << '\n';
    }

    return 0;
}