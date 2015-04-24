using System.Collections.Generic;

namespace MarsRoverTechChallenge.OO
{
    public class Input
    {
        public Point FieldSize { get; set; }
        public List<RoverInstructions> Movements { get; set; }

        public Input(Point fieldSize, List<RoverInstructions> movements)
        {
            FieldSize = fieldSize;
            Movements = movements;
        }
    }
}