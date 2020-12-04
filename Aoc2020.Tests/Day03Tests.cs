using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day03Tests
    {
        private readonly IDay _day;
        private readonly List<string> _input;

        public Day03Tests()
        {
            _input = new List<string>
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };

            _day = new Day03();
        }

        [Fact]
        public void Part1()
        {
            _day.Solve1(_input).Should().Be(7);
        }

        [Fact]
        public void Part2()
        {
            _day.Solve2(_input).Should().Be(336);
        }
    }
}
