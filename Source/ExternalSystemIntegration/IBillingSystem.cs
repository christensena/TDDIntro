using System.Collections.Generic;
using ChargifyNET;
using ExternalSystemIntegration.Implementation;

namespace ExternalSystemIntegration
{
    // compare this interface to IChargifyConnect!
    // it only contains what we need, nothing more
    // it is also expressed in the language of our domain (context map in DDD terms)
    // it is effectively an adapter or mediator to an external billing system
    public interface IBillingSystem
    {
        void AddSubscriber(Subscriber subscriber);
        Subscriber GetSubscriber(int subscriberId);

        IEnumerable<PlanSubscription> GetSubscriptions(int subscriberId);
        void SubscribeToPlan(int subscriberId, string planName);
        void Unsubscribe(int planSubscriptionId, string reasonMessage);
        IEnumerable<Plan> GetPlans();
    }

    // it's essential that in our application code, we only ever reference IBillingSystem and the model types
    // the chargify types should be hidden away
    // (in practice I would use a DI container for some of this)
    public static class BillingSystemFactory
    {
        public static IBillingSystem CreateBillingSystem()
        {
            var chargifyConnect = new ChargifyConnect();
            // configure chargify here

            return new ChargifyBillingSystem(chargifyConnect);
        }
    }
}