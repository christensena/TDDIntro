namespace ProductionBilling
{
    public class Plan
    {
        public string ID { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public decimal Price { get; internal set; }

        public bool IsPaid
        {
            get { return Price != 0; }
        }

        internal Plan()
        {
        }
    }
}