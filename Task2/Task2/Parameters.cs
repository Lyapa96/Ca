using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class Parameters
    {
        public List<int> SetY { get; set; }
        public List<int> SetX { get; set; }
        public Dictionary<int, List<int>> AdjacencyListForSetY = new Dictionary<int, List<int>>();

        public Parameters(string[] input)
        {
            SetX = new List<int>();
            SetY = new List<int>();
            var count = int.Parse(input[0]);
            for (int i = 0; i < count; i++)
            {
                SetX.Add(i + 1);
                var line = input[i + 1];
                var numbers =
                    line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(number => int.Parse(number))
                        .Where(number => number != 0)
                        .ToArray();
                foreach (var number in numbers)
                {
                    if (SetY.Contains(number))
                    {
                        AdjacencyListForSetY[number].Add(i + 1);
                    }
                    else
                    {
                        SetY.Add(number);
                        AdjacencyListForSetY.Add(number, new List<int>() {i + 1});
                    }
                }
            }
        }
    }
}