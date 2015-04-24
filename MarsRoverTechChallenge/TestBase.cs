using NUnit.Framework;

namespace MarsRoverTechChallenge
{
    public abstract class TestBase
    {
        protected abstract string Run(string input);

        [TestCase]
        public void BaseCase()
        {
            const string input = "5 5\r\n1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM";
            const string expected = "1 3 N\r\n5 1 E";

            var result = Run(input);
            Assert.AreEqual(expected, result);
        }

    }
}
