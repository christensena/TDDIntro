using System.Collections.Generic;
using ProductionBilling.Implementation;

namespace ProductionBilling.Events
{
    public class SubscriptionPlanChangeBillingEvent : BillingEvent
    {
        public string NewPlanID { get; private set; }

        internal SubscriptionPlanChangeBillingEvent(long organisationID, string newPlanID)
            : base(organisationID)
        {
            NewPlanID = newPlanID;
        }

        public static BillingEvent CreateFromPayload(IDictionary<string, string> payload)
        {
            var organisationID = long.Parse(payload[ChargifyFieldKeys.CustomerReference]);
            return new SubscriptionPlanChangeBillingEvent(
                organisationID,
                payload[ChargifyFieldKeys.SubscriptionProductHandle]);
        }
    }
}