using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverTechChallenge.Shared;
using Sprache;
using Position = MarsRoverTechChallenge.Shared.Position;
using Translate = System.Func<MarsRoverTechChallenge.Shared.Position, MarsRoverTechChallenge.Shared.Position>;

namespace MarsRoverTechChallenge.SingleStep
{
    public static class Program
    {
        public static string Run(string inputStr)
        {
            var moveForwardMap = new Dictionary<Direction, Translate>
            {
                {Direction.North, p => new Position(p.X, p.Y + 1, p.Direction)},
                {Direction.East, p => new Position(p.X + 1, p.Y, p.Direction)},
                {Direction.South, p => new Position(p.X, p.Y - 1, p.Direction)},
                {Direction.West, p => new Position(p.X - 1, p.Y, p.Direction)}
            };

            var turnLeftMap = new Dictionary<Direction, Direction>
            {
                {Direction.North, Direction.West},
                {Direction.East, Direction.North},
                {Direction.South, Direction.East},
                {Direction.West, Direction.South}
            };

            var turnRightMap = new Dictionary<Direction, Direction>
            {
                {Direction.North, Direction.East},
                {Direction.East, Direction.South},
                {Direction.South, Direction.West},
                {Direction.West, Direction.North}
            };
 
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

            var movement = Parse.Char('M').Return<char,Translate>(p => moveForwardMap[p.Direction](p))
                .Or(Parse.Char('L').Return<char,Translate>(p => new Position(p.X, p.Y, turnLeftMap[p.Direction])))
                .Or(Parse.Char('R').Return<char,Translate>(p => new Position(p.X, p.Y, turnRightMap[p.Direction])));

            var roverInstruction = from start in position
                from _ in newline
                from moves in movement.AtLeastOnce()
                from __ in newline.Optional()
                select moves.Aggregate(start, (p, m) => m(p));

            var document = from p in point
                from _ in newline
                from finishes in roverInstruction.AtLeastOnce()
                select finishes.Select(f => f.ToString())
                    .Aggregate((a, b) => a + Environment.NewLine + b.ToString());

            return document.Parse(inputStr);
        }
    }
}