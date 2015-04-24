using System;
using System.Collections.Generic;
using MarsRoverTechChallenge.Shared;

namespace MarsRoverTechChallenge.OO
{
    public class Rover
    {

        private Direction _direction;
        private int _x;
        private int _y;

        public Rover(Position position)
        {
            _direction = position.Direction;
            _x = position.X;
            _y = position.Y;
        }

        public Position Position
        {
            get
            {
                return new Position(_x, _y, _direction);
            }
        }

        public void Move(IReadOnlyList<Movement> movements)
        {
            foreach(var movement in movements)
                Move(movement);
        }

        private void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.Left:
                    TurnLeft();
                    break;
                case Movement.Right:
                    TurnRight();
                    break;
                case Movement.Forward:
                    Forward();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("movement");
            }
        }

        private void Forward()
        {
            switch (_direction)
            {
                case Direction.North:
                    _y++;
                    break;
                case Direction.East:
                    _x++;
                    break;
                case Direction.South:
                    _y--;
                    break;
                case Direction.West:
                    _x--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnRight()
        {
            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.East;
                    break;
                case Direction.East:
                    _direction = Direction.South;
                    break;
                case Direction.South:
                    _direction = Direction.West;
                    break;
                case Direction.West:
                    _direction = Direction.North;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnLeft()
        {
            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.West;
                    break;
                case Direction.East:
                    _direction = Direction.North;
                    break;
                case Direction.South:
                    _direction = Direction.East;
                    break;
                case Direction.West:
                    _direction = Direction.South;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}