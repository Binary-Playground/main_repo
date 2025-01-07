public class Program
{
    public static void Main()
    {
        SortingWord tool = new SortingWord();

        //초기화 및 입력
        tool.Initialize();
        
        // 시뮬레이션 시작
        tool.StartingSort();
        
        // 프린트
        tool.PrintResult();
    }
}

public class SortingWord
{
    private List<string> words;

    public void Initialize()
    {
        var length = int.Parse(Console.ReadLine());
        var hashsetWords = new HashSet<string>();
        words = new List<string>();
        for (int i = 0; i < length; i++)
        {
            var word = Console.ReadLine();
            if (hashsetWords.Contains(word)) continue;
            hashsetWords.Add(word);
            words.Add(word);
        }
    }

    public void StartingSort()
    {
        words.Sort((word1, word2) =>
        {
            if (word1.Length < word2.Length)
                return -1;
            else if (word1.Length == word2.Length)
            {
                return string.Compare(word1, word2);
            }

            return 1;
        });
    }

    public void PrintResult()
    {
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}