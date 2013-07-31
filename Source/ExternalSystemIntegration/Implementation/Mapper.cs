using System;
using ChargifyNET;

namespace ExternalSystemIntegration
{
    /// <summary>
    /// Maps from the domain of Chargify to our domain.
    /// For example, we talk about Subscribers instead of Customers (customers to our system are customers of our customers!)
    /// we talk about Plans instead of Products (products in our system are products of our customers, i.e. physical things).
    /// 
    /// by doing this we avoid all the confusion that could result in the core code base 
    /// and define how the concepts match up in one place
    /// </summary>
    internal static class Mapper
    {
        public static Subscriber MapCustomerToSubscriber(ICustomer customer)
        {
            return new Subscriber
                       {
                           Id = int.Parse(customer.SystemID),
                           FirstName = customer.FirstName,
                           LastName = customer.LastName,
                           Email = customer.Email,
                           Organisation = customer.Organization
                       };
        }

        public static PlanSubscription MapSubscriptionToPlanSubscription(ISubscription subscription, Func<string, Plan> lookupPlanById)
        {
            return new PlanSubscription
                       {
                           Id = subscription.SubscriptionID,
                           Plan = lookupPlanById(subscription.Product.Handle),
                           Subscriber = MapCustomerToSubscriber(subscription.Customer) // in actual system probably look up db
                       };
        }

        public static ICustomer MapSubscriberToCustomer(Subscriber subscriber)
        {
            return new Customer(
                subscriber.FirstName,
                subscriber.LastName,
                subscriber.Email,
                subscriber.Organisation,
                subscriber.Id.ToString());
        }
    }
}