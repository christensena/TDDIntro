using System;
using ChargifyNET;

namespace ProductionBilling.Implementation
{
    public class Mapper
    {
        public static Plan MapProductToPlan(IProduct chargifyProduct)
        {
            return new Plan
                       {
                           ID = chargifyProduct.Handle,
                           Name = chargifyProduct.Name,
                           Description = chargifyProduct.Description,
                           Price = chargifyProduct.Price
                       };
        }

        public static Account MapCustomerToAccount(ICustomer chargifyCustomer)
        {
            return new Account
                       {
                           ID = chargifyCustomer.SystemID,
                           FirstName = chargifyCustomer.FirstName,
                           LastName = chargifyCustomer.LastName,
                           Email = chargifyCustomer.Email,
                           OrganisationName = chargifyCustomer.Organization
                       };
        }

        public static PlanSubscription MapSubscription(ISubscription chargifySubscription)
        {
            return new PlanSubscription
                       {
                           ChargifySubscriptionID = chargifySubscription.SubscriptionID,
                           Plan = MapProductToPlan(chargifySubscription.Product),
                           Account = MapCustomerToAccount(chargifySubscription.Customer),
                           ActivatedAt = chargifySubscription.ActivatedAt.ToUniversalTime(),
                           NextAssessmentAt = chargifySubscription.NextAssessmentAt.ToUniversalTime(),
                           CurrentPeriodStartedAt = chargifySubscription.CurrentPeriodStartedAt.ToUniversalTime(),
                           CurrentPeriodEndsAt = chargifySubscription.CurrentPeriodEndsAt.ToUniversalTime(),
                           ExpiresAt = chargifySubscription.ExpiresAt.ToUniversalTime(),
                           TrialStartedAt = chargifySubscription.TrialStartedAt.ToUniversalTime(),
                           TrialEndedAt = chargifySubscription.TrialEndedAt.ToUniversalTime(),
                           State = MapChargifySubscriptionState(chargifySubscription.State.ToString())
                       };
        }

        public static PlanSubscriptionState MapChargifySubscriptionState(string chargifySubscriptionState)
        {
            // we ignore some of the states as they're not important to us
            // http://docs.chargify.com/subscription-states
            switch (chargifySubscriptionState)
            {
                case "active":
                case "trialing": // trials are done externally from Chargify
                case "assessing": // internal chargify state
                case "soft_failure":
                case "suspended": // currently unused; map to Active for safety
                    return PlanSubscriptionState.Active;

                case "past_due":
                    return PlanSubscriptionState.PastDue; // we don't use this state at the moment. treated as 'active'

                case "unpaid":
                    return PlanSubscriptionState.Unpaid;

                case "expired":
                case "canceled":
                    return PlanSubscriptionState.Ended;

                default:
                    throw new NotImplementedException("Unrecognised subscription state: " + chargifySubscriptionState);
            }
        }
    }
}