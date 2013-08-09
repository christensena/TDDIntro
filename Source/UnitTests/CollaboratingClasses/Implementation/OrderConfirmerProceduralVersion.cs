using System;
using System.Net.Mail;
using CollaboratingClasses.Model;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class OrderConfirmerProceduralVersion
    {
        private const string OrderFulfilmentEmailAddress = "shipping@amce.com";

        public void ConfirmOrder(Order order)
        {
            if (order.Status != OrderStatus.Draft)
            {
                throw new InvalidOperationException("Only draft orders can be confirmed");
            }

            order.Status = OrderStatus.ReadyToShip;

            var smtpClient = new SmtpClient();

            // these emails would be much longer in practice and probably not hard coded!
            var confirmationEmail = new MailMessage(
                "donotreply@acme.com",
                order.Customer.Email,
                "Order confirmation: " + order.Code,
                "Hello there, Your order is confirmed and has gone off for processing");
  
            smtpClient.Send(confirmationEmail);

            var shipmentRequestEmail = new MailMessage(
                "donotreply@acme.com",
                OrderFulfilmentEmailAddress,
                "Order shipment request: " + order.Code,
                "Hello there, this order is confirmed. Please arrange shipment."); 
            smtpClient.Send(shipmentRequestEmail);

            // maybe save order here as this would be typical procedural style (i.e. no persistence ignorance)

        }
    }
}