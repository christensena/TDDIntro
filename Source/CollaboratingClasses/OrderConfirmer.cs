using System.Threading;

namespace CollaboratingClasses
{
    public class OrderConfirmer
    {
        private readonly MailSender mailSender;
        private readonly OrderConfirmationEmailBuilder orderConfirmationEmailBuilder;
        private readonly OrderFulfillmentQueue orderFulfillmentQueue;

        public OrderConfirmer(MailSender mailSender, OrderConfirmationEmailBuilder orderConfirmationEmailBuilder, OrderFulfillmentQueue orderFulfillmentQueue)
        {
            this.mailSender = mailSender;
            this.orderConfirmationEmailBuilder = orderConfirmationEmailBuilder;
            this.orderFulfillmentQueue = orderFulfillmentQueue;
        }

        public void ConfirmOrder(Order order)
        {
            order.FlagAsConfirmed();

            var mailMessage = orderConfirmationEmailBuilder.BuildOrderConfirmationEmail(order);

            orderFulfillmentQueue.Enqueue(order);

            mailSender.SendMail(mailMessage);
        }
    }
}