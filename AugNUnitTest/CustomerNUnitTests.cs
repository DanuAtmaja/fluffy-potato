using NUnit.Framework;

namespace Aug
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange
            var customer = new Customer();

            //Act
            string fullName = customer.GreetAndCombineNames("Made", "Gele");
            
            //Assert
            Assert.That(fullName, Is.EqualTo("Swastiastu, Made Gele"));
        }
    }
}