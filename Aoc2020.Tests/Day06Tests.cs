using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day06Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day06Tests()
        {
            _input = new List<string>
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            };

            _day = new Day06();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(11);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(6);
        }
    }
}
