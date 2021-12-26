using CleanCodeAndTDD;
using System;
using Xunit;

namespace TestProjectCleanCodeAndTDD
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Add_Should_Return_Zero_When_Empty_Input()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("");

            Assert.Equal(0, result);
            
        }

        [Fact]
        public void Add_Should_Return_Sum_Of_One_If_Input_Is_One()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1");

            Assert.Equal(1, result);

        }

        [Fact]
        public void Add_Should_Return_Sum_Of_Two_Numbers_When_Separated_By_Comma()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("3,5");

            Assert.Equal(8, result);

        }

        [Fact]
        public void Add_Should_Return_Sum_Of_Multiple_Numbers_Seperated_By_Comma_If_Input_Is_Multiple()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("3, 5, 2, 5, 15");

            Assert.Equal(30, result);

        }

        [Fact]
        public void Add_Should_Return_Sum_If_Numbers_Are_Separated_With_New_Line()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("3,5\n7,5\n4\n10");

            Assert.Equal(34, result);

        }

        [Fact]
        public void Add_Should_support_Delimiter_declarations()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//;\n1;2");

            Assert.Equal(3, result);

        }

        [Fact]
        public void Add_Should_Not_Support_Negative_Number_And_Throw_Exception()
        {
            var stringCalculator = new StringCalculator();

            var ae = Assert.Throws<ArgumentException>(() => stringCalculator.Add("-2,3"));
        }

        [Fact]
        public void Add_Should_Not_Support_Negative_Number_And_Throw_Exception_And_Display_The_Number()
        {
            var stringCalculator = new StringCalculator();

            var ae = Assert.Throws<ArgumentException>(() => stringCalculator.Add("-5,3"));

            Assert.Equal("Negative numbers not allowed: -5", ae.Message);

        }

        [Fact]
        public void Add_Should_Not_Support_Multiple_Negative_Numbers_And_Throw_Exception_And_Display_The_Numbers()
        {
            var stringCalculator = new StringCalculator();
            var ae = Assert.Throws<ArgumentException>(() => stringCalculator.Add("-5,3,6,-9,-3"));

            Assert.Equal("Negative numbers not allowed: -5, -9, -3", ae.Message);

        }

        [Fact]
        public void Add_Should_Ignore_Number_Over_1000()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("2,1001");

            Assert.Equal(2, result);
            
        }

        [Fact]
        public void Add_Should_Ignore_Multiple_Numbers_Over_1000()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("2,1001,7,1002,1003");

            Assert.Equal(9, result);

        }
    }
}