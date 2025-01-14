#include <iostream>

using namespace std;

int cnt = 0;

void funcZ(int len, int row, int col, int x, int y)
{
    if (row == x && col == y)
    {
        cout << cnt << '\n';
        return;
    }

    if (len == 1)
    {
        cnt++;
        return;
    }

    // find area
    int half = len / 2;
    int bulk = half * half;

    if ((x <= row && row < x + half) && (y <= col && col < y + half))
    {
        // left top
        funcZ(half, row, col, x, y);
    }
    else if ((x <= row && row < x + half) && (y + half <= col && col < y + 2 * half))
    {
        // right top
        cnt += bulk;
        funcZ(half, row, col, x, y + half);
    }
    else if ((x + half <= row && row < x + 2 * half) && (y <= col && col < y + half))
    {
        cnt += bulk * 2;
        // left bottom
        funcZ(half, row, col, x + half, y);
    }
    else if ((x + half <= row && row < x + 2 * half) && (y + half <= col && col < y + 2 * half))
    {
        cnt += bulk * 3;
        // right bottom
        funcZ(half, row, col, x + half, y + half);
    }
}

int boj1074()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N, r, c;
    cin >> N >> r >> c;

    int len = (1 << N);

    funcZ(len, r, c, 0, 0);

    return 0;
}