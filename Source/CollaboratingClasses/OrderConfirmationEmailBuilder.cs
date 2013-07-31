using System;
using System.Net.Mail;

namespace CollaboratingClasses
{
    public class OrderConfirmationEmailBuilder
    {
        public virtual MailMessage BuildOrderConfirmationEmail(Order order)
        {
            if (order == null) throw new ArgumentNullException("order");

            // if you look at this code, it's clearly not finished
            // and it would ideally not be drafting entire email messages!
            // (job of this class should be just to match the order details to an email)
            // so again we'd take on a dependency, maybe to an external templating library
            // 
            // but we're building re-usable code, our application code is not
            // over-complicated by all sorts of concerns
            return new MailMessage(
                "donotreply@acme.com",
                order.Customer.Email,
                "Order confirmation: " + order.Code,
                "Hello there, Your order is confirmed and has gone off for processing");
        }
    }
}