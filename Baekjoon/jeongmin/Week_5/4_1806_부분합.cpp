#include <iostream>
#include <vector>

using namespace std;

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N, S;
    cin >> N >> S;

    vector<int> V(N + 1);
    for (int i = 0; i < N; i++)
        cin >> V[i];

    int st = 0;
    int en = 0;
    int sum = 0;
    int length = 100001;

    while (en < N)
    {
        if (sum < S)
        {
            sum += V[en++];
            continue;
        }

        // sum >= S
        // cout << st << ' ' << en - 1 << '\n';
        length = min(length, en - st);

        sum -= V[st++];
    }

    while (sum >= S)
    {
        length = min(length, en - st);
        sum -= V[st++];
    }

    cout << ((length == 100001) ? 0 : length);

    return 0;
}