using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using NUnit.Framework;

namespace Task2
{
    public class Algorithm
    {
        public static Tuple<bool, List<int>> Khun(List<int> setX, List<int> setY,
            Dictionary<int, List<int>> adjacencyListForSetY)
        {
            var graph = new Graph(setX.ToArray(), setY.ToArray(), adjacencyListForSetY);

            foreach (var xNode in graph.GetSetX())
            {
                if (!Dfs(xNode))
                {
                    return Tuple.Create(false, new List<int>());
                }
            }
            var listBlackY = graph.GetSetX().Select(x => int.Parse(x.BlackY.ToString())).ToList();
            return Tuple.Create(true, listBlackY);
        }

        private static bool Dfs(Node node)
        {
            foreach (var edge in node.Edges)
            {
                if (edge.Y.Color == Color.White)
                {
                    edge.X.Color = Color.Black;
                    edge.Y.Color = Color.Black;
                    edge.X.BlackY = edge.Y;
                    edge.Y.BlackX = edge.X;
                    return true;
                }
            }

            foreach (var edge in node.Edges.Where(e => !e.White))
            {
                if (edge.Y.Color == Color.Black && edge.Y.BlackX != null)
                {
                    var xNode = edge.Y.BlackX;
                    var whiteEdge = xNode.GiveEdge(edge.Y);
                    whiteEdge.White = true;
                    if (Dfs(xNode))
                    {
                        node.Color = Color.Black;
                        node.BlackY = edge.Y;
                        edge.Y.BlackX = node;
                        whiteEdge.White = false;
                        return true;
                    }
                    whiteEdge.White = false;
                }
            }
            return false;
        }
    }
}