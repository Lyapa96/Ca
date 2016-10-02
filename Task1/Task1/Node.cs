using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Task1
{
    public class Node
    {
        public int Number { get; set; }
        public Point Location { get; set; }
        public List<int> IncidentNodes { get; set; } = new List<int>();

        public Node(int number, int x, int y)
        {
            Number = number;
            Location = new Point(x,y);
        }

        public int GetDistanceToNode(Node otherNode)
        {
            return Math.Abs(otherNode.Location.X - Location.X) + Math.Abs(otherNode.Location.Y - Location.Y);
        }

        public override string ToString()
        {
            var sortedNodes = IncidentNodes.Select(x => x + 1).OrderBy(x => x);
            var strBuilder = new StringBuilder();
            foreach (var node in sortedNodes)
            {
                strBuilder.Append(node);
                strBuilder.Append(" ");
            }
            strBuilder.Append("0");
            return strBuilder.ToString();
        }
    }
}