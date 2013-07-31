using System.Collections.Generic;
using System.Linq;
using ChargifyNET;

namespace ExternalSystemIntegration.Implementation
{
    // this is an example billing system implementation that uses Chargify
    internal class ChargifyBillingSystem : IBillingSystem
    {
        private readonly IChargifyConnect chargify;

        public ChargifyBillingSystem(IChargifyConnect chargify)
        {
            this.chargify = chargify;
        }

        public void AddSubscriber(Subscriber subscriber)
        {
            chargify.CreateCustomer(Mapper.MapSubscriberToCustomer(subscriber));
        }

        public Subscriber GetSubscriber(int subscriberId)
        {
            var customer = chargify.LoadCustomer(subscriberId.ToString());
            if (customer == null)
                return null;

            return Mapper.MapCustomerToSubscriber(customer);
        }

        public IEnumerable<PlanSubscription> GetSubscriptions(int subscriberId)
        {
            var plans = GetPlans();
            return chargify.GetSubscriptionListForCustomer(subscriberId).Values.Select(
                s => Mapper.MapSubscriptionToPlanSubscription(s, planId => plans.Single(p => p.Id == planId))).ToList();
        }

        public void SubscribeToPlan(int subscriberId, string planName)
        {
            chargify.CreateSubscription(planName, subscriberId.ToString());
        }

        public void Unsubscribe(int planSubscriptionId, string reasonMessage)
        {
            chargify.DeleteSubscription(planSubscriptionId, reasonMessage);
        }

        // we could get the plans from chargify, or we could define them ourselves and just
        // make sure they map to chargify's
        public IEnumerable<Plan> GetPlans()
        {
            return new List<Plan>
                       {
                           new Plan {Id = "free", Title = "Free but not very useful"},
                           new Plan {Id = "standard", Title = "The plan you probably should choose"},
                           new Plan {Id = "enterprise", Title = "You have big truck, lots of folks"}
                       };
        }
    }
}