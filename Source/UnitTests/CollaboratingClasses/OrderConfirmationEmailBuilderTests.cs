using System;
using System.Linq;
using System.Collections.Generic;
using CollaboratingClasses;
using FluentAssertions;
using NUnit.Framework;

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
        public void BuildEmail_EmailShouldBeAddressedToCustomer()
        {
            // Arrange
            var order = OrderTestDataFactory.GetDraftOrder();

            // Act
            var email = orderConfirmationEmailBuilder.BuildOrderConfirmationEmail(order);

            // Assert
            email.To.Should().Contain(to => to.Address == order.Customer.Email);
        }
    }
}