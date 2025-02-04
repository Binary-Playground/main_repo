public class BJ1562 : IBaekjoon
{
    private int n;
    private long[,,] dp; // dp[i, j, bitMask] : 길이가 i이고, 마지막 숫자 j가 왔을때, 지금까지 등장한 숫자를 bitMask로 표현한 경우의 수
    private int mod = 1_000_000_000;
    public void Initialize()
    {
        n = int.Parse(Console.ReadLine().Trim());
        dp = new long[n+1, 10, 1024]; 

        for (int i = 1; i < 10; i++)
        {
            dp[1, i, 1 << i] = 1;
        }
    }

    public void Play()
    {
        for (int i = 2; i < n+1; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int bitmask = 0; bitmask < 1024; bitmask++)
                {
                    int newMask = bitmask | (1 << j);

                    if (j > 0)
                        dp[i, j, newMask] = (dp[i, j, newMask] + dp[i - 1, j - 1, bitmask]) % mod;
                    
                    if (j < 9)
                        dp[i, j, newMask] = (dp[i, j, newMask] + dp[i - 1, j + 1, bitmask]) % mod;
                }
            }
        }
    }

    public void Print()
    {
        long ans = 0;

        for (int j = 0; j < 10; j++)
        {
            ans += dp[n, j, 1023];
            ans %= mod;
        }

        Console.WriteLine(ans);
    }
}