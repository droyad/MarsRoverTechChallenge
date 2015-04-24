using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverTechChallenge.Shared;
using Translate = System.Func<MarsRoverTechChallenge.Shared.Position, MarsRoverTechChallenge.Shared.Position>;

namespace MarsRoverTechChallenge.Functional
{
    public class Program
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

            var movementMap = new Dictionary<Movement, Translate>
            {
                {Movement.Forward, p => moveForwardMap[p.Direction](p)},
                {Movement.Left, p => new Position(p.X, p.Y, turnLeftMap[p.Direction])},
                {Movement.Right, p => new Position(p.X, p.Y, turnRightMap[p.Direction])},
            };


            Func<RoverInstructions, Position> goRoverGo = i =>
            {
                Func<Position, Movement, Position> move = (p, m) => movementMap[m](p);
                return i.Movements.Aggregate(i.StartPosition, move);
            };

            return Parser.ParseInput(inputStr)
                .Instructions
                .Select(goRoverGo)
                .Select(p => p.ToString())
                .Aggregate((a, b) => a + Environment.NewLine + b);
        }

    }
}