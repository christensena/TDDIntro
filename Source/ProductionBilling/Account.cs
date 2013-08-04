namespace ProductionBilling
{
    public class Account
    {
        public string ID { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Email { get; internal set; }
        public string OrganisationName { get; internal set; }

        internal Account()
        {
        }
    }
}