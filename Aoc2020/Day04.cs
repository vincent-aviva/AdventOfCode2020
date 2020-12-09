using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc2020
{
    public class Day04 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;

        public long Solve1(IList<string> input)
        {
            var passports = ParseInput(input);
            return passports.Count(x => x.ContainsRequiredFields());
        }

        public long Solve2(IList<string> input)
        {
            var passports = ParseInput(input);
            return passports.Count(x => x.IsValid());
        }

        private List<Passport> ParseInput(IList<string> input)
        {
            var passports = new List<Passport>();
            var currentPassportText = "";

            foreach (var passwordRow in input)
            {
                if (passwordRow.Length == 0)
                {
                    passports.Add(new Passport(currentPassportText));
                    currentPassportText = "";
                }
                else
                {
                    currentPassportText += passwordRow + " ";
                }
            }

            passports.Add(new Passport(currentPassportText));
            return passports;
        }
    }

    public class Passport
    {
        private readonly string[] RequiredPasswordFieds = new[]
        {
            "byr", //(Birth Year)
            "iyr", //(Issue Year)
            "eyr", //(Expiration Year)
            "hgt", //(Height)
            "hcl", //(Hair Color)
            "ecl", //(Eye Color)
            "pid", //(Passport ID)
            //"cid", //(Country ID)
        };

        private readonly string[] AllowedEyeColors = new[]
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth",
        };

        private Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

        public Passport(string input)
        {
            var inputParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var inputPart in inputParts)
            {
                var dataParts = inputPart.Split(':');
                Data.Add(dataParts[0], dataParts[1]);
            }
        }

        public bool IsValid()
        {
            return ContainsRequiredFields() && ValidFieldValues();
        }

        public bool ContainsRequiredFields()
        {
            return RequiredPasswordFieds.All(x => Data.ContainsKey(x));
        }

        public bool ValidFieldValues()
        {
            bool valid = true;

            foreach (var dataKey in Data.Keys)
            {
                if (!valid)
                {
                    break;
                }

                var value = Data[dataKey];
                switch (dataKey)
                {
                    case "byr": //(Birth Year) - four digits; at least 1920 and at most 2002.
                        valid = int.TryParse(value, out var byr) && byr >= 1920 && byr <= 2002;
                        break;
                    case "iyr": //(Issue Year) - four digits; at least 2010 and at most 2020.
                        valid = int.TryParse(value, out var iyr) && iyr >= 2010 && iyr <= 2020;
                        break;
                    case "eyr": //(Expiration Year) - four digits; at least 2020 and at most 2030.
                        valid = int.TryParse(value, out var eyr) && eyr >= 2020 && eyr <= 2030;
                        break;
                    case "hgt": //(Height) - a number followed by either cm or in: If cm, the number must be at least 150 and at most 193. If in, the number must be at least 59 and at most 76.
                        var measurement = value.Substring(value.Length - 2);
                        valid = int.TryParse(value.Substring(0, value.Length - 2), out var hgt) &&
                                (
                                    (measurement == "cm" && hgt >= 150 && hgt <= 193)
                                    ||
                                    (measurement == "in" && hgt >= 59 && hgt <= 76)
                                );
                        break;
                    case "hcl": //(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                        valid = Regex.IsMatch(value, "^#[0-9a-f]{6}$");
                        break;
                    case "ecl": //(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                        valid = AllowedEyeColors.Contains(value);
                        break;
                    case "pid": //(Passport ID) - a nine-digit number, including leading zeroes.
                        valid = Regex.IsMatch(value, "^[0-9]{9}$");
                        break;
                    default:
                        break;
                }
            }

            return valid;
        }
    }
}
