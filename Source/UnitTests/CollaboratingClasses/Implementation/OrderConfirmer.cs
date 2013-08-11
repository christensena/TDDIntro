using System;
using CollaboratingClasses;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class OrderConfirmer
    {
        private readonly MailSender mailSender;
        private readonly OrderConfirmationEmailBuilder orderConfirmationEmailBuilder;

        public OrderConfirmer(MailSender mailSender, OrderConfirmationEmailBuilder orderConfirmationEmailBuilder)
        {
            this.mailSender = mailSender;
            this.orderConfirmationEmailBuilder = orderConfirmationEmailBuilder;
        }

        public void ConfirmOrder(Order order)
        {
            var customerMessage = orderConfirmationEmailBuilder.BuildOrderConfirmationEmail(order);
            mailSender.SendMail(customerMessage);

            order.FlagAsReadyToShip();
        }
    }
}