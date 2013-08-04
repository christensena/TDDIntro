using System.Collections.Generic;
using ProductionBilling.Implementation;

namespace ProductionBilling.Events
{
    public abstract class SubscriptionStateChangeBillingEvent : BillingEvent
    {
        public int SubscriptionID { get; private set; }

        public PlanSubscriptionState NewState { get; private set; }

        internal SubscriptionStateChangeBillingEvent(long organisationID, int subscriptionID, PlanSubscriptionState newState)
            : base(organisationID)
        {
            SubscriptionID = subscriptionID;
            NewState = newState;
        }

        public static IBillingEvent CreateFromPayload(IDictionary<string, string> payload)
        {
            var organisationID = long.Parse(payload[ChargifyFieldKeys.CustomerReference]);
            var subscriptionID = int.Parse(payload[ChargifyFieldKeys.SubscriptionID]);
            var planSubscriptionState = Mapper.MapChargifySubscriptionState(payload[ChargifyFieldKeys.SubscriptionState]);

            switch (planSubscriptionState)
            {
                case PlanSubscriptionState.Ended: // don't support catastrophic cancellation triggered from Chargify!
                    return new IgnoredBillingEvent();

                case PlanSubscriptionState.Unpaid:
                    return new SubscriptionUnpaidBillingEvent(organisationID, subscriptionID);

                default:
                    return new IgnoredBillingEvent();
            }
        }
    }
}