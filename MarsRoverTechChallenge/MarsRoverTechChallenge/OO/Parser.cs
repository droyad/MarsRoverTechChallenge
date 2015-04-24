using System.Collections.Generic;
using System.Linq;
using MarsRoverTechChallenge.Shared;

namespace MarsRoverTechChallenge.OO
{
    public class Parser
    {
        public static Input Parse(string input)
        {
            var lines = input.Split('\n').Select(s => s.Trim()).ToArray();
            var fieldSize = ParseFieldSize(lines[0]);
            var instructions = new List<RoverInstructions>();
            for (var i = 1; i < lines.Length; i += 2)
                instructions.Add(ParseInstructions(lines[i], lines[i + 1]));

            return new Input(fieldSize, instructions);
        }

        private static Point ParseFieldSize(string line)
        {
            var split = line.Split(' ');
            return new Point(int.Parse(split[0]), int.Parse(split[1]));
        }

        private static readonly Dictionary<char, Direction> _directionMap = new Dictionary<char, Direction>()
        {
            {'N', Direction.North},
            {'E', Direction.East},
            {'S', Direction.South},
            {'W', Direction.West},
        };


        private static readonly Dictionary<char, Movement> _movementMap = new Dictionary<char, Movement>()
        {
            {'L', Movement.Left},
            {'R', Movement.Right},
            {'M', Movement.Forward},
        };

        private static RoverInstructions ParseInstructions(string startLine, string movement)
        {
            var split = startLine.Split(' ');
            var position = new Position(int.Parse(split[0]), int.Parse(split[1]), _directionMap[split[2][0]]);
            var instructions = movement.Select(c => _movementMap[c]).ToArray();
            return new RoverInstructions(position, instructions);
        }
    }
}