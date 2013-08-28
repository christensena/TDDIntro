using System;
using System.Collections.Generic;
using System.Net.Mail;
using CollaboratingClasses;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class OrderConfirmationCustomerNotifier
    {
        private readonly TemplateEmailBuilder templateEmailBuilder;
        private readonly MailSender mailSender;

        public OrderConfirmationCustomerNotifier(TemplateEmailBuilder templateEmailBuilder, MailSender mailSender)
        {
            this.templateEmailBuilder = templateEmailBuilder;
            this.mailSender = mailSender;
        }

        public virtual void SendOrderConfirmedNotification(Order order)
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
            
            mailSender.SendMail(mailMessage);
        }

        protected OrderConfirmationCustomerNotifier()
        {   
        }
    }
}