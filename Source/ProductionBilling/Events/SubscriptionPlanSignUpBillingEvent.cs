namespace ProductionBilling.Events
{
    public class SubscriptionPlanSignUpBillingEvent : BillingEvent
    {
        public string PlanID { get; private set; }

        public SubscriptionPlanSignUpBillingEvent(long organisationID, string planID)
            : base(organisationID)
        {
            PlanID = planID;
        }
    }
}