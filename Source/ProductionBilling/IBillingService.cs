using System;
using System.Collections.Generic;

namespace ProductionBilling
{
    public interface IBillingService
    {
        /// <summary>
        /// Get plans that can be chosen by the user.
        /// </summary>
        /// <returns></returns>
        IEnumerable<BillingPlan> GetAvailablePlans();

        /// <summary>
        /// Gets the details of a particulary plan by ID.
        /// </summary>
        /// <param name="planID"></param>
        /// <returns></returns>
        BillingPlan GetPlanByID(string planID);

        /// <summary>
        /// Either performs the plan change request or returns the Uri through which that
        /// can be done via an external service (i.e. billing system).
        /// </summary>
        SubscriptionModificationResult PerformPlanChangeRequest(string planID);

        /// <summary>
        /// Validates that the billing event is valid by comparing with the shared key.
        /// </summary>
        /// <param name="signature">public signature provided</param>
        /// <param name="payload">payload</param>
        /// <returns><c>true</c> if the billing event is valid</returns>
        bool IsRawBillingEventAuthentic(string signature, string payload);

        /// <summary>
        /// Processes a billing event.
        /// </summary>
        /// <param name="eventName">Event name</param>
        /// <param name="payload">Payload contain the details of the event</param>
        void ProcessRawBillingEvent(string eventName, string payload);

        /// <summary>
        /// Sign organisation up to paid subscription.
        /// </summary>
        void ProcessPaidSubscriptionSignUp(long organisationID, string planID);

        /// <summary>
        /// Selects a free plan.
        /// </summary>
        /// <exception cref="ArgumentException">If planID is not a free plan</exception>
        /// <remarks>
        /// Paid plans must be selected via <see cref="ProcessPaidSubscriptionSignUp"/>.
        /// </remarks>
        void SelectFreePlan(string planID);

        /// <summary>
        /// Cancel the given organisation in the system including stopping any billing, suspending from processor polling, etc.
        /// </summary>
        void CancelAccount(string reason);

        /// <summary>
        /// Get the URL for the hosted update payment details page.
        /// </summary>
        Uri GetHostedUpdatePaymentDetailsPageUrl();
    }
}