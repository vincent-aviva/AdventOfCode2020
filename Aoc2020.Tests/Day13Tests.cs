using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day13Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day13Tests()
        {
            _input = new List<string>
            {
                "939",
                "7,13,x,x,59,x,31,19",
            };

            _day = new Day13(1068781);
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(295);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(1068781);
        }
    }
}
