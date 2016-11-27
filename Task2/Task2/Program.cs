using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("in.txt");
            var parameters = new Parameters(input);

            var pair = Algorithm.Khun(parameters.SetY, parameters.SetX, parameters.AdjacencyListForSetY);
            if (pair.Item1)
            {
                using (var sw = new StreamWriter("out.txt"))
                {
                    sw.Write($"Y{Environment.NewLine}");
                    foreach (var number in pair.Item2)
                    {
                        sw.Write(number + " ");
                    }
                }
            }
            else
            {
                File.WriteAllText("out.txt", "N");
            }
        }
    }
}