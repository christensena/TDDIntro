using System;
using System.Net.Mail;

namespace CollaboratingClasses
{
    public class OrderConfirmer
    {
        private readonly MailSender mailSender;

        public OrderConfirmer(MailSender mailSender)
        {
            this.mailSender = mailSender;
        }

        public void ConfirmOrder(Order order)
        {
            order.Confirm();

            var mailMessage = new MailMessage(
                "donotreply@acme.com", 
                order.Customer.Email, 
                "Order confirmation: " + order.Code, 
                "Order Confirmed");

            mailSender.SendMail(mailMessage);
        }
    }
}