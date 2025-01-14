#include <iostream>
#include <string>

using namespace std;

bool isPalindrom(const string &str)
{
    int idx1 = 0;
    int idx2 = str.size() - 1;

    while (idx1 <= idx2)
    {
        if (str[idx1] != str[idx2])
            return false;
        idx1++;
        idx2--;
    }

    return true;
}

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    while (true)
    {
        string str;
        cin >> str;

        if (str == "0")
            break;

        if (isPalindrom(str))
        {
            cout << "yes\n";
        }
        else
        {
            cout << "no\n";
        }
    }

    return 0;
}