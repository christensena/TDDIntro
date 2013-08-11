using CollaboratingClasses;

namespace UnitTests.CollaboratingClasses.Helpers
{
    internal static class OrderTestDataFactory
    {
        public static Order GetDraftOrder()
        {
            return new Order(new Customer("Alan", "Christensen", "alan@christensen.org.nz"), "1234");
        }

        public static Order GetConfirmedOrder()
        {
            var order = GetDraftOrder();
            order.FlagAsReadyToShip();
            return order;
        }
    }
}