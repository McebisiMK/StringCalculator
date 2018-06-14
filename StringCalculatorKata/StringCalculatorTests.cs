using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            //-------------------Arrange--------------------
            var number = string.Empty;
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1", 1)]
        [TestCase("50", 50)]
        [TestCase("1000", 1000)]
        public void Add_GivenStringWithOneNumber_ShouldReturnThatNumber(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1,2", 3)]
        [TestCase("1,2,6", 9)]
        [TestCase("1,2,6,8,9,10,45", 81)]
        public void Add_GivenStringOfNumbersSeparatedByComma_ShouldReturnTheSumOfThoseNumbers(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1\n2", 3)]
        [TestCase("1\n2\n3", 6)]
        [TestCase("1\n2\n6\n8\n9\n10\n45", 81)]
        public void Add_GivenStringOfNumbersSeparatedByNewline_ShouldReturnTheSumOfThoseNumbers(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        [TestCase("\n1,2", 3)]
        [TestCase("\n1,2,6", 9)]
        [TestCase("\n1,2,6,8,9,10,45", 81)]
        public void Add_GivenStringOfNumbersSeparatedByCommaAndStaringWithNewline_ShouldReturnTheSumOfThoseNumbers(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//%\n1%2%6", 9)]
        [TestCase("//*\n1*2*6*8*9*10*45", 81)]
        public void Add_GivenStringOfNumbersSeparatedBySpecifiedDelimiter_ShouldReturnTheSumOfThoseNumbers(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        [TestCase("\n1,1001,2", 3)]
        [TestCase("100,1009,2", 102)]
        [TestCase("//;\n1;1002;2", 3)]
        public void Add_GivenStringOfNumbersWhereOneNumberIsGreaterThan1000_ShouldReturnTheSumOfTheNumbersNotGreaterThan1000(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        [TestCase("-8", "Negatives not allowed -8")]
        [TestCase("-8,2,-9", "Negatives not allowed -8 -9")]
        [TestCase("//%\n-8%9%-11", "Negatives not allowed -8 -11")]
        public void Add_GivenStringOfNumbersContainingNegativeNumber_ShouldThrowExceptionAllNegativeNumbersThatWerePassed(string number, string expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(number));

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual.Message);

        }

        [TestCase("//[***]\n4***4", 8)]
        [TestCase("//[%%%]\n7%%%4", 11)]
        [TestCase("//[;;]\n4;;2", 6)]
        public void Add_GivenStringOfNumbersSeparatedByGivenDelimiterInsideBrackets_ShouldReturnTheSumOfThoseNumbers(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        [TestCase("//[;;][%%]\n4;;2%%8", 14)]
        [TestCase("//[***][%%]\n4***2%%8***10", 24)]
        [TestCase("//[;;][...]\n4;;2...8...1001", 14)]
        public void Add_GivenStringOfNumbersSeparatedByTwoDelimitersInsideBrackets_ShouldReturnTheSumOfThoseNumbers(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        [TestCase("//[;;][...][%%]\n4;;2...8...1001%%4", 18)]
        [TestCase("//[^^][...][%%]\n4^^6%%8...1001%%4", 22)]
        [TestCase("//[##][--][%%]\n4##10--8##100%%4", 126)]
        public void Add_GivenStringOfNumbersSeparatedByMultipleDelimitersInsideBrackets_ShouldReturnTheSumOfThoseNumbers(string number, int expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = stringCalculator.Add(number);

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual);

        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
