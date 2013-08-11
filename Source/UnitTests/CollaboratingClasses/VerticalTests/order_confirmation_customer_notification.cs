using System.Linq;
using CollaboratingClasses;
using FluentAssertions;
using NUnit.Framework;
using UnitTests.CollaboratingClasses.Fakes;
using UnitTests.CollaboratingClasses.Helpers;
using UnitTests.CollaboratingClasses.Implementation;

namespace UnitTests.CollaboratingClasses.VerticalTests
{
    // vertical slice of order confirmation: emailing customer
    [TestFixture]
    public class order_confirmation_customer_notification
    {
        private OrderConfirmer orderConfirmer;
        private Order order;
        private MailSenderFake mailSenderFake;

        [SetUp]
        public void confirming_order()
        {
            // Arrange
            order = OrderTestDataFactory.GetDraftOrder();

            // we still use a fake mail sender--don't want emails sent!
            mailSenderFake = new MailSenderFake();

            // we use the real order confirmation email builder rather than mocking it out
            // also we don't have separate tests on the mail builder (if vertical slice approach)
            orderConfirmer = new OrderConfirmer(mailSenderFake, new OrderConfirmationEmailBuilder(new TemplateEmailBuilder()));

            // Act
            orderConfirmer.ConfirmOrder(order);
        }

        [Test]
        public void email_sent_to_customer()
        {
            // Assert
            mailSenderFake.GetMessagesSentToAddress(order.Customer.Email).Should().NotBeEmpty();
        }

        [Test] 
        public void email_subject_has_order_number()
        {
            // Assert
            mailSenderFake.GetMessagesSentToAddress(order.Customer.Email).
                Single().Subject.Should().Contain(order.Code);
        }
    }
}