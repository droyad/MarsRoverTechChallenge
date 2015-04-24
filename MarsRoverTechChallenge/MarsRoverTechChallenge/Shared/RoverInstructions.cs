namespace MarsRoverTechChallenge.Shared
{
    public class RoverInstructions
    {
        public RoverInstructions(Position startPosition, Movement[] movements)
        {
            StartPosition = startPosition;
            Movements = movements;
        }

        public Position StartPosition { get; private set; }
        public Movement[] Movements { get; private set; }
    }
}