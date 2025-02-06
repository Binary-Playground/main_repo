using System.Text;

public class BJ1764 : IBaejoon
{
    private HashSet<string> noListenSet, noLookingSet;
    private List<string> noLLSet;
    public void Initialize()
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        var (n, m) = (input[0], input[1]);
        noListenSet = new HashSet<string>();
        noLookingSet = new HashSet<string>();
        noLLSet = new List<string>(500_000);
        for (int i = 0; i < n; i++)
            noListenSet.Add(Console.ReadLine().Trim());
        for (int i = 0; i < m; i++)
            noLookingSet.Add(Console.ReadLine().Trim());
    }

    public void Play()
    {
        if (noListenSet.Count > noLookingSet.Count)
        {
            foreach (var element in noLookingSet)
            {
                if (noListenSet.Contains(element))
                    noLLSet.Add(element);
            }
        }
        else
        {
            foreach (var element in noListenSet)
            {
                if (noLookingSet.Contains(element))
                    noLLSet.Add(element);
            }
        }
        
        noLLSet.Sort();
    }

    public void Print()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(noLLSet.Count.ToString());
        foreach (string element in noLLSet)
        {
            sb.AppendLine(element);
        }
        Console.WriteLine(sb.ToString());
    }
}