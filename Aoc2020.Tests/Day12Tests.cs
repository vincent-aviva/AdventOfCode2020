using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day12Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day12Tests()
        {
            _input = new List<string>
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11",
            };

            _day = new Day12();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(25);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(286);
        }
    }
}
