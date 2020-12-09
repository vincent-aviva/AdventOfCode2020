using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day09 : IDay
    {
        private readonly int _preamble;
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => false;

        public Day09(int preamble = 25)
        {
            _preamble = preamble;
        }

        public long Solve1(IList<string> input)
        {
            var numbers = input.Select(long.Parse).ToList();

            for (var i = _preamble; i < input.Count; i++)
            {
                var currentNumber = numbers[i];
                var previousNumbers = numbers.Skip(i - _preamble).Take(_preamble).ToList();
                var valid = previousNumbers.Any(x => previousNumbers.Where(y=> y != x).Any(y => x + y == currentNumber));

                if (!valid)
                {
                    return currentNumber;
                }
            }

            return 0;
        }

        public long Solve2(IList<string> input)
        {
            var target = Solve1(input);

            var numbers = input.Select(long.Parse).ToList();
            
            for (var i = 0; i < numbers.Count; i++)
            {
                var numberCounter = 1;
                long sum = 0;
                while (sum < target)
                {
                    var range = numbers.Skip(i).Take(numberCounter).ToList();
                    sum = range.Sum();

                    if (sum == target)
                    {
                        return range.Min() + range.Max();
                    }

                    numberCounter++;
                }
            }

            return 0;
        }
    }
}
