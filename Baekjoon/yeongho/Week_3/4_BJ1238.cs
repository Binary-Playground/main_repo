public class BJ1238 : IBaekjoon
{
    private int N, M, X;
    private Dictionary<int, Node> nodeDic;
    private int[,] distance; // 각 마을에서 X 마을 까지 가는 최단거리를 기록해 놓는 2차원 배열
    private int[] backDistance; //X 마을에서 각 마을까지 가는 최단거리
    public void Initialize()
    {
        var dimension = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        (N, M, X) = (dimension[0], dimension[1], dimension[2]);
        
        distance = new int[N + 1, N + 1];
        for (int i = 1; i < N+1; i++)
            for (int j = 1; j < N+1; j++)
                distance[i, j] = int.MaxValue;

        nodeDic = new Dictionary<int, Node>();
        for (int i = 1; i < N+1; i++)
        {
            nodeDic.Add(i, new Node(i));
        }
        
        for (int i = 0; i < M; i++)
        {
            var edge = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            nodeDic[edge[0]].AddLinkNode(edge[1], edge[2]);
        }
    }

    public void Play()
    {
        GetMaxDistanceValue_for_Dijkstra();
    }

    public void Print()
    {
        int ans = 0;
        for (int i = 1; i < N+1; i++)
        {
            if (i == X) continue;

            distance[i, i] = distance[i, X] + distance[X, i]; // 어떤 마을에서 X마을 까지 가는 최단시간 + X 마을에서 i까지 가는 최단 시간
            ans = Math.Max(ans, distance[i, i]);
        }

        Console.WriteLine(ans);
    }

    private void GetMaxDistanceValue_for_Dijkstra()
    {
        PriorityQueue<Node, int> heap = new PriorityQueue<Node, int>();

        for (int i = 1; i < N+1; i++)
        {
            distance[i, i] = 0;
            heap.Enqueue(nodeDic[i], distance[i, i]);
            
            while (heap.Count > 0)
            {
                var outNode = heap.Dequeue();

                foreach (var inNodeIdx in outNode.linkedWeightDic.Keys)
                {
                    Node inNode = nodeDic[inNodeIdx];
                    
                    if (distance[i, inNodeIdx] < distance[i, outNode.index] + outNode.linkedWeightDic[inNode.index]) continue;

                    distance[i, inNodeIdx] = distance[i, outNode.index] + outNode.linkedWeightDic[inNode.index];
                    heap.Enqueue(inNode, distance[i, inNodeIdx]);
                }
            }
        }

        PrintBlock();
    }

    private void PrintBlock()
    {
        Console.WriteLine();

        for (int i = 1; i < N+1; i++)
        {
            for (int j = 1; j < N+1; j++)
            {
                Console.Write($"{distance[i,j]} ");
            }
            Console.WriteLine();
        }
    }

    private class Node
    {
        public int index { get; private set; }
        public Dictionary<int, int> linkedWeightDic;
        
        public Node(int index)
        {
            this.index = index;
            linkedWeightDic = new Dictionary<int, int>();
        }

        public void AddLinkNode(int nodeIdx, int weight)
        {
            linkedWeightDic.Add(nodeIdx, weight);
        }
    }
}