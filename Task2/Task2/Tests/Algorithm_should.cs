using System.Collections.Generic;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class Algorithm_should
    {
        private static readonly TestCaseData[] InputTwoCase =
        {
            new TestCaseData(new List<string>()
            {
                "6",
                "1 2 5 6 7 8 0",
                "5 6 7 0",
                "5 6 0",
                "5 0",
                "1 0",
                "2 0"
            }).Returns(new List<int>() {8, 7, 6, 5, 1, 2}),
            new TestCaseData(new List<string>()
            {
                "3",
                "1 2 3 0",
                "1 2 0",
                "3 0"
            }).Returns(new List<int>() {1, 2, 3}),
            new TestCaseData(new List<string>()
            {
                "3",
                "1 0",
                "2 0",
                "3 0"
            }).Returns(new List<int>() {1, 2, 3}),
            new TestCaseData(new List<string>()
            {
                "3",
                "1 0",
                "1 2 0",
                "3 0"
            }).Returns(new List<int>() {1, 2, 3}),
            new TestCaseData(new List<string>()
            {
                "3",
                "1 2 0",
                "1 0",
                "3 0"
            }).Returns(new List<int>() {2, 1, 3}),
            new TestCaseData(new List<string>()
            {
                "3",
                "1 0",
                "1 0",
                "3 0"
            }).Returns(new List<int>()),
            new TestCaseData(new List<string>()
            {
                "3",
                "1 2 3 0",
                "1 2 3 0",
                "1 2 3 0"
            }).Returns(new List<int>() {1, 2, 3}),
            new TestCaseData(new List<string>()
            {
                "4",
                "1 3 0",
                "2 0",
                "3 4 0",
                "1 0"
            }).Returns(new List<int>() {3, 2, 4, 1})
        };


        [Test, TestCaseSource(nameof(InputTwoCase))]
        public List<int> FindRightTwoPair(List<string> input)
        {
            var parameters = new Parameters(input.ToArray());
            return Algorithm.Khun(parameters.SetX, parameters.SetY, parameters.AdjacencyListForSetY).Item2;
        }
    }
}