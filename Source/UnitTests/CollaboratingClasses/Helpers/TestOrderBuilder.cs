using CollaboratingClasses;

namespace UnitTests.CollaboratingClasses.Helpers
{
    internal class TestOrderBuilder
    {
        private Customer customer;
        private string code;
        private Order order;

        public TestOrderBuilder WithCustomer(Customer customer)
        {
            this.customer = customer;

            return this;
        }

        public TestOrderBuilder WithCode(string code)
        {
            this.code = code;

            return this;
        }

        public TestOrderBuilder AsDraft()
        {
            EnsureOrder();
            
            // can't set to draft as that's default state and can't go back

            return this;
        }

        public TestOrderBuilder AsReadyToShip()
        {
            EnsureOrder();

            order.FlagAsReadyToShip();

            return this;
        }

        public Order Build()
        {
            EnsureOrder();

            return order;
        }

        private void EnsureOrder()
        {
            if (order == null)
            {
                if (customer == null)
                {
                    // todo; make a customer builder
                    customer = new Customer("Alan", "Christensen", "alan@christensen.org.nz");
                }

                if (string.IsNullOrWhiteSpace(code))
                {
                    code = Randomizer.RandomString();
                }
                order = new Order(customer, code);
            }
        }
    }
}