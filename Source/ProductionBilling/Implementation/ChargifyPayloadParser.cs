using System;
using System.Collections.Generic;
using ProductionBilling.Events;

namespace ProductionBilling.Implementation
{
    internal static class ChargifyPayloadParser
    {
        public static class ChargifyEventNames
        {
            public const string SubscriptionStateChange = "subscription_state_change";
            public const string SubscriptionProductChange = "subscription_product_change";
            public const string Test = "test";
        }

        public static IBillingEvent ParseBillingEvent(string name, string payload)
        {
            var payloadStringDictionary = ParseKeyValuePairsFromPayload(payload);

            switch (name)
            {
                case ChargifyEventNames.SubscriptionStateChange:
                    return SubscriptionStateChangeBillingEvent.CreateFromPayload(payloadStringDictionary);

                case ChargifyEventNames.SubscriptionProductChange:
                    return SubscriptionPlanChangeBillingEvent.CreateFromPayload(payloadStringDictionary);

                case ChargifyEventNames.Test:
                    return new TestBillingEvent();

                default:
                    throw new NotSupportedException("Unrecognised Chargify event name: " + name);
            }
        }

        private static IDictionary<string, string> ParseKeyValuePairsFromPayload(string payload)
        {
            var kvps = new Dictionary<string, string>();

            var pairs = payload.Split('&');

            foreach (var pair in pairs)
            {
                var kvp = pair.Split('=');
                var key = kvp[0].StartsWith("payload") ? kvp[0].Substring("payload".Length) : kvp[0];
                var value = System.Web.HttpUtility.UrlDecode(kvp[1]);
                kvps.Add(key, value);
            }

            return kvps;
        }

    }
}