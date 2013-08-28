using System;
using CollaboratingClasses;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class OrderConfirmer
    {
        private readonly OrderConfirmationCustomerNotifier orderConfirmationCustomerNotifier;

        public OrderConfirmer(OrderConfirmationCustomerNotifier orderConfirmationCustomerNotifier)
        {
            this.orderConfirmationCustomerNotifier = orderConfirmationCustomerNotifier;
        }

        public void ConfirmOrder(Order order)
        {
            orderConfirmationCustomerNotifier.SendOrderConfirmedNotification(order);

            order.FlagAsReadyToShip();
        }
    }
}