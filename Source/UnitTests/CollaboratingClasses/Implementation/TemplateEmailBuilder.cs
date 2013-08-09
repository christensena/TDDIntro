using System.Collections.Generic;
using System.Net.Mail;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class TemplateEmailBuilder
    {
        public virtual MailMessage BuildEmail(string templateName, IDictionary<string, string> tokens)
        {
            return new MailMessage();
        }
    }
}