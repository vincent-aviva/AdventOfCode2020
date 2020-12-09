using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day05 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            var boardingPasses = input.Select(x => new BoardingPass(x)).ToList();
            return boardingPasses.Max(x => x.SeatId);
        }

        public long Solve2(IList<string> input)
        {
            var boardingPasses = input.Select(x => new BoardingPass(x)).ToList();
            boardingPasses = boardingPasses.OrderBy(x => x.Row).ThenBy(x => x.Seat).ToList();

            for (var row = 0;row < 128;row++)
            {
                for (var seat = 0;seat < 8;seat++)
                {
                    var currentSeatId = BoardingPass.CalculateSeatId(row, seat);
                    if (boardingPasses.Count(x => x.Row == row && x.Seat == seat) == 0 &&
                        boardingPasses.Any(x => x.SeatId == currentSeatId - 1) &&
                        boardingPasses.Any(x => x.SeatId == currentSeatId + 1))
                    {
                        return currentSeatId;
                    }
                }
            }

            return 0;
        }
    }

    public class BoardingPass
    {
        public int Row { get; }

        public int Seat { get; }

        public int SeatId => CalculateSeatId(Row, Seat);

        public BoardingPass(string input)
        {
            Row = Calculate(input.Substring(0, 7).ToCharArray(), 0, 127);
            Seat = Calculate(input.Substring(7).ToCharArray(), 0, 7);
        }

        public static int CalculateSeatId(int row, int seat)
        {
            return row * 8 + seat;
        }

        private static int Calculate(IEnumerable<char> inputCharacters, int min, int max)
        {
            foreach (var inputCharacter in inputCharacters)
            {
                switch (inputCharacter)
                {
                    case 'L': //LEFT
                    case 'F': //FRONT
                        max -= ((max - min + 1) / 2);
                        break;
                    case 'R': //RIGHT
                    case 'B': //BACK
                        min += ((max - min + 1) / 2);
                        break;
                }
            }

            if (min != max)
            {
                throw new Exception("Something went wrong during processing of the boarding pass");
            }

            return min;
        }
    }
}
