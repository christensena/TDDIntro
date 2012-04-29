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

        [SetUp]
        public void SetUp()
        {
            mailSenderFake = Substitute.For<MailSender>();

            // this is the version where we decide to keep the unit large
            // i.e. include collaborating classes rather than unit testing
            // them separately
            orderConfirmer = new OrderConfirmer(mailSenderFake, new OrderConfirmationEmailBuilder());

        }

        [Test]
        public void ConfirmingOrder_DraftOrder_OrderShouldBeConfirmed()
        {
            // Arrange
            var order = GetDraftOrder();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            order.Status.Should().Be(OrderStatus.Confirmed);
        }

        [Test]
        public void ConfirmingOrder_ConfirmedOrder_ShouldNotBeAllowed()
        {
            // Arrange
            var order = GetConfirmedOrder();

            // Act
            Action action = () => orderConfirmer.ConfirmOrder(order);

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void ConfirmingOrder_DraftOrder_ConfirmationEmailShouldBeSent()
        {
            var order = GetDraftOrder();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            mailSenderFake.ReceivedWithAnyArgs().SendMail(null);
        }

        [Test]
        public void ConfirmingOrder_DraftOrder_ConfirmationEmailShouldBeSentToCustomer()
        {
            var order = GetDraftOrder();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            mailSenderFake.Received().SendMail(
                Arg.Is<MailMessage>(m => m.To.Any(to => to.Address == order.Customer.Email)));
        }

        private static Order GetDraftOrder()
        {
            return new Order(new Customer("Alan", "Christensen", "alan@tradevine.com"), "1234");
        }

        private static Order GetConfirmedOrder()
        {
            var order = GetDraftOrder();
            order.Confirm();
            return order;
        }
    }
}