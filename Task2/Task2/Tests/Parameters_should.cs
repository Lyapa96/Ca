using FluentAssertions;
using NUnit.Framework;

namespace Task2.Tests
{
    public class Parameters_should
    {
        [Test]
        public void rightCreateSetXandSetY()
        {
            var input = new[]
            {
                "3",
                "1 2 3 0",
                "1 2 0",
                "3 0"
            };
            var parameters = new Parameters(input);

            parameters.SetX.Should().HaveCount(3);
            parameters.SetY.Should().HaveCount(3);

            parameters.SetX.Should().BeEquivalentTo(new int[] {1, 2, 3});
            parameters.SetY.Should().BeEquivalentTo(new int[] {1, 2, 3});
        }

        [Test]
        public void rightCreateAdjacencyListForSetY()
        {
            var input = new[]
            {
                "3",
                "1 2 3 0",
                "1 2 0",
                "3 0"
            };
            var parameters = new Parameters(input);

            parameters.AdjacencyListForSetY.Should().HaveCount(3);
            parameters.AdjacencyListForSetY[1].ShouldBeEquivalentTo(new[] {1, 2});
            parameters.AdjacencyListForSetY[2].ShouldBeEquivalentTo(new[] {1, 2});
            parameters.AdjacencyListForSetY[3].ShouldBeEquivalentTo(new[] {1, 3});
        }
    }
}