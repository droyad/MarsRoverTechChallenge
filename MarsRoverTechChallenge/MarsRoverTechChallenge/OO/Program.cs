using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRoverTechChallenge.OO
{
    public static class Program
    {
        public static string Run(string input)
        {
            var parsedInput = Parser.Parse(input);
            var output = new List<string>();
            foreach (var instruction in parsedInput.Movements)
            {
                var rover = new Rover(instruction.StartPosition);
                rover.Move(instruction.Instructions);
                output.Add(rover.Position.ToString());
            }
            return string.Join(Environment.NewLine, output);
        }
    }
}