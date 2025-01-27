#include <iostream>
#include <set>

using namespace std;

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N;
    cin >> N;
    set<int> S;

    for (int i = 0; i < N; i++)
    {
        int num;
        cin >> num;
        if (S.find(num) == S.end())
        {
            S.insert(num);
        }
    }

    int M;
    cin >> M;
    for (int i = 0; i < M; i++)
    {
        int num;
        cin >> num;

        if (S.find(num) == S.end())
        {
            cout << 0 << '\n';
        }
        else
        {
            cout << 1 << '\n';
        }
    }

    return 0;
}