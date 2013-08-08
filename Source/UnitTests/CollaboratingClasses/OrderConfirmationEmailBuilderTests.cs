using System;
using System.Linq;
using System.Collections.Generic;
using CollaboratingClasses;
using FluentAssertions;
using NUnit.Framework;
using UnitTests.CollaboratingClasses.Helpers;

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
            var order = BuildEntity.Order.AsDraft().Build();

            // Act
            var email = orderConfirmationEmailBuilder.BuildOrderConfirmationEmail(order);

            // Assert
            email.To.Should().Contain(to => to.Address == order.Customer.Email);
        }
    }
}