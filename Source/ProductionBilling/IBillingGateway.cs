using System;
using System.Collections.Generic;

namespace ProductionBilling
{
    public interface IBillingGateway
    {
        /// <summary>
        /// Gets all the plans that can be subscribed to.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Plan> GetAvailablePlans();

        /// <summary>
        /// Get the account for <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Unique ID e.g. Organisation ID</param>
        /// <returns>The account for <paramref name="id"/> or <c>null</c> if not found.</returns>
        Account GetAccount(string id);

        /// <summary>
        /// Creates an account.
        /// </summary>
        /// <param name="id">Unique ID e.g. Organisation ID</param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="organisationName"></param>
        Account AddAccount(string id, string firstName, string lastName, string emailAddress, string organisationName);

        /// <summary>
        /// Subscribe to a plan for an account.
        /// </summary>
        PlanSubscription SubscribeToPlan(string accountID, string planID);

        /// <summary>
        /// Obtain the current plan for the account with id <paramref name="accountID"/>.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>The plan subscription or <c>null</c> if none</returns>
        /// <exception cref="ArgumentException">If <paramref name="accountID"/> is not a known account.</exception>
        PlanSubscription GetCurrentSubscription(string accountID);

        /// <summary>
        /// Migrates to another subscription including pro-rating.
        /// </summary>
        /// <param name="subscription">The suscription to migrate.</param>
        /// <param name="planID">The plan to switch to.</param>
        /// <returns>The updated subscription.</returns>
        PlanSubscription ChangeSubscription(PlanSubscription subscription, string planID);

        /// <summary>
        /// Cancel current subscription for account with ID <paramref name="accountID"/>.
        /// </summary>
        /// <param name="subscription">The suscription to cancel</param>
        /// <param name="cancellationMessage">Message to attach to cancellation in billing system (e.g. reason for cancellation)</param>
        void CancelSubscription(PlanSubscription subscription, string cancellationMessage);

        /// <summary>
        /// Get the url of the hosted page for entering payment details on the chargify site.
        /// </summary>
        /// <param name="subscription">The subscription to update payment for.</param>
        /// <returns>The URL to send the user's browser to to enter their billing info.</returns>
        /// <remarks>As of Jan 12 2012 this page on Chargify does not validate credit card detaails.</remarks>
        Uri GetHostedSubscriptionPaymentPageUrl(PlanSubscription subscription);

        /// <summary>
        /// Gets the url of the hosted signup page prepopulated as given in the parameters.
        /// </summary>
        Uri GetHostedSignUpPageUrl(string accountID, string firstName, string lastName, string emailAddress, string organisationName, string planID);

        /// <summary>
        /// Validates that the billing event is valid by comparing with the shared key.
        /// </summary>
        /// <param name="signature">public signature provided</param>
        /// <param name="payload">payload</param>
        /// <returns><c>true</c> if the billing event is valid</returns>
        bool IsBillingEventAuthentic(string signature, string payload);

        /// <summary>
        /// Parses a payload from a Chargify webhook and turns it into one of the derived <see cref="BillingEvent"/> instance.
        /// </summary>
        /// <param name="name">Event name</param>
        /// <param name="rawPayload">Payload</param>
        IBillingEvent ParseBillingEvent(string name, string rawPayload);
    }
}