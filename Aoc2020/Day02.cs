using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc2020
{
    public class Day02 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            var passwords = input.Select(x => new Day2PasswordPolicy(x)).ToList();
            var correct = passwords.Count(x => x.FirstValidateAttempt);

            return correct;
        }

        public long Solve2(IList<string> input)
        {
            var passwords = input.Select(x => new Day2PasswordPolicy(x)).ToList();
            var correct = passwords.Count(x => x.SecondValidateAttempt);

            return correct;
        }

        private Day2PasswordPolicy CreatePasswordPolicy(string input)
        {
            return new Day2PasswordPolicy(input);
        }
    }

    public class Day2PasswordPolicy
    {
        public Day2PasswordPolicy(string input)
        {
            var match = Regex.Match(input, "(?<min>-?[0-9]+)-(?<max>-?[0-9]+) (?<char>-?[a-z]+): (?<pwd>-?[a-z]+)");

            FirstNumber = int.Parse(match.Groups["min"].Value);
            SecondNumber = int.Parse(match.Groups["max"].Value);
            Character = match.Groups["char"].Value[0];
            Password = match.Groups["pwd"].Value;
        }

        private int FirstNumber { get; }
        private int SecondNumber { get; }
        private char Character { get; }
        private string Password { get; }

        /// <summary>
        /// The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid.
        /// </summary>
        public bool FirstValidateAttempt {
            get {
                var charCount = Password.Count(x => x == Character);
                return charCount >= FirstNumber && charCount <= SecondNumber;
            }
        }

        /// <summary>
        /// Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on.
        /// (Be careful; Toboggan Corporate Policies have no concept of "index zero"!)
        /// Exactly one of these positions must contain the given letter. Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
        /// </summary>
        public bool SecondValidateAttempt {
            get {
                var firstValid = Password[FirstNumber - 1] == Character;
                var secondValid = Password[SecondNumber - 1] == Character;
                return firstValid ^ secondValid;
            }
        }
    }
}
