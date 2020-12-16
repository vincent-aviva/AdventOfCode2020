using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day15 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true; //TODO There has to be a better way than trying all numbers

        public long Solve1(IList<string> input)
        {
            var startingNumbers = input[0].Split(',').Select(int.Parse).ToList();

            var spokenNumbers = startingNumbers.Take(startingNumbers.Count - 1).ToList();
            var lastSpokenNumber = startingNumbers.Last();

            for (var i = startingNumbers.Count; i <= 2020; i++)
            {
                if (spokenNumbers.Contains(lastSpokenNumber))
                {
                    var lastSpokenTurn = spokenNumbers.LastIndexOf(lastSpokenNumber);
                    spokenNumbers.Add(lastSpokenNumber);

                    lastSpokenNumber = spokenNumbers.Count - lastSpokenTurn - 1;
                }
                else
                {
                    spokenNumbers.Add(lastSpokenNumber);

                    lastSpokenNumber = 0;
                }
            }

            return spokenNumbers.Last();
        }

        public long Solve2(IList<string> input)
        {
            var startingNumbers = input[0].Split(',').Select(int.Parse).ToList();

            var spokenNumbers = startingNumbers.Take(startingNumbers.Count - 1).ToList();
            var lastSpokenNumber = startingNumbers.Last();

            for (var i = startingNumbers.Count;i <= 30000000;i++)
            {
                if (spokenNumbers.Contains(lastSpokenNumber))
                {
                    var lastSpokenTurn = spokenNumbers.LastIndexOf(lastSpokenNumber);
                    spokenNumbers.Add(lastSpokenNumber);

                    lastSpokenNumber = spokenNumbers.Count - lastSpokenTurn - 1;
                }
                else
                {
                    spokenNumbers.Add(lastSpokenNumber);

                    lastSpokenNumber = 0;
                }
            }

            return spokenNumbers.Last();
        }
    }
}
