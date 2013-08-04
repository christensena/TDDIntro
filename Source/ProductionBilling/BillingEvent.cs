namespace ProductionBilling
{
    public interface IBillingEvent
    {
    }

    public abstract class BillingEvent : IBillingEvent
    {
        public long OrganisationID { get; private set; }

        protected BillingEvent(long organisationID)
        {
            OrganisationID = organisationID;
        }
    }
}