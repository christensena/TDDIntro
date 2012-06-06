using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using CollaboratingClasses;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests.CollaboratingClasses
{
    [TestFixture]
    public class OrderConfirmerTests
    {
        private OrderConfirmer orderConfirmer;
        private MailSender mailSenderFake;
        private OrderConfirmationEmailBuilder orderConfirmationEmailBuilderFake;

        [SetUp]
        public void SetUp()
        {
            // dependencies (substituted with fake versions)
            mailSenderFake = Substitute.For<MailSender>();
            orderConfirmationEmailBuilderFake = Substitute.For<OrderConfirmationEmailBuilder>();

            // test target
            orderConfirmer = new OrderConfirmer(mailSenderFake, orderConfirmationEmailBuilderFake);
        }

        [Test]
        public void ConfirmingOrder_DraftOrder_OrderShouldBeConfirmed()
        {
            // Arrange
            var order = OrderTestDataFactory.GetDraftOrder();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            order.Status.Should().Be(OrderStatus.Confirmed);
        }

        [Test]
        public void ConfirmingOrder_ConfirmedOrder_ShouldNotBeAllowed()
        {
            // Arrange
            var order = OrderTestDataFactory.GetConfirmedOrder();

            // Act
            Action action = () => orderConfirmer.ConfirmOrder(order);

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void ConfirmingOrder_DraftOrder_ConfirmationEmailShouldBeSent()
        {
            var order = OrderTestDataFactory.GetDraftOrder();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            mailSenderFake.ReceivedWithAnyArgs().SendMail(null);
        }

        [Test]
        public void ConfirmingOrder_DraftOrder_ConfirmationEmailShouldBeOrderConfirmationForOrder()
        {
            var order = OrderTestDataFactory.GetDraftOrder();

            var mailMessageFromBuilder = new MailMessage();

            orderConfirmationEmailBuilderFake.BuildOrderConfirmationEmail(null)
                .ReturnsForAnyArgs(mailMessageFromBuilder);

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            mailSenderFake.Received().SendMail(mailMessageFromBuilder);
        }
    }
}