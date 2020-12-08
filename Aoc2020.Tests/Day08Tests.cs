using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day08Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day08Tests()
        {
            _input = new List<string>
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6",
            };

            _day = new Day08();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(5);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(8);
        }
    }
}
