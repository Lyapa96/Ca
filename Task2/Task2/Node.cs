using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class Node
    {
        public List<Edge> Edges = new List<Edge>();

        public readonly int NodeNumber;
        public Color Color;
        public TypeSet Set;

        public Node BlackY;
        public Node BlackX;

        public Node(int number,TypeSet type)
        {
            NodeNumber = number;
            Set = type;
        }
        
        public Edge GiveEdge(Node otherNode)
        {
            return Edges.First(e => e.Y == otherNode);
        }

        public override string ToString()
        {
            return NodeNumber.ToString();
        }
    }
}