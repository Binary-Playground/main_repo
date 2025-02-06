public class BJ1697 : IBaekjoon
{
    private int LengthRange = 100_000;
    private int[] dp;
    private int pos_f, pos_c;
    
    public void Initialize()
    {
        dp = new int[LengthRange+1];
        Array.Fill(dp, -1);

        int[] dimension = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        (pos_f, pos_c) = (dimension[0], dimension[1]);
    }

    public void Play()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(pos_f);
        dp[pos_f] = 0;

        while (queue.Count > 0)
        {
            int currentPos = queue.Dequeue();

            foreach (int next in new int[] {currentPos-1, currentPos+1, currentPos*2})
            {
                if (!InRange(next) || dp[next] != -1) continue;

                dp[next] = dp[currentPos] + 1;
                queue.Enqueue(next);
            }
        }

    }

    public void Print()
    {
        Console.WriteLine(dp[pos_c]);
    }

    private bool InRange(int x)
    {
        return x >= 0 && x <= LengthRange;
    }
}