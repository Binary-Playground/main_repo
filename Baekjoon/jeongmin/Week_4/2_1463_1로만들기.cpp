#include <iostream>
#include <vector>

using namespace std;

const int INF = 9999999;

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N;
    cin >> N;

    vector<int> dp(N + 1, INF);
    dp[1] = 0;

    for (int i = 2; i <= N; i++)
    {
        if (i % 3 == 0)
        {
            dp[i] = min(dp[i / 3] + 1, dp[i]);
        }

        if (i % 2 == 0)
        {
            dp[i] = min(dp[i / 2] + 1, dp[i]);
        }

        dp[i] = min(dp[i - 1] + 1, dp[i]);
    }

    cout << dp[N] << '\n';
    // for (int i = 1; i <= N; i++) {
    //	cout << dp[i] << ' ';
    // }

    return 0;
}