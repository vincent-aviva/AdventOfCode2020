using System.Collections.Generic;

namespace Aoc2020
{
    public interface IDay
    {
        bool IsImplemented { get; }

        bool IsPart1Complete { get; }

        bool IsPart2Complete { get; }

        long Solve1(IList<string> input);

        long Solve2(IList<string> input);
    }
}
