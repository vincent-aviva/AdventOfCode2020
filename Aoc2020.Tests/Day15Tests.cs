using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day15Tests
    {
        private readonly IDay _day;

        public Day15Tests()
        {
            _day = new Day15();
        }

        [Fact]
        public void Part1_1()
        {
            _day.Solve1(new List<string> { "0,3,6", }).Should().Be(436);
        }

        [Fact]
        public void Part1_2()
        {
            _day.Solve1(new List<string> { "1,3,2", }).Should().Be(1);
        }

        [Fact]
        public void Part1_3()
        {
            _day.Solve1(new List<string> { "2,1,3", }).Should().Be(10);
        }

        [Fact]
        public void Part1_4()
        {
            _day.Solve1(new List<string> { "1,2,3", }).Should().Be(27);
        }

        [Fact]
        public void Part1_5()
        {
            _day.Solve1(new List<string> { "2,3,1", }).Should().Be(78);
        }

        [Fact]
        public void Part1_6()
        {
            _day.Solve1(new List<string> { "3,2,1", }).Should().Be(438);
        }

        [Fact]
        public void Part1_7()
        {
            _day.Solve1(new List<string> { "3,1,2", }).Should().Be(1836);
        }

        [Fact]
        public void Part2_1()
        {
            _day.Solve2(new List<string> { "0,3,6", }).Should().Be(175594);
        }

        [Fact]
        public void Part2_2()
        {
            _day.Solve2(new List<string> { "1,3,2", }).Should().Be(2578);
        }

        [Fact]
        public void Part2_3()
        {
            _day.Solve2(new List<string> { "2,1,3", }).Should().Be(3544142);
        }

        [Fact]
        public void Part2_4()
        {
            _day.Solve2(new List<string> { "1,2,3", }).Should().Be(261214);
        }

        [Fact]
        public void Part2_5()
        {
            _day.Solve2(new List<string> { "2,3,1", }).Should().Be(6895259);
        }

        [Fact]
        public void Part2_6()
        {
            _day.Solve2(new List<string> { "3,2,1", }).Should().Be(18);
        }

        [Fact]
        public void Part2_7()
        {
            _day.Solve2(new List<string> { "3,1,2", }).Should().Be(362);
        }
    }
}
