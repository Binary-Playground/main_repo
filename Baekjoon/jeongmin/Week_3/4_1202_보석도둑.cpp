#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>

using namespace std;
using MV = pair<int, int>;

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N, K;
    cin >> N >> K;

    priority_queue<MV, vector<MV>, greater<MV>> minHeap;
    for (int i = 0; i < N; i++)
    {
        int M, V;
        cin >> M >> V;
        minHeap.push({M, V});
    }

    vector<int> capa;
    for (int i = 0; i < K; i++)
    {
        int C;
        cin >> C;
        capa.push_back(C);
    }
    sort(capa.begin(), capa.end());

    long long sum = 0;
    priority_queue<int> maxHeap;

    for (int i = 0; i < K; i++)
    {
        int curCapa = capa[i];

        while (!minHeap.empty() && minHeap.top().first <= curCapa)
        {
            auto cur = minHeap.top();
            minHeap.pop();
            if (cur.first <= curCapa)
            {
                maxHeap.push(cur.second);
            }
        }

        if (!maxHeap.empty())
        {
            sum += (long long)(maxHeap.top());
            maxHeap.pop();
        }
    }

    cout << sum << '\n';

    return 0;
}