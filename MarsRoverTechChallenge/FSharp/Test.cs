using System;
using Microsoft.FSharp.Core;

namespace MarsRoverTechChallenge.FSharp
{
    public class TestMover1 : TestBase
    {
        protected override string Run(string input)
        {
            return FSharpRover.Run1(input);
        }
    }

    public class TestMover2 : TestBase
    {
        protected override string Run(string input)
        {
            return FSharpRover.Run2(input);
        }
    }

    public class TestMover3 : TestBase
    {
        protected override string Run(string input)
        {
            return FSharpRover.Run3(input);
        }
    }
}