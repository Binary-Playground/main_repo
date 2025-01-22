#include <iostream>
#include <vector>

using namespace std;

long long mul(int base, int exp, int mod)
{
    if (exp == 0)
        return 1;
    if (exp == 1)
        return base % mod;

    int half = exp / 2;
    long long tmp = (mul(base, half, mod) * mul(base, half, mod)) % mod;
    if (exp % 2 != 0)
    {
        tmp = ((tmp % mod) * (base % mod)) % mod;
    }

    return tmp;
}

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int A, B, C;
    cin >> A >> B >> C;

    cout << mul(A, B, C);

    return 0;
}