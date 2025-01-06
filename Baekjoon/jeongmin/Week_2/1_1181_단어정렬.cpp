#include <iostream>
#include <vector>
#include <string>
#include <set>
#include <algorithm>

using namespace std;

int main()
{
    cin.tie(0);
    ios_base::sync_with_stdio(0);

    int N;
    cin >> N;
    vector<string> words;
    set<string> S;

    for (int i = 0; i < N; i++)
    {
        string s;
        cin >> s;
        if (S.find(s) == S.end())
        {
            words.push_back(s);
            S.insert(s);
        }
    }

    sort(words.begin(), words.end(),
         [](const string &s1, const string &s2)
         {
             int size1 = s1.size();
             int size2 = s2.size();

             if (size1 == size2)
             {
                 return s1 < s2;
             }
             else
                 return size1 < size2;
         });

    for (string &w : words)
    {
        cout << w << '\n';
    }

    return 0;
}