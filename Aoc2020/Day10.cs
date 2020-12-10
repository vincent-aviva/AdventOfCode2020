using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day10 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => false;
        public bool IsPart2Complete => false;

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
            throw new NotImplementedException();
        }
    }
}
