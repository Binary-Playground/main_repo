public class BJ1629 : IBaejoon
{
    private int num, n, divider;
    private long ans;
    public void Initialize()
    {
        var dimension = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        num = dimension[0];
        n = dimension[1];
        divider = dimension[2];
    }

    public void Play()
    {
        ans = Multiply(n);
    }

    public void Print()
    {
        Console.WriteLine(ans);
    }

    private long Multiply(int cnt)
    {
        if (cnt == 0)
            return 1;

        var halfResult = Multiply(cnt / 2) % divider;
        
        long result = halfResult * halfResult % divider;
        
        if (cnt % 2 != 0)
            return result * (num % divider) % divider;

        return result;
    }
}