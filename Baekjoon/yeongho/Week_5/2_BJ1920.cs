using System.Text;

public class BJ1920 : IBaekjoon
{
    private int n, m;
    private int[] targetArray;
    private HashSet<int> _hashSet;
    public void Initialize()
    {
        n = int.Parse(Console.ReadLine().Trim());
        
        _hashSet = new HashSet<int>();
        string[] elements = Console.ReadLine().Trim().Split();
        foreach (string element in elements)
            _hashSet.Add(int.Parse(element));
        
        m = int.Parse(Console.ReadLine().Trim());
        targetArray = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
    }

    public void Play()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < m; i++)
        {
            sb.AppendLine(_hashSet.Contains(targetArray[i]) ? "1" : "0");
        }
        Console.WriteLine(sb.ToString());
    }

    public void Print()
    {
        
    }
}