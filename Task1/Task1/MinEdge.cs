using System.Security.Cryptography;

namespace Task1
{
    public class MinEdge
    {
        public int Weight { get; set; } 
        public int FromNode { get; set; }
        public int ToNode { get; set; }

        public MinEdge(int weight)
        {
            Weight = weight;
        }
    }
}