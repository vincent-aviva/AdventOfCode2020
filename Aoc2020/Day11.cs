using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day11 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        private List<string> WaitingArea { get; set; }

        private int OccupiedWaitingRoom => WaitingArea.Sum(x => x.Count(y => y == OccupiedSeat));

        private int WaitingRoomMaxX;
        private int WaitingRoomMaxY;

        private const char Floor = '.';
        private const char EmptySeat = 'L';
        private const char OccupiedSeat = '#';

        public long Solve1(IList<string> input)
        {
            return Solve(input.ToList(), CountOccupiedSeatsAround, 4);
        }

        public long Solve2(IList<string> input)
        {
            return Solve(input.ToList(), CountOccupiedSeatsAdvanced, 5);
        }

        private long Solve(List<string> input, Func<int, int, int> CountSeatsAround, int clearAround)
        {
            WaitingArea = input.ToList();
            WaitingRoomMaxY = WaitingArea.Count - 1;
            WaitingRoomMaxX = WaitingArea.First().Length - 1;

            var occupied = -1;

            while (occupied != OccupiedWaitingRoom)
            {
                occupied = OccupiedWaitingRoom;

                var copy = WaitingArea.Select(x => x.ToCharArray()).ToList();
                for (var y = 0;y <= WaitingRoomMaxY;y++)
                {
                    for (var x = 0;x <= WaitingRoomMaxX;x++)
                    {
                        if (copy[y][x] == Floor)
                        {
                            continue;
                        }

                        var occupiedAround = CountSeatsAround(y, x);
                        if (copy[y][x] == EmptySeat && occupiedAround == 0)
                        {
                            copy[y][x] = OccupiedSeat;
                        }
                        if (copy[y][x] == OccupiedSeat && occupiedAround >= clearAround)
                        {
                            copy[y][x] = EmptySeat;
                        }
                    }
                }

                WaitingArea = copy.Select(x => string.Join("", x)).ToList();
                var output = string.Join(Environment.NewLine, WaitingArea);
            }

            return OccupiedWaitingRoom;
        }

        private int CountOccupiedSeatsAround(int y, int x)
        {
            var tilesAround = new List<char>
            {
                GetTile(y-1, x-1),
                GetTile(y-1, x),
                GetTile(y-1, x+1),

                GetTile(y, x-1),
                GetTile(y, x+1),

                GetTile(y+1, x-1),
                GetTile(y+1, x),
                GetTile(y+1, x+1),
            };

            return tilesAround.Count(z => z == OccupiedSeat);
        }

        private char GetTile(int y, int x)
        {
            if (y < 0 || y > WaitingRoomMaxY || x < 0 || x > WaitingRoomMaxY)
            {
                return Floor;
            }

            return WaitingArea[y][x];
        }

        private int CountOccupiedSeatsAdvanced(int y, int x)
        {
            var tilesAround = new List<char>
            {
                GetFirstSeat(y-1, x-1, -1, -1),
                GetFirstSeat(y-1, x, -1, 0),
                GetFirstSeat(y-1, x+1, -1, +1),

                GetFirstSeat(y, x-1, 0, -1),
                GetFirstSeat(y, x+1, 0, +1),

                GetFirstSeat(y+1, x-1, +1, -1),
                GetFirstSeat(y+1, x, +1, 0),
                GetFirstSeat(y+1, x+1, +1, +1),
            };

            return tilesAround.Count(z => z == OccupiedSeat);
        }

        private char GetFirstSeat(int y, int x, int yChange, int xChange)
        {
            if (y < 0 || y > WaitingRoomMaxY || x < 0 || x > WaitingRoomMaxX)
            {
                return EmptySeat;
            }

            var tile = WaitingArea[y][x];
            return tile == Floor ? 
                GetFirstSeat(y + yChange, x + xChange, yChange, xChange) : 
                tile;
        }
    }
}
