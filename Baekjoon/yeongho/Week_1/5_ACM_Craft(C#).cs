using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        ACMCraftTool simulation = new ACMCraftTool();
        
        simulation.Initialize();
        simulation.Run();
    }
}

public class ACMCraftTool
{
    private int _testCaseCount;
    private Queue<CraftGame> _gameQueue;

    public void Initialize()
    {
        _testCaseCount = int.Parse(Console.ReadLine());
        _gameQueue = new Queue<CraftGame>();

        for (int i = 0; i < _testCaseCount; i++)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int buildingCount = input[0];
            int ruleCount = input[1];

            CraftGame game = new CraftGame(buildingCount, ruleCount);
            game.Initialize();
            _gameQueue.Enqueue(game);
        }
    }

    public void Run()
    {
        while (_gameQueue.Count > 0)
        {
            var game = _gameQueue.Dequeue();
            game.Play();
        }
    }
}

public class CraftGame
{
    private int _buildingCount;
    private int _goalBuilding;
    private Dictionary<int, Node> _nodes;
    private int[] _inDegrees;

    public CraftGame(int buildingCount, int ruleCount)
    {
        _buildingCount = buildingCount;
        _nodes = new Dictionary<int, Node>();
        _inDegrees = new int[buildingCount + 1];
    }

    public void Initialize()
    {
        // 각 건물의 소요 시간 설정
        var buildTimes = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int i = 1; i <= _buildingCount; i++)
        {
            _nodes[i] = new Node(buildTimes[i - 1]);
        }

        // 규칙(간선) 설정
        int ruleCount = _nodes.Count - 1;
        for (int i = 0; i < ruleCount; i++)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int start = input[0];
            int end = input[1];

            _nodes[start].AddEdge(end);
            _inDegrees[end]++;
        }

        // 목표 건물 설정
        _goalBuilding = int.Parse(Console.ReadLine());
    }

    public void Play()
    {
        Queue<int> queue = new Queue<int>();

        // 진입 차수가 0인 노드 추가
        for (int i = 1; i <= _buildingCount; i++)
        {
            if (_inDegrees[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            Node currentNode = _nodes[current];

            foreach (int next in currentNode.Edges)
            {
                _inDegrees[next]--;
                Node nextNode = _nodes[next];
                nextNode.TotalTime = Math.Max(nextNode.TotalTime, currentNode.TotalTime + nextNode.BuildTime);

                if (_inDegrees[next] == 0)
                {
                    queue.Enqueue(next);
                }
            }
        }

        Console.WriteLine(_nodes[_goalBuilding].TotalTime);
    }
}

public class Node
{
    public int BuildTime { get; }
    public int TotalTime { get; set; }
    public List<int> Edges { get; }

    public Node(int buildTime)
    {
        BuildTime = buildTime;
        TotalTime = buildTime;
        Edges = new List<int>();
    }

    public void AddEdge(int target)
    {
        Edges.Add(target);
    }
}
