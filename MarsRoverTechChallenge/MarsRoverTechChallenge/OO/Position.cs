namespace MarsRoverTechChallenge.OO
{
    public struct Position
    {
        private readonly Direction _direction;
        private readonly int _x;
        private readonly int _y;

        public Position(int x, int y, Direction direction)
        {
            _direction = direction;
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public Direction Direction
        {
            get { return _direction; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, Direction.ToString()[0]);
        }
    }
}