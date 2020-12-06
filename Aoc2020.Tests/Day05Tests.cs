using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day05Tests
    {
        private readonly IDay _day;
        private List<string> _input;

        public Day05Tests()
        {
            _day = new Day05();
        }

        [Fact]
        public void Part1()
        {
            _input = new List<string>
            {
                "BFFFBBFRRR",
                "FFFBBBFRRR",
                "BBFFBBFRLL"
            };
            _day.Solve1(_input).Should().Be(820);
        }
    }
}
