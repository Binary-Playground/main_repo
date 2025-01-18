#include <iostream>
#include <vector>
#include <queue>

using namespace std;

using CostNode = pair<int, int>;
const int INF = 999999999;

int N, M, X;
vector<vector<pair<int, int>>> graph;

int findPath(int here, int to)
{
    if (here == to)
        return INF;

    priority_queue<CostNode, vector<CostNode>, greater<CostNode>> pq;
    vector<int> dist(N + 1, INF);
    pq.push({0, here});
    dist[here] = 0;

    while (!pq.empty())
    {
        auto cur = pq.top();
        pq.pop();
        int curSum = cur.first;
        int curNode = cur.second;

        if (curNode == to)
            break;

        for (int i = 0; i < graph[curNode].size(); i++)
        {
            int nxtNode = graph[curNode][i].second;
            int nxtCost = graph[curNode][i].first;

            if (curSum + nxtCost >= dist[nxtNode])
                continue;

            pq.push({curSum + nxtCost, nxtNode});
            dist[nxtNode] = curSum + nxtCost;
        }
    }

    return dist[to];
}

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    cin >> N >> M >> X;

    graph.resize(N + 1);
    for (int i = 0; i < M; i++)
    {
        int st, en, time;
        cin >> st >> en >> time;

        graph[st].push_back({time, en});
    }

    // i to X
    int node = -1;
    int pathSum = 0;
    for (int i = 1; i <= N; i++)
    {
        if (i == X)
            continue;
        int sum1 = findPath(i, X);
        int sum2 = findPath(X, i);

        if (sum1 + sum2 > pathSum)
        {
            node = i;
            pathSum = sum1 + sum2;
        }
    }

    cout << pathSum;

    return 0;
}