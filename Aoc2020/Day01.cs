using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day01 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public int Solve1(IList<string> input)
        {
            var numbers = input.Select(int.Parse).ToList();
            var output = 0;

            for (var i = 0;i < numbers.Count;i++)
            {
                for (var j = i;j < numbers.Count;j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        output = numbers[i] * numbers[j];
                    }
                }
            }

            return output;
        }

        public int Solve2(IList<string> input)
        {
            var numbers = input.Select(int.Parse).ToList();
            var output = 0;

            for (int i = 0;i < numbers.Count;i++)
            {
                for (var j = i;j < numbers.Count;j++)
                {
                    for (var k = j;k < numbers.Count;k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            output = numbers[i] * numbers[j] * numbers[k];
                        }
                    }
                }
            }

            return output;
        }
    }
}
