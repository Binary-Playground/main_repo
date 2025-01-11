using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        BJ1197 simulation = new BJ1197();
        
        simulation.Initialize();
        simulation.StartSimulation();
        simulation.PrintResult();
    }
}

public class BJ1197
{
    private Dictionary<int, Node> nodeDic;
    private int[] distNodes;
    
    //입력 및 초기화
    public void Initialize()
    {
        var dimensions = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int nodes = dimensions[0] + 1;
        int edges = dimensions[1];
        distNodes = new int[nodes];
        
        nodeDic = new Dictionary<int, Node>();
        distNodes[0] = 0;
        for (int i = 1; i < nodes; i++)
        {
            nodeDic.Add(i, new Node(i));
            distNodes[i] = int.MaxValue;
        }

        for (int i = 0; i < edges; i++)
        {
            var inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int firstNode = inputs[0];
            int secondNode = inputs[1];
            int distance = inputs[2];
            nodeDic[firstNode].AddLink(secondNode, distance);
            nodeDic[secondNode].AddLink(firstNode, distance);
        }
    }

    public void StartSimulation()
    {
        //첫 노드의 거리는 0 으로 설정하고 시작
        if(nodeDic[1].linkedNode.ContainsKey(1)) // 본인 노드로 가는 간선을 가지고 있다면 해당 간선으로 업데이트
            distNodes[1] = nodeDic[1].linkedNode[1];
        else // 아니라면 0 처리
            distNodes[1] = 0;
        
        //프림 알고리즘을 돌린 후
        Prim();
    }

    private void Prim()
    {
        var priorityQueue = new PriorityQueue<Node, int>();
        
        foreach (var nodeDicValue in nodeDic.Values)
        {
            priorityQueue.Enqueue(nodeDicValue, distNodes[nodeDicValue.index]);
        }
        
        while (priorityQueue.Count > 0)
        {
            Node curNode = priorityQueue.Dequeue(); // 1부터 나옴.
            if (curNode.isVisited) continue;
            
            curNode.isVisited = true;
            
            //연결되어 있는 노드들을 탐색하며 가중치 업데이트 + Q에 넣어주기
            foreach(var nodeIdx in curNode.linkedNode.Keys)
            {
                if (nodeDic[nodeIdx].isVisited) continue;

                distNodes[nodeIdx] = Math.Min(distNodes[nodeIdx], curNode.linkedNode[nodeIdx]);
                priorityQueue.Enqueue(nodeDic[nodeIdx], distNodes[nodeIdx]);
            }
        }
    }

    public void PrintResult()
    {
        Console.WriteLine(distNodes.Sum());
    }

    public class Node
    {
        public int index;
        public Dictionary<int, int> linkedNode;
        public bool isVisited;
        public Node(int idx)
        {
            index = idx;
            linkedNode = new Dictionary<int, int>();
            isVisited = false;
        }

        public void AddLink(int nodeIdx, int distance)
        {
            if (linkedNode.ContainsKey(nodeIdx))
            {
                linkedNode[nodeIdx] = Math.Min(linkedNode[nodeIdx], distance);
                return;
            }
                
            linkedNode.Add(nodeIdx, distance);
        }
    }
}