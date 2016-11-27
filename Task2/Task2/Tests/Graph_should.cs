using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Task2.Tests
{
    public class Graph_should
    {
        [Test]
        public void createRightBipartiteGraph()
        {
            var setX = new int[] {1, 2};
            var setY = new int[] {1, 2};
            var a = new Dictionary<int, List<int>>()
            {
                {1, new List<int>() {1}},
                {2, new List<int>() {2}}
            };
            var graph = new Graph(setX, setY, a);

            graph.Nodes.Count().ShouldBeEquivalentTo(4);
        }
    }
}