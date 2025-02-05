public class BJ1978 : IBaekjoon
{
    private bool[] notPrimeNumvers = new bool[1001];
    private int n, ans;
    private int[] numbers;
    private HashSet<int> primeNumSet;
    public void Initialize()
    {
        n = int.Parse(Console.ReadLine().Trim());
        numbers = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        ans = 0;
        primeNumSet = new HashSet<int>();
        notPrimeNumvers[0] = true;
        notPrimeNumvers[1] = true;
        for (int i = 2; i <= 1000; i++)
        {
            if (notPrimeNumvers[i]) continue;

            primeNumSet.Add(i);
            SetPrimeNum(i, 2);
        }
    }

    public void Play()
    {
        foreach (int number in numbers)
        {
            if (!primeNumSet.Contains(number)) continue;

            ans += 1;
        }
    }
    
    public void Print()
    {
        Console.WriteLine(ans);
    }
    
    private void SetPrimeNum(int num, int cnt)
    {
        if (num * cnt >1000)
            return;

        notPrimeNumvers[num * cnt] = true;
        SetPrimeNum(num, cnt+1);
    }
}