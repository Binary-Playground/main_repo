#include <iostream>
#include <queue>

using namespace std;

const int MX = 1000001;

#define POS first
#define SEC second

int vis[MX];

bool inRange(int pos)
{
    return (0 <= pos && pos < MX);
}

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N, K;
    cin >> N >> K;

    fill(vis, vis + MX, -1);

    // pos, time
    queue<pair<int, int>> Q;
    Q.push({N, 0});

    while (!Q.empty())
    {
        auto cur = Q.front();
        Q.pop();

        if (cur.POS == K)
        {
            cout << cur.SEC << '\n';
            break;
        }

        // +1
        int nxt = cur.POS + 1;
        if (inRange(nxt))
        {
            if (vis[nxt] == -1)
            {
                vis[nxt] = cur.SEC + 1;
                Q.push({nxt, vis[nxt]});
            }
        }

        // -1
        nxt = cur.POS - 1;
        if (inRange(nxt))
        {
            if (vis[nxt] == -1)
            {
                vis[nxt] = cur.SEC + 1;
                Q.push({nxt, vis[nxt]});
            }
        }

        // *2
        nxt = cur.POS * 2;
        if (inRange(nxt))
        {
            if (vis[nxt] == -1)
            {
                vis[nxt] = cur.SEC + 1;
                Q.push({nxt, vis[nxt]});
            }
        }
    }

    return 0;
}