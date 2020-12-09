using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day07 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        private Dictionary<string, List<ContainingBag>> bagCombinations;

        public long Solve1(IList<string> input)
        {
            bagCombinations = RenderBags(input);
            return FindColorPossibilities("shiny gold", new List<string>()).Distinct().Count();
        }

        public long Solve2(IList<string> input)
        {
            bagCombinations = RenderBags(input);
            return GetContainingBagCount("shiny gold");
        }

        private Dictionary<string, List<ContainingBag>> RenderBags(IList<string> input)
        {
            var bags = new Dictionary<string, List<ContainingBag>>();

            foreach (var bagRow in input)
            {
                var colorPosition = bagRow.IndexOf("bags");
                var color = bagRow.Substring(0, colorPosition).Trim();
                
                var containingString = bagRow.Substring(colorPosition + 12).Trim();
                var containingArray = containingString.Split(',');
                var containingList = new List<ContainingBag>();
                foreach (var containingInput in containingArray)
                {
                    var containingBag = containingInput.Trim();
                    if (containingBag.StartsWith("no other bags"))
                    {
                        continue;
                    }

                    var amountPosition = containingBag.IndexOf(' ');
                    var containingAmount = int.Parse(containingBag.Substring(0, amountPosition));
                    var containingColor = containingBag.Substring(amountPosition+1, containingBag.LastIndexOf(' ') - amountPosition).Trim();
                    
                    containingList.Add(new ContainingBag { Amount = containingAmount, Color = containingColor});
                }

                bags.Add(color, containingList);
            }

            return bags;
        }

        private List<string> FindColorPossibilities(string color, List<string> colorPossibilities)
        {
            var possibilities = bagCombinations
                .Where(x => x.Value.Any(y => y.Color == color))
                .ToList();
            colorPossibilities.AddRange(possibilities.Select(x => x.Key));

            foreach (var possibility in possibilities)
            {
                FindColorPossibilities(possibility.Key, colorPossibilities);
            }

            return colorPossibilities;
        }

        private int GetContainingBagCount(string color)
        {
            int bagCount = 0;
            var bag = bagCombinations.First(x => x.Key == color);
            foreach (var containingBag in bag.Value)
            {
                bagCount += containingBag.Amount;
                bagCount += containingBag.Amount * GetContainingBagCount(containingBag.Color);
            }

            return bagCount;
        }
    }

    public class ContainingBag
    {
        public int Amount { get; set; }

        public string Color { get; set; }
    }
}
