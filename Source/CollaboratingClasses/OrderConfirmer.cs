using System;

namespace CollaboratingClasses
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
            order.FlagAsConfirmed();

            var mailMessage = orderConfirmationEmailBuilder.BuildOrderConfirmationEmail(order);

            mailSender.SendMail(mailMessage);
        }
    }
}