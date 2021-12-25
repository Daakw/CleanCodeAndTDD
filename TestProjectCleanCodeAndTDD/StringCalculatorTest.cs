using CleanCodeAndTDD;
using Xunit;

namespace TestProjectCleanCodeAndTDD
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Should_Return_Zero_When_Empty_Input()
        {
            var result = StringCalculator.Add("0");

            Assert.Equal(0, result);
            
        }

        [Fact]
        public void Should_Return_Sum_Of_One_If_Input_Is_One()
        {
            var result = StringCalculator.Add("1");

            Assert.Equal(1, result);

        }

        [Fact]
        public void Should_Return_Sum_Of_Two_If_Input_Is_Two()
        {
            var result = StringCalculator.Add("3,5");

            Assert.Equal(8, result);

        }



    }
}