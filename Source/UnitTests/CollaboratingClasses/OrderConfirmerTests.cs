using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using CollaboratingClasses;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnitTests.CollaboratingClasses.Helpers;

namespace UnitTests.CollaboratingClasses
{
    [TestFixture]
    public class OrderConfirmerTests
    {
        private OrderConfirmer orderConfirmer;
        private MailSender mailSenderFake;
        private OrderConfirmationEmailBuilder orderConfirmationEmailBuilderFake;
        private OrderFulfillmentQueue orderFulfillmentQueueFake;

        [SetUp]
        public void SetUp()
        {
            // dependencies (substituted with fake versions)
            mailSenderFake = Substitute.For<MailSender>();
            orderConfirmationEmailBuilderFake = Substitute.For<OrderConfirmationEmailBuilder>();
            orderFulfillmentQueueFake = Substitute.For<OrderFulfillmentQueue>();
            orderFulfillmentQueueFake.WhenForAnyArgs(x => x.Enqueue(null)).Do(ci => { });

            // test target
            orderConfirmer = new OrderConfirmer(mailSenderFake, orderConfirmationEmailBuilderFake, orderFulfillmentQueueFake);
        }

        // basic state test. order status should change to confirmed
        // if we confirm a draft order
        [Test]
        public void ConfirmingOrder_DraftOrder_OrderShouldBeConfirmed()
        {
            // Arrange
            var order = BuildEntity.Order.AsDraft().Build();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            order.Status.Should().Be(OrderStatus.Confirmed);
        }

        // what happens if the order is already confirmed? invalid. shouldn't get here but make sure we don't
        // get an order repeat (remember those web forms with the warnings about clicking Submit twice?)
        [Test]
        public void ConfirmingOrder_ConfirmedOrder_ShouldNotBeAllowed()
        {
            // Arrange
            var order = BuildEntity.Order.AsReadyToShip().Build();

            // Act
            Action action = () => orderConfirmer.ConfirmOrder(order);

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        // verify via behaviour. locks us in to implementation
        [Test]
        public void ConfirmingOrder_DraftOrder_ConfirmationEmailShouldBeSent()
        {
            var order = BuildEntity.Order.AsDraft().Build();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            mailSenderFake.ReceivedWithAnyArgs().SendMail(null);
        }

        // when we go to write this we realise that to verify the confirmation email content
        // feels hard and awkward--listen to tests: creating a confirmation email is probably
        // a separate responsibility, separate test suite, separate "unit".

        // at this point we create a 'dependency' for building emails but we don't 
        // need to implement now. dynamic stubs/substitute can help here
        // this substitute also lets us try out, define our API for building emails
        [Test]
        public void ConfirmingOrder_DraftOrder_ConfirmationEmailShouldBeOrderConfirmationForOrder()
        {
            var order = BuildEntity.Order.AsDraft().Build();

            var mailMessageFromBuilder = new MailMessage();

            orderConfirmationEmailBuilderFake.BuildOrderConfirmationEmail(order)
                .ReturnsForAnyArgs(mailMessageFromBuilder);

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            mailSenderFake.Received().SendMail(mailMessageFromBuilder);
        }

        [Test]
        public void ConfirmingOrder_DraftOrder_ShouldQueueOrderFulfillment()
        {
            // Arrange
            var order = BuildEntity.Order.AsDraft().Build();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            orderFulfillmentQueueFake.Received().Enqueue(order);
        }
    }
}