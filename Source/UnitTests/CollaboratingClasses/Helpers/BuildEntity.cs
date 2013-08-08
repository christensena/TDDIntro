namespace UnitTests.CollaboratingClasses.Helpers
{
    internal static class BuildEntity
    {
        public static TestOrderBuilder Order
        {
            get { return new TestOrderBuilder(); }
        }
    }
}