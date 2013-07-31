using System.Collections.Generic;

namespace ExternalSystemIntegration
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Organisation { get; set; }
    }

    public class PlanSubscription
    {
        public int Id { get; set; }
        public Plan Plan { get; set; }
        public Subscriber Subscriber { get; set; }
    }

    public class Plan
    {
        internal int ChargifyProductId { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
    }
}