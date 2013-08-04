namespace ProductionBilling.Events
{
    // billing event for webhook testing
    public class TestBillingEvent : BillingEvent
    {
        public TestBillingEvent()
            : base(1)
        {
            
        }
    }
}