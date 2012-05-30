using System;

namespace CollaboratingClasses
{
    public class Order
    {
        public string Code { get; private set; }

        public Customer Customer { get; private set; }

        public OrderStatus Status { get; private set; }

        public Order(Customer customer, string code)
        {
            if (customer == null) throw new ArgumentNullException("customer");
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Cannot be empty", "code");

            Customer = customer;
            Code = code;
            Status = OrderStatus.Draft;
        }

        internal void FlagAsConfirmed()
        {
            if (Status != OrderStatus.Draft)
                throw new InvalidOperationException("Only draft orders can be confirmed.");

            Status = OrderStatus.Confirmed;
        }

        internal void FlagAsShipped()
        {
            if (Status != OrderStatus.Confirmed)
                throw new InvalidOperationException("Only confirmed orders can be shipped.");

            Status = OrderStatus.Confirmed;
        }

        public bool Equals(Order other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Code, Code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Order)) return false;
            return Equals((Order) obj);
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}