using System;
using System.Collections.Generic;
using System.Net.Mail;
using CollaboratingClasses;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class OrderConfirmationEmailBuilder
    {
        private readonly TemplateEmailBuilder templateEmailBuilder;

        public OrderConfirmationEmailBuilder(TemplateEmailBuilder templateEmailBuilder)
        {
            this.templateEmailBuilder = templateEmailBuilder;
        }

        public virtual MailMessage BuildOrderConfirmationEmail(Order order)
        {
            if (order == null) throw new ArgumentNullException("order");

            var tokens = new Dictionary<string, string>
                                 {
                                     {"customer-full-name", order.Customer.FirstName + order.Customer.LastName},
                                     {"ordernumber", order.Code}
                                 };

            var mailMessage = templateEmailBuilder.BuildEmail("orderconfirmation", tokens);
            mailMessage.To.Add(order.Customer.Email);
            mailMessage.Subject = "Order confirmed: " + order.Code;
            return mailMessage;
        }

        protected OrderConfirmationEmailBuilder()
        {   
        }
    }
}