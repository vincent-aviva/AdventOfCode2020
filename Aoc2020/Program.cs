using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2020
{
    class Program
    {

        internal static List<IDay> Days => new List<IDay> { new Day01(), new Day02(), new Day03(), new Day04(), new Day05(), new Day06(), new Day07(), new Day08(), new Day09(), new Day10(), new Day11(), new Day12(), new Day13(), new Day14(), new Day15(), new Day16(), new Day17(), new Day18(), new Day19(), new Day20(), new Day21(), new Day22(), new Day23(), new Day24(), new Day25() };

        static void Main(string[] args)
        {
            foreach (var day in Days)
            {
                if (!day.IsImplemented || (day.IsPart1Complete && day.IsPart2Complete)) continue;

                var dayNumber = day.GetType().Name.Substring(3);
                
                var input = File.ReadAllLines($"./Input/Day{dayNumber}.txt").ToList();

                if (day.IsImplemented && !day.IsPart1Complete)
                {
                    Console.WriteLine($"Running {day} - Part 1.");

                    var answer = day.Solve1(input);
                    Console.WriteLine($"The answer is {answer}");
                }

                if (day.IsImplemented && day.IsPart1Complete && !day.IsPart2Complete)
                {
                    Console.WriteLine($"Running {day} - Part 2.");

                    var answer = day.Solve2(input);
                    Console.WriteLine($"The answer is {answer}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("That's it's folks.");
            Console.ReadLine();
        }
    }
}
