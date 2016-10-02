using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("in.txt");
            var parameters = new Parameters(input);
            var size = parameters.CountOfVertices;
            var graph = parameters.Graph;

            var weightMatrix = new int[size,size];
            for (int x = 0; x < size; x++)
            {
                for (int y = x; y < size; y++)
                {
                    if (x == y)
                    {
                        weightMatrix[x,y] = int.MaxValue;
                    }
                    else
                    {
                        var distance = graph[x].GetDistanceToNode(graph[y]);
                        weightMatrix[x,y] = distance;
                        weightMatrix[y,x] = distance;
                    }
                }
            }


            var weight = GetWeight(graph, weightMatrix);
            using (var sw = new StreamWriter("out.txt")) 
            {
                foreach (var node in graph.Values)
                {
                    sw.WriteLine(node.ToString());
                }
                sw.WriteLine(weight);
            }

        }

        private static int GetWeight(Dictionary<int,Node> graph,int[,] weightMatrix)
        {
            List<Node> tree = new List<Node>();
            tree.Add(graph[0]);
            var weight = 0;
            while (tree.Count != graph.Count)
            {
                var minEdge = new MinEdge(int.MaxValue);
                
                foreach (var node in tree)
                {
                    var currentNodeNumber = node.Number;
                    for (int i = 0; i < weightMatrix.GetLength(0); i++)
                    {
                        if (weightMatrix[currentNodeNumber,i] < minEdge.Weight)
                        {
                            minEdge.Weight = weightMatrix[currentNodeNumber,i];
                            minEdge.FromNode = currentNodeNumber;
                            minEdge.ToNode = i;
                        }
                    }
                }

                weightMatrix[minEdge.FromNode,minEdge.ToNode] = int.MaxValue;
                weightMatrix[minEdge.ToNode,minEdge.FromNode] = int.MaxValue;
                
                graph[minEdge.FromNode].IncidentNodes.Add(minEdge.ToNode);
                graph[minEdge.ToNode].IncidentNodes.Add(minEdge.FromNode);
                tree.Add(graph[minEdge.ToNode]);

                weight += minEdge.Weight;
            }
            return weight;
        }
    }
}
