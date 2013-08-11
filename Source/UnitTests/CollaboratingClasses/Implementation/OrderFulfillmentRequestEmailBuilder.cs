using System;
using System.Net.Mail;
using CollaboratingClasses;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class OrderFulfillmentRequestEmailBuilder
    {
        private const string OrderFulfilmentEmailAddress = "shipping@ame.com";

        public virtual MailMessage BuildOrderFulfillmentRequestEmailBuilder(Order order)
        {
            if (order == null) throw new ArgumentNullException("order");

            return new MailMessage(
                "donotreply@acme.com",
                OrderFulfilmentEmailAddress,
                "Order shipment request: " + order.Code,
                "Hello there, this order is confirmed. Please arrange shipment."); 
        }
    }
}