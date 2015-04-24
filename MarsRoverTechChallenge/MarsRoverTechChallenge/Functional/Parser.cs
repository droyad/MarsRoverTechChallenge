using System.Linq;
using MarsRoverTechChallenge.Shared;
using Sprache;
using Input = MarsRoverTechChallenge.Shared.Input;
using Position = MarsRoverTechChallenge.Shared.Position;

namespace MarsRoverTechChallenge.Functional
{
    public class Parser
    {
        public static Input ParseInput(string inputStr)
        {
            var space = Parse.Char(' ');
            var newline = Parse.String("\r\n");
            var number = Parse.Number.Select(int.Parse);

            var point = from x in number
                        from _ in space
                        from y in number
                        select new Point(x, y);

            var direction = Parse.Char('N').Return(Direction.North)
                .Or(Parse.Char('E').Return(Direction.East))
                .Or(Parse.Char('S').Return(Direction.South))
                .Or(Parse.Char('W').Return(Direction.West));

            var position = from x in number
                           from _ in space
                           from y in number
                           from __ in space
                           from d in direction
                           select new Position(x, y, d);

            var movement = Parse.Char('M').Return(Movement.Forward)
                .Or(Parse.Char('L').Return(Movement.Left))
                .Or(Parse.Char('R').Return(Movement.Right));


            var roverInstruction = from start in position
                                   from _ in newline
                                   from moves in movement.AtLeastOnce()
                                   from __ in newline.Optional()
                                   select new RoverInstructions(start, moves.ToArray());

            var document = from p in point
                           from _ in newline
                           from ri in roverInstruction.AtLeastOnce()
                           select new Input(p, ri.ToArray());

            return document.Parse(inputStr);
        }
    }
}