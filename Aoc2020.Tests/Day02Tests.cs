using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day02Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day02Tests()
        {
            _input = new List<string>
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
            };

            _day = new Day02();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(2);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(1);
        }
    }
}
