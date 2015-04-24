namespace MarsRoverTechChallenge.OO
{
    public class RoverInstructions
    {
        public RoverInstructions(Position startPosition, Movement[] instructions)
        {
            StartPosition = startPosition;
            Instructions = instructions;
        }

        public Position StartPosition { get; private set; }
        public Movement[] Instructions { get; private set; }
    }
}