#include <iostream>
#include <queue>
#include <algorithm>
#include <vector>

using namespace std;
using CostNode = pair<int, int>;

#define COST first
#define NODE second

int MST()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int V, E;
    cin >> V >> E;

    vector<vector<CostNode>> graph(V + 1);
    for (int i = 0; i < E; i++)
    {
        int A, B, C;
        cin >> A >> B >> C;
        graph[A].push_back({C, B});
        graph[B].push_back({C, A});
    }

    priority_queue<CostNode, vector<CostNode>, greater<CostNode>> pq;
    vector<bool> vis(V + 1, false);
    int sum = 0;
    // current cost - current node
    pq.push({0, 1});

    while (!pq.empty())
    {
        auto cur = pq.top();
        pq.pop();

        if (vis[cur.NODE])
            continue;

        sum += cur.COST;
        vis[cur.NODE] = true;

        for (int i = 0; i < graph[cur.NODE].size(); i++)
        {
            auto nxtPair = graph[cur.NODE][i];

            if (vis[nxtPair.NODE])
                continue;

            pq.push({nxtPair});
        }
    }

    cout << sum << '\n';

    return 0;
}
