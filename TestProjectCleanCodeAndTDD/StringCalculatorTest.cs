using CleanCodeAndTDD;
using Xunit;

namespace TestProjectCleanCodeAndTDD
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Add_Should_Return_Zero_When_Empty_Input()
        {
            var result = StringCalculator.Add("");

            Assert.Equal(0, result);
            
        }

        [Fact]
        public void Add_Should_Return_Sum_Of_One_If_Input_Is_One()
        {
            var result = StringCalculator.Add("1");

            Assert.Equal(1, result);

        }

        [Fact]
        public void Add_Should_Return_Sum_Of_Two_Numbers_When_Separated_By_Comma()
        {
            var result = StringCalculator.Add("3,5");

            Assert.Equal(8, result);

        }

        [Fact]
        public void Add_Should_Return_Sum_Of_Multiple_Numbers_Seperated_By_Comma_If_Input_Is_Multiple()
        {
            var result = StringCalculator.Add("3, 5, 2, 5, 15");

            Assert.Equal(30, result);

        }

        [Fact]
        public void Add_Should_Return_Sum_If_Numbers_Are_Separated_With_New_Line()
        {
            var result = StringCalculator.Add("3,5\n7,5\n4\n10");

            Assert.Equal(34, result);

        }

        [Fact]
        public void Add_Should_support_Delimiter_declarations()
        {
            var result = StringCalculator.Add("//;\n1;2");

            Assert.Equal(3, result);

        }

    }
}