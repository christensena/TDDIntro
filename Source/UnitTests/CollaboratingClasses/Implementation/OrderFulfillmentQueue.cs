using CollaboratingClasses.Model;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class OrderFulfillmentQueue
    {
        private readonly OrderFulfillmentRequestEmailBuilder emailBuilder;
        private readonly MailSender mailSender;

        public OrderFulfillmentQueue(OrderFulfillmentRequestEmailBuilder emailBuilder, MailSender mailSender)
        {
            this.emailBuilder = emailBuilder;
            this.mailSender = mailSender;
        }

        public virtual void Enqueue(Order order)
        {
            var mailMessage = emailBuilder.BuildOrderFulfillmentRequestEmailBuilder(order);
            mailSender.SendMail(mailMessage);
        }

        // for tests
        protected OrderFulfillmentQueue()
        {
            
        }
    }
}