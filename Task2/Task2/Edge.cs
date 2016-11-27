using System;

namespace Task2
{
    public class Edge
    {
        public readonly Node X;
        public readonly Node Y;
        public int Weight;
        public bool White;

        public Edge(Node first, Node second, int weight = 1)
        {
            this.X = first;
            this.Y = second;
            Weight = weight;
        }

        public bool IsIncident(Node node)
        {
            return X == node || Y == node;
        }

        public Node OtherNode(Node node)
        {
            if (!IsIncident(node)) throw new ArgumentException();
            if (X == node) return Y;
            return X;
        }
    }
}