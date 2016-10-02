using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Task1
{


    public class Parameters
    {
        public int CountOfVertices { get; private set; }
        public Dictionary<int,Node> Graph { get; private set; }

        public Parameters(string[] input)
        {
            Graph = new Dictionary<int, Node>();
            CountOfVertices = int.Parse(input[0]);
            for (int i = 0; i < CountOfVertices; i++)
            {
                var point = input[i+1].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s)).ToArray();
                var node = new Node(i, point[0], point[1]);             
                Graph.Add(i,node);
            }
        }
    }
}