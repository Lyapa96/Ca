using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{   
    public class Graph
    {
        private List<Node> nodes = new List<Node>();

        public Graph(int[] setX, int[] setY, Dictionary<int, List<int>> adjacencyListForSetY)
        {
            foreach (var x in setX)
            {
                nodes.Add(new Node(x,TypeSet.X));
            }
            foreach (var y in setY)
            {
                nodes.Add(new Node(y, TypeSet.Y));
            }
            foreach (var x in adjacencyListForSetY.Keys)
            {
                var nodeY = nodes.First(yNode => yNode.NodeNumber == x && yNode.Set==TypeSet.Y);
                foreach (var y in adjacencyListForSetY[x])
                {
                    var nodeX = nodes.First(yNode => yNode.NodeNumber == y && yNode.Set == TypeSet.X);
                    var edge = new Edge(nodeX,nodeY);
                    nodeX.Edges.Add(edge);
                    nodeY.Edges.Add(edge);
                }
            }

        }

        public int Length => nodes.Count;

        public Node this[int index] => nodes[index];
        public IEnumerable<Node> Nodes => nodes;


        public IEnumerable<Node> GetSetX()
        {
            return nodes.Where(x => x.Set == TypeSet.X);
        }
    }
}