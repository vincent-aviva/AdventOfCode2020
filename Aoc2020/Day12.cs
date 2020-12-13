using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020
{
    public class Day12 : IDay
    {
        public bool IsImplemented => true;
        public bool IsPart1Complete => true;
        public bool IsPart2Complete => true;
        
        public long Solve1(IList<string> input)
        {
            var ferry = new Ferry();
            foreach (var instruction in input)
            {
                ferry.Process(instruction);
            }

            return ferry.ManhattenDistance;
        }

        public long Solve2(IList<string> input)
        {
            var ferry = new Ferry();
            foreach (var instruction in input)
            {
                ferry.ProcessWaypoint(instruction);
            }

            return ferry.ManhattenDistance;
        }
    }

    public class Ferry
    {
        private Dictionary<int, char> Directions { get; set; } = new Dictionary<int, char>();
        
        private int CurrentDirection { get; set; }
        
        private Dictionary<char, int> Distances { get; set; } = new Dictionary<char, int>();

        private Dictionary<char, int> Waypoints { get; set; } = new Dictionary<char, int>();

        public int ManhattenDistance => Math.Abs(Distances['N'] - Distances['S']) + 
                                        Math.Abs(Distances['E'] - Distances['W']);

        public Ferry()
        {
            Directions.Add(0, 'N');
            Directions.Add(90, 'E');
            Directions.Add(180, 'S');
            Directions.Add(270, 'W');

            CurrentDirection = 90;

            Distances.Add('N', 0);
            Distances.Add('E', 0);
            Distances.Add('S', 0);
            Distances.Add('W', 0);

            Waypoints.Add('N', 1);
            Waypoints.Add('E', 10);
            Waypoints.Add('S', 0);
            Waypoints.Add('W', 0);
        }

        public void Process(string instruction)
        {
            var instructionChar = instruction[0];
            var instructionAmount = int.Parse(instruction.Substring(1));

            switch (instructionChar)
            {
                case 'N': //Action N means to move north by the given value.
                case 'S': //Action S means to move south by the given value.
                case 'E': //Action E means to move east by the given value.
                case 'W': //Action W means to move west by the given value.
                    Distances[instructionChar] += instructionAmount;
                    break;
                case 'L': //Action L means to turn left the given number of degrees.
                    CurrentDirection = (CurrentDirection + 360 - instructionAmount) % 360;
                    break;
                case 'R': //Action R means to turn right the given number of degrees.
                    CurrentDirection = (CurrentDirection + instructionAmount) % 360;
                    break;
                case 'F': //Action F means to move forward by the given value in the direction the ship is currently facing.
                    Distances[Directions[CurrentDirection]] += instructionAmount;
                    break;

            }
        }

        public void ProcessWaypoint(string instruction)
        {
            var instructionChar = instruction[0];
            var instructionAmount = int.Parse(instruction.Substring(1));

            switch (instructionChar)
            {
                case 'N': //Action N means to move north by the given value.
                case 'S': //Action S means to move south by the given value.
                case 'E': //Action E means to move east by the given value.
                case 'W': //Action W means to move west by the given value.
                    Waypoints[instructionChar] += instructionAmount;
                    break;
                case 'L': //Action L means to turn left the given number of degrees.
                    RotateWaypoint(360 - instructionAmount);
                    break;
                case 'R': //Action R means to turn right the given number of degrees.
                    RotateWaypoint(instructionAmount);
                    break;
                case 'F': //Action F means to move forward by the given value in the direction the ship is currently facing.
                    foreach (var wayPoint in Waypoints)
                    {
                        Distances[wayPoint.Key] += (instructionAmount * wayPoint.Value);
                    }
                    break;

            }
        }

        private void RotateWaypoint(int degrees)
        {
            var newWaypoints = new Dictionary<char, int>();
            foreach (var oldWaypoint in Waypoints)
            {
                var newDegree = (Directions.First(x => x.Value == oldWaypoint.Key).Key + degrees) % 360;
                newWaypoints.Add(Directions[newDegree], oldWaypoint.Value);
            }

            Waypoints = newWaypoints;
        }
    }
}
