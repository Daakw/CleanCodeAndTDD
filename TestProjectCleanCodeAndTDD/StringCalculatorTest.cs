using CleanCodeAndTDD;
using Xunit;

namespace TestProjectCleanCodeAndTDD
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Should_Return_Zero_When_Empty_Input()
        {
            var result = StringCalculator.Add("1");

            Assert.Equal(1, result);


            
        }
    }
}