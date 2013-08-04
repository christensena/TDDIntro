namespace ProductionBilling.Events
{
    public class SubscriptionUnpaidBillingEvent : SubscriptionStateChangeBillingEvent
    {
        public SubscriptionUnpaidBillingEvent(long organisationID, int subscriptionID)
            : base(organisationID, subscriptionID, PlanSubscriptionState.Unpaid)
        {
        }
    }
}