using FluentAssertions;
using NUnit.Framework;
using UnitTests.CollaboratingClasses.Helpers;
using UnitTests.CollaboratingClasses.Implementation;

namespace UnitTests.CollaboratingClasses
{
    [TestFixture]
    public class OrderConfirmationEmailBuilderTests
    {
        private OrderConfirmationEmailBuilder orderConfirmationEmailBuilder;

        [SetUp]
        public void SetUp()
        {
            orderConfirmationEmailBuilder = new OrderConfirmationEmailBuilder();
        }

        [Test]
        public void BuildEmail_EmailShouldHaveOrderCodeInSubject()
        {
            // Arrange
            var order = BuildEntity.Order.AsDraft().Build();

            // Act
            var email = orderConfirmationEmailBuilder.BuildOrderConfirmationEmail(order);

            // Assert
            email.Subject.Should().Contain(order.Code);
        }

        [Test]
        public void BuildEmail_EmailShouldBeAddressedToCustomer()
        {
            // Arrange
            var order = BuildEntity.Order.AsDraft().Build();

            // Act
            var email = orderConfirmationEmailBuilder.BuildOrderConfirmationEmail(order);

            // Assert
            email.To.Should().Contain(to => to.Address == order.Customer.Email);
        }
    }
}