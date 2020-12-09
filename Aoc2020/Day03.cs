using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day03 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            return FindTrees(input, 3, 1);
        }

        public long Solve2(IList<string> input)
        {
            var slopes = new List<(int right, int down)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };

            return slopes.Aggregate(1, 
                (current, slope) => current * FindTrees(input, slope.right, slope.down));
        }

        private int FindTrees(IList<string> data, int right, int down)
        {
            var yPosition = 0;
            var xPosition = 0;
            var treeCount = 0;

            while (yPosition < data.Count())
            {
                var currentRow = data[yPosition];
                var currentPosition = currentRow[xPosition % currentRow.Length];
                if (currentPosition == '#')
                {
                    treeCount++;
                }

                yPosition += down;
                xPosition += right;
            }

            return treeCount;
        }
    }
}
