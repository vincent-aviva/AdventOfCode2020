using System.Collections.Generic;

namespace Aoc2020
{
    public interface IDay
    {
        bool IsImplemented { get; }

        bool IsPart1Complete { get; }

        bool IsPart2Complete { get; }

        int Solve1(IList<string> input);

        int Solve2(IList<string> input);
    }
}
