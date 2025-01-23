public class BJ1463 : IBaekjoon
{
    private int number;
    private int ans;
    

    public void Initialize()
    {
        number = int.Parse(Console.ReadLine().Trim());
    }

    public void Play()
    {
        ans = GetCalculate(number);
    }

    public void Print()
    {
        Console.WriteLine(ans);
    }

    private int GetCalculate(int num)
    {
        int[] dp = new int[num + 1];
        for (int i = 0; i < num+1; i++)
            dp[i] = int.MaxValue;

        dp[^1] = 0;
        for (int i = num; i >= 1; i--)
        {
            if (i % 3 == 0)
                dp[i / 3] = Math.Min(dp[i / 3], dp[i] + 1);
            
            if(i%2 == 0)
                dp[i / 2] = Math.Min(dp[i / 2], dp[i] + 1);
            
            dp[i - 1] = Math.Min(dp[i - 1], dp[i] + 1);
        }

        return dp[1];
    }
}