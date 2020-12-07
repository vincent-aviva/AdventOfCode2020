using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Aoc2020.Tests
{
    public class Day07Tests
    {
        private readonly IDay _day;
        private List<string> _input;

        public Day07Tests()
        {
            _day = new Day07();
        }

        [Fact]
        public void Part1()
        {
            _input = new List<string>
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
            };
            _day.Solve1(_input).Should().Be(4);
        }

        [Fact]
        public void Part2_option1()
        {
            _input = new List<string>
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
            };
            _day.Solve2(_input).Should().Be(32);
        }

        [Fact]
        public void Part2_option2()
        {
            _input = new List<string>
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags.",
            };
            _day.Solve2(_input).Should().Be(126);
        }
    }
}
