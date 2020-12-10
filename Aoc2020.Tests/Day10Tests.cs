using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day10Tests
    {
        private readonly IDay _day;
        private List<string> _input1;
        private List<string> _input2;

        public Day10Tests()
        {
            _day = new Day10();

            _input1 = new List<string>
            {
                "16",
                "10",
                "15",
                "5",
                "1",
                "11",
                "7",
                "19",
                "6",
                "12",
                "4"
            };

            _input2 = new List<string>
            {
                "28",
                "33",
                "18",
                "42",
                "31",
                "14",
                "46",
                "20",
                "48",
                "47",
                "24",
                "23",
                "49",
                "45",
                "19",
                "38",
                "39",
                "11",
                "1",
                "32",
                "25",
                "35",
                "8",
                "17",
                "7",
                "9",
                "4",
                "2",
                "34",
                "10",
                "3"
            };
        }

        [Fact]
        public void Part1_1()
        {
            _day.Solve1(_input1).Should().Be(7 * 5);
        }

        [Fact]
        public void Part1_2()
        {
            _day.Solve1(_input2).Should().Be(22 * 10);
        }

        [Fact]
        public void Part2_1()
        {
            _day.Solve2(_input1).Should().Be(8);
        }

        [Fact]
        public void Part2_2()
        {
            _day.Solve2(_input2).Should().Be(19208);
        }
    }
}
