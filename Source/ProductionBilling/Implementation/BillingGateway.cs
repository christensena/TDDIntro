using System;
using System.Collections.Generic;
using System.Linq;
using ChargifyNET;

namespace ProductionBilling.Implementation
{
    // Aims: 
    // 1. reduce the surface area (and resultant complexity and less testability) of billing api to what we need+use
    // 2. make more expressive of our usage and language
    // 3. reduce dependence+coupling to a particular billing system
    public class BillingGateway : IBillingGateway
    {
        private readonly IChargifyConnect chargifyConnect;

        public BillingGateway(IChargifyConnect chargifyConnect)
        {
            this.chargifyConnect = chargifyConnect;
        }

        public IEnumerable<Plan> GetAvailablePlans()
        {
            var productList = chargifyConnect.GetProductList();
            return productList.Values.Select(Mapper.MapProductToPlan);
        }
        
        public Account GetAccount(string id)
        {
            var customer = chargifyConnect.LoadCustomer(id);
            return customer == null ? null : Mapper.MapCustomerToAccount(customer);
        }

        public Account AddAccount(string id, string firstName, string lastName, string emailAddress, string organisationName)
        {
            var customer = chargifyConnect.CreateCustomer(firstName, lastName, emailAddress, "", organisationName, id);
            return Mapper.MapCustomerToAccount(customer);
        }

        public void CancelSubscription(PlanSubscription planSubscription, string cancellationMessage)
        {
            if (planSubscription == null) throw new ArgumentNullException("planSubscription");

            chargifyConnect.DeleteSubscription(planSubscription.ChargifySubscriptionID, cancellationMessage);
        }

        public PlanSubscription SubscribeToPlan(string accountID, string planID)
        {
            var subscription = chargifyConnect.CreateSubscription(planID, accountID);
            return Mapper.MapSubscription(subscription);
        }

        public PlanSubscription GetCurrentSubscription(string accountID)
        {
            var customer = chargifyConnect.LoadCustomer(accountID);
            if (customer == null)
            {
                throw new ArgumentException("No customer found with ID: " + accountID);
            }

            var subscriptions = chargifyConnect.GetSubscriptionListForCustomer(customer.ChargifyID).Values;
            var activeBillingSubscriptions = subscriptions.Select(Mapper.MapSubscription).Where(s => s.IsLive);
            if (activeBillingSubscriptions.Count() > 1)
            {
                throw new InvalidOperationException("More than one plan subscribed to by customer with ID: " + accountID);
            }

            return activeBillingSubscriptions.SingleOrDefault();
        }

        public PlanSubscription ChangeSubscription(PlanSubscription subscription, string planID)
        {
            if (subscription == null) throw new ArgumentNullException("subscription");
            if (string.IsNullOrWhiteSpace(planID)) throw new ArgumentException(@"Must not be empty", "planID");

            var existingSubscription = GetCurrentSubscription(subscription.Account.ID);
            if (existingSubscription.Plan.IsPaid)
            {
                var editedSubscription = chargifyConnect.EditSubscriptionProduct(existingSubscription.ChargifySubscriptionID, planID);
                return Mapper.MapSubscription(editedSubscription);
            }
            else
            {
                var editedSubscription = chargifyConnect.EditSubscriptionProduct(subscription.ChargifySubscriptionID, planID);
                return Mapper.MapSubscription(editedSubscription);
            }
        }

        public Uri GetHostedSubscriptionPaymentPageUrl(PlanSubscription subscription)
        {
            if (subscription == null) throw new ArgumentNullException("subscription");

            return new Uri(chargifyConnect.GetSubscriptionUpdateURL(subscription.ChargifySubscriptionID));
        }

        public Uri GetHostedSignUpPageUrl(string accountID, string firstName, string lastName, string emailAddress, string organisationName, string planID)
        {
            var product = chargifyConnect.LoadProduct(planID);
            if (product == null) throw new ArgumentException("Plan not found with ID: " + planID);
            return HostedPageUrlGenerator.GenerateSignUpPageUrl(chargifyConnect.URL, product.ID, accountID, firstName, lastName, emailAddress, organisationName, planID);
        }

        public bool IsBillingEventAuthentic(string signature, string payload)
        {
            return payload.IsChargifyWebhookContentValid(signature, chargifyConnect.SharedKey);
        }

        public IBillingEvent ParseBillingEvent(string name, string rawPayload)
        {
            return ChargifyPayloadParser.ParseBillingEvent(name, rawPayload);
        }
    }
}