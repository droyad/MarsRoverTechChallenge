using System.Collections.Generic;

namespace MarsRoverTechChallenge.Shared
{
    public class Input
    {
        public Point FieldSize { get; set; }
        public IReadOnlyList<RoverInstructions> Instructions { get; set; }

        public Input(Point fieldSize, IReadOnlyList<RoverInstructions> instructions)
        {
            FieldSize = fieldSize;
            Instructions = instructions;
        }
    }
}