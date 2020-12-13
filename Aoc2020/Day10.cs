using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day10 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            var adapters = input.Select(int.Parse).ToList();
            adapters.Add(0); //Add 
            adapters.Add(adapters.Max() + 3);
            adapters = adapters.OrderBy(x => x).ToList();

            var couples = adapters.Skip(1).Select((x, index) => (current: adapters[index], next: x));
            var joltDiff = couples.Select(x => x.next - x.current).ToList();

            return joltDiff.Count(x => x == 1) * joltDiff.Count(x => x == 3);
        }

        public long Solve2(IList<string> input)
        {
            //Copy of https://github.com/FrankBakkerNl/AdventOfCode2020/blob/master/AdventOfCode2020/Puzzles/Day10.cs
            var inputSet = input.Select(int.Parse).Append(0).ToHashSet();

            var pathCounts = new long[input.Count * 3 + 4];
            pathCounts[0] = 1;

            var skipped = 0;

            for (var i = 0;;i++)
            {
                if (!inputSet.Contains(i))
                {
                    if (++skipped == 3)
                        return pathCounts[i - skipped]; // If we skipped 3 times in a row we are passed the end
                    continue;
                }

                var paths = pathCounts[i];
                pathCounts[i + 1] += paths;
                pathCounts[i + 2] += paths;
                pathCounts[i + 3] += paths;

                skipped = 0;
            }
        }
    }
}
