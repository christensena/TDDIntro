using CollaboratingClasses.Model;
using FluentAssertions;
using NUnit.Framework;
using UnitTests.CollaboratingClasses.Fakes;
using UnitTests.CollaboratingClasses.Helpers;
using UnitTests.CollaboratingClasses.Implementation;

namespace UnitTests.CollaboratingClasses.VerticalTests
{
    // vertical slice of order confirmation: updated order status
    [TestFixture]
    public class order_confirmation_updating_order_status
    {
        private OrderConfirmer orderConfirmer;
        private MailSenderFake mailSenderFake;

        [SetUp]
        public void SetUp()
        {
            // we still use a fake mail sender--don't want emails sent!
            mailSenderFake = new MailSenderFake();

            // we use the real order confirmation email builder rather than mocking it out
            // also we don't have separate tests on the mail builder (if vertical slice approach)
            orderConfirmer = new OrderConfirmer(mailSenderFake, new OrderConfirmationEmailBuilder());
        }

        [Test]
        public void should_set_status_to_ReadyToShip()
        {
            // Arrange
            var order = OrderTestDataFactory.GetDraftOrder();

            // Act
            orderConfirmer.ConfirmOrder(order);

            // Assert
            order.Status.Should().Be(OrderStatus.ReadyToShip);
        }
    }
}