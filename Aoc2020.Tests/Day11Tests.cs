using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day11Tests
    {
        private readonly IDay _day;
        private List<string> _input;

        public Day11Tests()
        {
            _input = new List<string>
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL",
            };

            _day = new Day11();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(37);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(26);
        }
    }
}
