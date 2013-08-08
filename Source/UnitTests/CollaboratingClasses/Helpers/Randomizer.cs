using System;
using System.Text;

namespace UnitTests.CollaboratingClasses.Helpers
{
    internal static class Randomizer
    {
        public static string RandomString(int length = 10)
        {
            var sb = new StringBuilder();
            while (sb.Length < length)
            {
                sb.Append(Guid.NewGuid());
            }
            // todo: trim to length;
            return sb.ToString();
        }
    }
}