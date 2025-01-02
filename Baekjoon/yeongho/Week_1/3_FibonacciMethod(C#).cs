/*
 *  날짜 : 2025-01-01
 *  문제 URL : https://www.acmicpc.net/problem/1003
 *  
*/

public class Program
{
    public static void Main()
    {
        FibonacciTool tool = new FibonacciTool();

        //초기화 및 입력
        tool.Initialize();
        
        // 시뮬레이션 시작
        tool.PlayFibonacci();
    }
}

// 메모이제이션만 알면 쉬운 문제.
public class FibonacciTool
{
    private Dictionary<int, (int, int)> memoization_Anser;
    private List<int> caseList;

    // 입력 및 초기화
    public void Initialize()
    {
        memoization_Anser = new Dictionary<int, (int, int)>();
        caseList = new List<int>();

        var caseLength = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < caseLength; i++)
            caseList.Add(int.Parse(Console.ReadLine()));
    }

    // 피보나치 로직 시작
    public void PlayFibonacci()
    {
        foreach (var num in caseList)
        {
            var (zeroCnt, oneCnt) = Fibonacci(num);
            Console.WriteLine($"{zeroCnt} {oneCnt}");
        }
    }

    private (int, int) Fibonacci(int num)
    {
        if (memoization_Anser.ContainsKey(num))
            return memoization_Anser[num];

        if (num == 0)
        {
            memoization_Anser.Add(num, (1, 0));
        }
        else if (num == 1)
        {
            memoization_Anser.Add(num, (0, 1));
        }
        else
        {
            var value1 = Fibonacci(num - 2);
            var value2 = Fibonacci(num - 1);
            var ans = (value1.Item1 + value2.Item1, value1.Item2 + value2.Item2);
            memoization_Anser.Add(num, ans);
        }

        return memoization_Anser[num];
    }
}