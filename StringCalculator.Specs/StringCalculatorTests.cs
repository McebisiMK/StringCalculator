using FluentAssertions;
using NUnit.Framework;
using StringCalculator_Library;
using StringCalculator_Library.Exceptions;

namespace StringCalculator_Specs
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_Given_Empty_Null_WhiteSpace_Should_Return_Zero(string number)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = Assert.Throws<InvalidInputException>(() => stringCalculator.Add(number));

            //----------------------Assert---------------------------
            actual.Message.Should().Be($"Given input does not contain any number!!");
        }

        [TestCase("name")]
        [TestCase("##$$%%")]
        [TestCase("-------")]
        public void Add_Given_Input_Contains_No_Numbers_Should_Return_Zero(string number)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = Assert.Throws<InvalidInputException>(() => stringCalculator.Add(number));

            //----------------------Assert---------------------------
            actual.Message.Should().Be($"Given input does not contain any number!!");
        }

        [TestCase("1", 1)]
        [TestCase("10", 10)]
        [TestCase("100", 100)]
        public void Add_Given_String_Number_Should_Return_Number_As_Integer(string input, double expectedSum)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(input);

            //----------------------Assert---------------------------
            actual.Should().Be(expectedSum);
        }

        [TestCase("1,2", 3)]
        [TestCase("10,20", 30)]
        [TestCase("100,200", 300)]
        [TestCase("101,245", 346)]
        public void Add_Given_String_Of_Two_Numbers_Separated_By_Comma_Should_Return_Their_Sum(string input, double expectedSum)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(input);

            //----------------------Assert---------------------------
            actual.Should().Be(expectedSum);
        }

        [TestCase("10.0,0.1", 10.1)]
        [TestCase("101.00,01.50", 102.50)]
        [TestCase("445.99,0.01", 446.00)]
        public void Add_Given_String_Of_Two_Numbers_Of_Type_Double_Separated_By_Comma_Should_Return_Their_Sum(string input, double expectedSum)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(input);

            //----------------------Assert---------------------------
            actual.Should().Be(expectedSum);
        }

        [TestCase("10.0,0.1", 10.1)]
        [TestCase("101.00,01.50\n10", 112.50)]
        [TestCase("445.99 0.01\n14#15", 475.00)]
        [TestCase("100.99\t1001.01\n458#852", 2412.00)]
        public void Add_Given_String_Of_Numbers_Separated_By_Any_Delimeter_Should_Return_Their_Sum(string input, double expectedSum)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = stringCalculator.Add(input);

            //----------------------Assert---------------------------
            actual.Should().Be(expectedSum);
        }

        [TestCase("10.0,-0.1", "-0.1")]
        [TestCase("-101.01,01.50\n-10", "-101.01, -10")]
        [TestCase("445.99 -0.01\n-14#15", "-0.01, -14")]
        [TestCase("-100.99\t-1001.01\n-458#-852", "-100.99, -1001.01, -458, -852")]
        public void Add_Given_String_Of_Numbers_With_Negatives_Separated_By_Any_Delimeter_Should_Throw_Exception_With_All_Negatives(string input, string negatives)
        {
            //----------------------Arrange--------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------------Act------------------------------
            var actual = Assert.Throws<NegativeNumberException>(() => stringCalculator.Add(input));

            //----------------------Assert---------------------------
            actual.Message.Should().Be($"Negative numbers are not allowed: ({negatives})");
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}