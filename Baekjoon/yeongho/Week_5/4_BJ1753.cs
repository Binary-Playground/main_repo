using System.Text;

public class BJ1753 : IBaejoon
{
    private int[] vertex;
    private bool[] visited;
    private int StartVertex;
    private Dictionary<int, List<(int, int)>> edges;

    public void Initialize()
    {
        var inputs = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        var (v, e) = (inputs[0], inputs[1]);
        vertex = new int[v + 1];
        Array.Fill(vertex, int.MaxValue);
        visited = new bool[v + 1];

        StartVertex = int.Parse(Console.ReadLine().Trim());
        vertex[StartVertex] = 0;
        edges = new Dictionary<int, List<(int, int)>>();
        for (int i = 0; i < e; i++)
        {
            var edge = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            var (start, end, weight) = (edge[0], edge[1], edge[2]);
            if(!edges.ContainsKey(start))
                edges.Add(start, new List<(int, int)>());
            
            edges[start].Add((end, weight));
        }
    }

    public void Play()
    {
        PriorityQueue<int, int> pQueue = new PriorityQueue<int, int>();
        pQueue.Enqueue(StartVertex, 0);

        while (pQueue.Count > 0)
        {
            var curVertex = pQueue.Dequeue();
            
            if (visited[curVertex]) continue;
            visited[curVertex] = true;
            
            if (!edges.ContainsKey(curVertex)) continue;
            
            foreach (var (endV, weight) in edges[curVertex])
            {
                if (vertex[endV] > vertex[curVertex] + weight)
                {
                    vertex[endV] = vertex[curVertex] + weight;
                    if (!visited[endV])
                        pQueue.Enqueue(endV, vertex[endV]);
                }
            }
        }
    }

    public void Print()
    {
        StringBuilder sb = new StringBuilder();
        for (int j = 1; j < vertex.Length; j++)
        {
            sb.AppendLine(vertex[j] < int.MaxValue ? vertex[j].ToString( ): "INF");
        }
        Console.WriteLine(sb.ToString());
    }
}