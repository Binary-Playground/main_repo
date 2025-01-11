class Program
{
    public static void Main()
    {
        BJ1167 simulation = new BJ1167();
        
        simulation.Initialize();
        simulation.StartSimulation();
    }
}

public class BJ1167
{
    private Node2 bestFarNode;
    private int distanceValue;
    private Dictionary<int, Node2> nodeDic;

    public void Initialize()
    {
        int nodeCnt = int.Parse(Console.ReadLine());
        nodeDic = new Dictionary<int, Node2>();
        for (int i = 1; i < nodeCnt + 1; i++)
        {
            nodeDic.Add(i, new Node2(i));
        }

        for (int i = 1; i < nodeCnt + 1; i++)
        {
            var dimensions = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int j = 1;
            var nodeIdx = dimensions[0];
            do
            {
                nodeDic[nodeIdx].AddNodeLinked(dimensions[j], dimensions[j + 1]);
                j += 2;
            } while (dimensions[j] != -1);
        }
    }
    
    public void StartSimulation()
    {
        // 1. 노드부터 시작하여 가장 깊이있는 노드를 찾는다.
        BFS(nodeDic[1]);

        ResetNode();
        
        // 2. 가장 깊이 있는 노드부터 시작해서 거꾸러 찾아 올라간다.
        BFS(bestFarNode);

        Console.WriteLine(distanceValue);
    }

    private void BFS(Node2 node)
    {
        Queue<Node2> qList = new Queue<Node2>();
        qList.Enqueue(node);
        node.isVisited = true;

        while (qList.Count > 0)
        {
            Node2 curNode = qList.Dequeue();
            foreach (var key in curNode.linkedNodeList.Keys)
            {
                if (nodeDic[key].isVisited) continue;
                
                nodeDic[key].isVisited = true;
                nodeDic[key].accumulatedSum = curNode.accumulatedSum + curNode.linkedNodeList[key];
                if (distanceValue < nodeDic[key].accumulatedSum)
                {
                    distanceValue = nodeDic[key].accumulatedSum;
                    bestFarNode = nodeDic[key];
                }
                
                qList.Enqueue(nodeDic[key]);
            }
        }
    }

    private void ResetNode()
    {
        foreach (var nodeDicValue in nodeDic.Values)
        {
            nodeDicValue.isVisited = false;
            nodeDicValue.accumulatedSum = 0;
        }
    }
    
    class Node2
    {
        public int index;           //노드의 인덱스
        public int accumulatedSum; // 누적합
        public bool isVisited;      // 방문 유무
        public Dictionary<int, int> linkedNodeList; // key : idx, value : distance

        public Node2(int idx)
        {
            index = idx;
            accumulatedSum = 0;
            isVisited = false;
            linkedNodeList = new Dictionary<int, int>();
        }

        public void AddNodeLinked(int node, int dist)
        {
            linkedNodeList.Add(node, dist);
        }
    }
    
}

