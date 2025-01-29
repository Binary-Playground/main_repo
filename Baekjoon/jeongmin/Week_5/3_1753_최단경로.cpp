#include <iostream>
#include <vector>
#include <queue>

using namespace std;

#define COST first
#define NODE second

const int INF = 99999999;
using CostNode = pair<int, int>;

int main()
{
    int V, E;
    cin >> V >> E;

    // start node
    int K;
    cin >> K;

    vector<vector<CostNode>> graph(V + 1);
    for (int i = 0; i < E; i++)
    {
        int u, v, w;
        cin >> u >> v >> w;

        // cost node
        graph[u].push_back({w, v});
    }

    vector<int> dist(V + 1, INF);
    priority_queue<CostNode, vector<CostNode>, greater<CostNode>> pq;

    pq.push({0, K});
    dist[K] = 0;

    while (!pq.empty())
    {
        auto cur = pq.top();
        pq.pop();

        int curNode = cur.NODE;
        int curCost = cur.COST;
        // cout << "cur: " << curNode << '\n';

        for (int i = 0; i < graph[curNode].size(); i++)
        {
            int nxtNode = graph[curNode][i].NODE;
            int nxtCost = graph[curNode][i].COST;

            if (dist[nxtNode] > curCost + nxtCost)
            {
                // cout << "nxt: " << nxtNode << '\n';
                dist[nxtNode] = curCost + nxtCost;
                pq.push({dist[nxtNode], nxtNode});
            }
        }
    }

    for (int i = 1; i <= V; i++)
    {
        if (dist[i] == INF)
            cout << "INF\n";
        else
            cout << dist[i] << ' ';
    }

    return 0;
}