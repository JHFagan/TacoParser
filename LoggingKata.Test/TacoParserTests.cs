using System;
using Xunit;
//DONT FORGET DEPENDENCIES!!

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
            //ARRANGE
            var tacoParser = new TacoParser();
            //ACT
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            //ASSERT
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]
        public void ShouldParse(string str, double expected)
        {
            // TODO: Complete Should Parse
            //ARRANGE
            var tacoParser = new TacoParser();
            //ACT
            TacoBells actual = (TacoBells)tacoParser.Parse(str);
            //ASSERT
            Assert.Equal(expected, actual.lat);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            //ARRANGE
            var tacoParser = new TacoParser();
            //ACT
            TacoBells actual = (TacoBells)tacoParser.Parse(str);
            //ASSERT
            Assert.Null(actual);
        }
    }
}
