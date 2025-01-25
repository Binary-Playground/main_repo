// https://www.acmicpc.net/problem/1562

#include <iostream>
#include <vector>

using namespace std;

const long long MOD = 1000000000;

#define MASK 1024
#define BIT(x) (1 << x)

// dp[자릿수>=1][끝나는수][사용된수(bitmask)]
long long dp[101][10][MASK];

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N;
    cin >> N;

    for (int i = 0; i < 10; i++)
    {
        if (i == 0)
        {
            dp[1][i][BIT(i)] = 0;
        }
        else
        {
            dp[1][i][BIT(i)] = 1;
        }
    }

    // dp[i][j][bit]
    for (int i = 2; i <= N; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            for (int b = 0; b < 1024; b++)
            {

                int idx = (b | BIT(j));
                if (j == 0)
                {
                    dp[i][j][idx] = (dp[i][j][idx] + dp[i - 1][j + 1][b]) % MOD;
                }
                else if (j == 9)
                {
                    dp[i][j][idx] = (dp[i][j][idx] + dp[i - 1][j - 1][b]) % MOD;
                }
                else
                {
                    dp[i][j][idx] = (dp[i][j][idx] + dp[i - 1][j - 1][b] + dp[i - 1][j + 1][b]) % MOD;
                }
            }
        }
    }

    // calc
    long long ans = 0;
    int full = 0;
    for (int i = 0; i < 10; i++)
        full += (1 << i);

    for (int i = 0; i < 10; i++)
    {
        ans = (ans + dp[N][i][full]) % MOD;
    }

    cout << ans;

    return 0;
}