#include <iostream>
#include <vector>

using namespace std;

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N;
    cin >> N;
    int high = -1;
    vector<int> V;
    for (int i = 0; i < N; i++)
    {
        int g;
        cin >> g;
        if (g > high)
            high = g;
        V.push_back(g);
    }

    double sum = 0;
    for (int i = 0; i < N; i++)
    {
        int score = V[i];

        double d = (double)score / (double)high * 100.0;
        sum += d;
    }

    cout << sum / (double)N;

    return 0;
}