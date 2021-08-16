using NUnit.Framework;

namespace Aug
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();
            
            //Act
            int result = calc.AddNumbers(10, 20);
            
            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new();
            
            bool isOdd = calc.IsOddNumber(10);
            Assert.That(isOdd, Is.EqualTo(false));
            Assert.IsFalse(isOdd);
        }
        
        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            Calculator calc = new();
            
            bool isOdd = calc.IsOddNumber(a);
            Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calc = new();
            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)]
        [TestCase(5.43, 10.53)]
        [TestCase(5.49, 10.59)]
        public void AddNumberDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculator calc = new();

            double result = calc.AddNumbersDouble(a, b);
            
            Assert.AreEqual(15.9, result, .2);
        }
    }
}