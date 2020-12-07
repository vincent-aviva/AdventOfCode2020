using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day06 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public int Solve1(IList<string> input)
        {
            var groupAnswers = ParseGroups(input);

            return groupAnswers.Sum(x => x.AnyoneAnswered);
        }

        public int Solve2(IList<string> input)
        {
            var groupAnswers = ParseGroups(input);

            return groupAnswers.Sum(x => x.EveryoneAnswered());
        }

        private static List<Group> ParseGroups(IList<string> input)
        {
            var group = new Group();
            var groupAnswers = new List<Group> { @group };
            foreach (var answers in input)
            {
                if (answers.Length == 0)
                {
                    group = new Group();
                    groupAnswers.Add(group);
                }
                else
                {
                    group.PersonAnswers.Add(answers);
                }
            }

            return groupAnswers;
        }
    }

    public class Group
    {
        public List<string> PersonAnswers { get; set; } = new List<string>();

        public int AnyoneAnswered => string.Join("", PersonAnswers).Distinct().Count();

        public int EveryoneAnswered()
        {
            var counter = 0;
            for (var i = 0; i < 26; i++)
            {
                var toCheck = (char) (i + 97);
                if (PersonAnswers.All(x => x.Contains(toCheck)))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
