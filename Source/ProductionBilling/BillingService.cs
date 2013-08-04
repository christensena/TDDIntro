using System;
using System.Collections.Generic;

namespace ProductionBilling
{
    public class BillingService : IBillingService
    {
        private readonly IBillingGateway billingGateway;
        private readonly SubscriptionPlanChanger subscriptionPlanChanger;
        private readonly FreePlanSelector freePlanSelector;
        private readonly PaidSubscriptionSignUpHandler paidSubscriptionSignUpHandler;
        private readonly RawBillingEventProcessor rawBillingEventProcessor;
        private readonly AccountCanceller accountCanceller;
        private readonly HostedPaymentDetailsUrlProvider hostedPaymentDetailsUrlProvider;
        private readonly BillingPlanLookup billingPlanLookup;

        public BillingService(
            IBillingGateway billingGateway,
            SubscriptionPlanChanger subscriptionPlanChanger,
            FreePlanSelector freePlanSelector,
            PaidSubscriptionSignUpHandler paidSubscriptionSignUpHandler,
            RawBillingEventProcessor rawBillingEventProcessor,
            AccountCanceller accountCanceller,
            HostedPaymentDetailsUrlProvider hostedPaymentDetailsUrlProvider,
            BillingPlanLookup billingPlanLookup)
        {
            this.billingGateway = billingGateway;
            this.subscriptionPlanChanger = subscriptionPlanChanger;
            this.freePlanSelector = freePlanSelector;
            this.paidSubscriptionSignUpHandler = paidSubscriptionSignUpHandler;
            this.rawBillingEventProcessor = rawBillingEventProcessor;
            this.accountCanceller = accountCanceller;
            this.hostedPaymentDetailsUrlProvider = hostedPaymentDetailsUrlProvider;
            this.billingPlanLookup = billingPlanLookup;
        }

        public IEnumerable<BillingPlan> GetAvailablePlans()
        {
            return billingPlanLookup.GetAvailablePlans();
        }

        public BillingPlan GetPlanByID(string planID)
        {
            return billingPlanLookup.GetPlanByID(planID);
        }

        public SubscriptionModificationResult PerformPlanChangeRequest(string planID)
        {
            return subscriptionPlanChanger.PerformPlanChangeRequest(planID);
        }

        public bool IsRawBillingEventAuthentic(string signature, string payload)
        {
            return billingGateway.IsBillingEventAuthentic(signature, payload);
        }

        public void ProcessRawBillingEvent(string eventName, string payload)
        {
            rawBillingEventProcessor.ProcessRawBillingEvent(eventName, payload);
        }

        public void ProcessPaidSubscriptionSignUp(long organisationID, string planID)
        {
            paidSubscriptionSignUpHandler.ProcessPaidSubscriptionSignUp(organisationID, planID);
        }

        public void SelectFreePlan(string planID)
        {
            freePlanSelector.SelectFreePlan(planID);
        }

        public void CancelAccount(string reason)
        {
            accountCanceller.CancelAccount(reason);
        }

        public Uri GetHostedUpdatePaymentDetailsPageUrl()
        {
            return hostedPaymentDetailsUrlProvider.GetHostedUpdatePaymentDetailsUrl();
        }
    }

    public class BillingPlan
    {
    }

    public class SubscriptionModificationResult
    {
    }

    public class BillingPlanLookup
    {
        public IEnumerable<BillingPlan> GetAvailablePlans()
        {
            throw new NotImplementedException();
        }

        public BillingPlan GetPlanByID(string planID)
        {
            throw new NotImplementedException();
        }
    }

    public class HostedPaymentDetailsUrlProvider
    {
        public Uri GetHostedUpdatePaymentDetailsUrl()
        {
            throw new NotImplementedException();
        }
    }

    public class AccountCanceller
    {
        public void CancelAccount(string reason)
        {
            throw new NotImplementedException();
        }
    }

    public class RawBillingEventProcessor
    {
        public void ProcessRawBillingEvent(string eventName, string payload)
        {
            throw new NotImplementedException();
        }
    }

    public class PaidSubscriptionSignUpHandler
    {
        public void ProcessPaidSubscriptionSignUp(long organisationID, string planID)
        {
            throw new NotImplementedException();
        }
    }

    public class FreePlanSelector
    {
        public void SelectFreePlan(string planID)
        {
            throw new NotImplementedException();
        }
    }

    public class SubscriptionPlanChanger
    {
        public SubscriptionModificationResult PerformPlanChangeRequest(string planID)
        {
            throw new NotImplementedException();
        }
    }
}
