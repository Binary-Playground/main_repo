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
        for (int i = 0; i < length; i++)
        {
            var word = Console.ReadLine();
            hashsetWords.Add(word);
        }

        words = new List<string>(hashsetWords);
    }

    public void StartingSort()
    {
        // 또는 LINQ 방식으로 더 깔끔하게
        // List<string> wordList = words.OrderBy(x => x.Length).ThenBy(x => x).ToList();
        //words = wordList;

        words.Sort((word1, word2) =>
        {
            var lengthComparison = word1.Length.CompareTo(word2.Length);
            return lengthComparison != 0 ? lengthComparison : word1.CompareTo(word2);
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