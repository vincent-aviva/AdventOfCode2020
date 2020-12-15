using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day14Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day14Tests()
        {
            _input = new List<string>
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0",
            };

            _day = new Day14();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(165);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(1068781);
        }
    }
}
