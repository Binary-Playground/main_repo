// https://www.acmicpc.net/problem/1167

#include <iostream>
#include <vector>

using namespace std;

#define NODE first
#define COST second

using NodeToCosts = vector<pair<int, int>>;

// find maximum path sum
pair<int, int> dfs(const vector<NodeToCosts> &V, int curNode, int sum, vector<bool> &vis)
{
    NodeToCosts neighbor = V[curNode];
    if (neighbor.empty())
    {
        return {curNode, sum};
    }

    pair<int, int> ret{curNode, sum};
    for (int i = 0; i < neighbor.size(); i++)
    {
        int nxt = neighbor[i].NODE;

        if (vis[nxt])
            continue;

        vis[nxt] = true;

        int nxtCost = neighbor[i].COST;
        auto p = dfs(V, nxt, sum + nxtCost, vis);

        if (ret.COST < p.COST)
        {
            ret.NODE = p.NODE;
            ret.COST = p.COST;
        }

        vis[nxt] = false;
    }

    return ret;
}

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int V;
    cin >> V;
    // first: node, second: cost
    vector<NodeToCosts> vertices(V + 1);

    for (int i = 0; i < V; i++)
    {
        int num;
        cin >> num;
        vector<int> buff;

        while (true)
        {
            int x;
            cin >> x;
            if (x == -1)
                break;

            buff.push_back(x);
            if (buff.size() == 2)
            {
                vertices[num].push_back({buff[0], buff[1]});
                buff.clear();
            }
        }
    }

    int farNode = -1;
    vector<bool> vis(V + 1, false);

    int ans = -1;
    for (int i = 1; i <= V; i++)
    {
        vis[i] = true;
        auto ret = dfs(vertices, i, 0, vis);
        vis[i] = false;

        if (ret.COST != 0)
        {
            farNode = ret.NODE;
            break;
        }
    }

    vis[farNode] = true;
    cout << dfs(vertices, farNode, 0, vis).COST;

    return 0;
}