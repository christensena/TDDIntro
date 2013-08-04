using System;

namespace ProductionBilling.Implementation
{
    // see http://docs.chargify.com/hosted-page-integration
    internal static class HostedPageUrlGenerator
    {
        public static Uri GenerateSignUpPageUrl(string baseUrl, int productID, string accountID, string firstName, string lastName, string emailAddress, string organisationName, string planID)
        {
            //https://tradevine-test.chargify.com/h/79544/subscriptions/new
            return new Uri(string.Format("{0}/h/{1}/subscriptions/new?first_name={2}&last_name={3}&email={4}&reference={5}&organization={6}", 
                baseUrl, productID, firstName, lastName, emailAddress, accountID, organisationName));
        }
    }
}