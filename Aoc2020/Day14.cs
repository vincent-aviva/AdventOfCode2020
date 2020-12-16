using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day14 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true; //TODO for later

        private string Mask = "";

        public long Solve1(IList<string> input)
        {
            var memory = new List<long>(Enumerable.Repeat((long)0, 100000));

            foreach (var command in input)
            {
                var commandParts = command.Split(" = ");
                if (commandParts[0].Equals("mask"))
                {
                    Mask = commandParts[1];
                }
                else
                {
                    var position = int.Parse(commandParts[0].Substring(4, commandParts[0].Length - 5));
                    var output = CalculateValueWithMask(int.Parse(commandParts[1]));
                    memory[position] = output;
                }
            }

            return memory.Sum();
        }

        private long CalculateValueWithMask(long number)
        {
            var array = new BitArray(BitConverter.GetBytes(number));
            for (int i = 0;i < Mask.Length;i++)
            {
                var maskPosition = Mask.Length - 1 - i;
                switch (Mask[maskPosition])
                {
                    case '0':
                        array.Set(i, false);
                        break;
                    case '1':
                        array.Set(i, true);
                        break;
                }
            }

            var output = new byte[8];
            array.CopyTo(output, 0);
            return BitConverter.ToInt64(output, 0);
        }

        public long Solve2(IList<string> input)
        {
            var memory = new List<long>(Enumerable.Repeat((long)0, 100000));

            foreach (var command in input)
            {
                var commandParts = command.Split(" = ");
                if (commandParts[0].Equals("mask"))
                {
                    Mask = commandParts[1];
                }
                else
                {
                    var position = int.Parse(commandParts[0].Substring(4, commandParts[0].Length - 5));
                    int[] indexes = CalculateIndexesWithMask(position);
                    var value = int.Parse(commandParts[1]);

                    foreach (var index in indexes)
                    {
                        memory[index] = value;
                    }

                }
            }
            return memory.Sum();
        }

        private int[] CalculateIndexesWithMask(int position)
        {
            //TODO
            return new int[] { };
        }
    }
}
