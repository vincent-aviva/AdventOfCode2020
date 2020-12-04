using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day01Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day01Tests()
        {
            _input = new List<string>
            {
                "1721",
                "979",
                "366",
                "299",
                "675",
                "1456"
            };

            _day = new Day01();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(514579);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(241861950);
        }
    }
}
