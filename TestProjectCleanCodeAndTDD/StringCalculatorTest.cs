using CleanCodeAndTDD;
using Xunit;

namespace TestProjectCleanCodeAndTDD
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Should_Return_Zero_When_Empty_Input()
        {
            var result = StringCalculator.Add("");

            Assert.Equal(0, result);


            
        }
    }
}