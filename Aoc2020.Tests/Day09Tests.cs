using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day09Tests
    {
        private readonly IDay _day;
        private List<string> _input;

        public Day09Tests()
        {
            _input = new List<string>
            {
                "35",
                "20",
                "15",
                "25",
                "47",
                "40",
                "62",
                "55",
                "65",
                "95",
                "102",
                "117",
                "150",
                "182",
                "127",
                "219",
                "299",
                "277",
                "309",
                "576",
            };

            _day = new Day09(5);
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(127);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(8);
        }
    }
}
