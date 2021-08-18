using System;
using NUnit.Framework;

namespace Aug
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }
        
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Act
            customer.GreetAndCombineNames("Made", "Gele");
            Assert.Multiple(() =>
            {
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Made Gele"));
                Assert.AreEqual(customer.GreetMessage, "Hello, Made Gele");
                Assert.That(customer.GreetMessage, Does.Contain("Made Gele").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("Gele"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");
            
            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Aug"));
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
            
            Assert.That(() => customer.GreetAndCombineNames("","Aug"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Aug"));
            
            Assert.That(() => customer.GreetAndCombineNames("", "Aug"),
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));
        }


        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Oreder_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }
        
        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Oreder_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}