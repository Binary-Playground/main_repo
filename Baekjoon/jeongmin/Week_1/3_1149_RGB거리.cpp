// https://www.acmicpc.net/problem/1149

#include <iostream>
#include <vector>

using namespace std;

const int MX = 100000008;

#define _MIN(x, y, z) min(x, min(y, z))

int boj1149()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N;
    cin >> N;

    // red green blue
    vector<vector<int>> RGB(N, vector<int>(3, 0));
    vector<vector<int>> dp(N, vector<int>(3, MX));

    for (int i = 0; i < N; i++)
    {
        cin >> RGB[i][0] >> RGB[i][1] >> RGB[i][2];
    }

    dp[0][0] = RGB[0][0];
    dp[0][1] = RGB[0][1];
    dp[0][2] = RGB[0][2];

    for (int i = 1; i < N; i++)
    {
        dp[i][0] = RGB[i][0] + min(dp[i - 1][1], dp[i - 1][2]);
        dp[i][1] = RGB[i][1] + min(dp[i - 1][0], dp[i - 1][2]);
        dp[i][2] = RGB[i][2] + min(dp[i - 1][0], dp[i - 1][1]);
    }

    cout << _MIN(dp[N - 1][0], dp[N - 1][1], dp[N - 1][2]);

    return 0;
}