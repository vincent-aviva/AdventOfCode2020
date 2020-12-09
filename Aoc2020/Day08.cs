using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day08 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            var commands = input.Select(x => HandheldGameConsole.ParseCommand(x)).ToList();

            var handheld = new HandheldGameConsole(commands);
            handheld.Boot();

            return handheld.Accumulator;
        }

        public long Solve2(IList<string> input)
        {
            var commands = input.Select(x => HandheldGameConsole.ParseCommand(x)).ToList();

            for (var i = 0; i < commands.Count; i++)
            {
                if (commands[i].instruction == "acc") continue;

                var copy = commands.ToList();
                copy[i] = (SwitchOperation(commands[i].instruction), commands[i].number);

                var handheld = new HandheldGameConsole(copy);
                var completed = handheld.Boot();

                if (completed)
                {
                    return handheld.Accumulator;
                }
            }

            return 0;
        }

        private string SwitchOperation(string operation)
        {
            return operation switch
            {
                "jmp" => "nop",
                "nop" => "jmp",
                _ => throw new Exception("Incorrect operation switch")
            };
        }
    }

    public class HandheldGameConsole
    {
        private readonly IList<(string instruction, int number)> _commands;

        public int Accumulator { get; private set; }

        public HandheldGameConsole(IList<(string instruction, int number)> commands)
        {
            _commands = commands;
            Accumulator = 0;
        }

        public bool Boot()
        {
            var rowPosition = 0;
            var executedRows = new List<int>();

            while (executedRows.All(x => x != rowPosition) && rowPosition < _commands.Count)
            {
                executedRows.Add(rowPosition);

                var (instruction, number) = _commands[rowPosition];
                switch (instruction)
                {
                    case "nop":
                        rowPosition++;
                        break;

                    case "acc":
                        Accumulator += number;
                        rowPosition++;
                        break;

                    case "jmp":
                        rowPosition += number;
                        break;
                }
            }

            return rowPosition >= _commands.Count;
        }

        public static (string instruction, int number) ParseCommand(string line)
        {
            var commandParts = line.Split(' ');
            return (commandParts[0], int.Parse(commandParts[1]));
        }
    }
}
