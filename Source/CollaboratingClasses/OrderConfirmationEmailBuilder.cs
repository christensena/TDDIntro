using System;
using System.Net.Mail;

namespace CollaboratingClasses
{
    public class OrderConfirmationEmailBuilder
    {
        public virtual MailMessage BuildOrderConfirmationEmail(Order order)
        {
            if (order == null) throw new ArgumentNullException("order");

            return new MailMessage(
                "donotreply@acme.com",
                order.Customer.Email,
                "Order confirmation: " + order.Code,
                "Order Confirmed");
        }
    }
}