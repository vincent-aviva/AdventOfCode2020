using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day13 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => false;

        private long Part2StartPosition = 0;

        public Day13(long part2Start = 100000000000000)
        {
            Part2StartPosition = part2Start;
        }

        public long Solve1(IList<string> input)
        {
            var earliestTimestamp = int.Parse(input[0]);
            var busServices = input[1].Split(',')
                .Where(x => x != "x")
                .Select(int.Parse).ToList();

            var options = new Dictionary<int, int>();
            foreach (var busService in busServices)
            {
                if (earliestTimestamp % busService == 0)
                {
                    options.Add(busService, 0);
                }
                else
                {
                    var nextDeparture = busService * (earliestTimestamp / busService + 1);
                    options.Add(busService, nextDeparture - earliestTimestamp);
                }
            }

            var firstBus = options.First(x => x.Value == options.Values.Min());
            return firstBus.Value * firstBus.Key;
        }

        public long Solve2(IList<string> input)
        {
            //Copy from https://github.com/RaczeQ/AdventOfCode2020/blob/master/Day13/SecondSolver.cs

            var x = input[1]
                .Split(',')
                .Select((item, index) => (item, index))
                .Where(t => !t.item.Equals("x"))
                .Select(t => (long.Parse(t.item), t.index))
                .OrderByDescending(t => t.Item1)
                .ToList();

            var timestamp = x.First().Item1 - x.First().index;
            var period = x.First().Item1;
            for (var busIndex = 1;busIndex <= x.Count;busIndex++)
            {
                while (x.Take(busIndex).Any(t => (timestamp + t.index) % t.Item1 != 0))
                {
                    timestamp += period;
                }

                period = x.Take(busIndex).Select(t => t.Item1).Aggregate(LCM);
            }

            return timestamp;
        }

        private static long LCM(long a, long b)
        {
            return (a / GCD(a, b)) * b;
        }

        private static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public long Solve2_BruteForce(IList<string> input)
        {
            var busServices = input[1]
                .Split(',')
                .Select((item, index) => (item, index))
                .Where(t => !t.item.Equals("x"))
                .Select(t => (service: long.Parse(t.item), difference: t.index))
                .OrderByDescending(t => t.service)
                .ToList();

            var maxService = busServices.Max(x => x.service);
            var maxDifference = busServices.First(x => x.service == maxService).difference;
            var start = Part2StartPosition / maxService;

            for (var i = start;i < long.MaxValue;i++)
            {
                var time = i * maxService - maxDifference;

                if (busServices.All(x => (time + x.difference) % x.service == 0))
                {
                    return time;
                }
            }

            return -1;
        }
    }
}
