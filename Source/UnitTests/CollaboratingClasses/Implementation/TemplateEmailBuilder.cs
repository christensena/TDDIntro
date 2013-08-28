using System.Collections.Generic;
using System.Net.Mail;

namespace UnitTests.CollaboratingClasses.Implementation
{
    public class TemplateEmailBuilder
    {
        public virtual MailMessage BuildEmail(string templateName, IDictionary<string, string> tokens)
        {
            // this would take a template engine, ask it to load template 'templateName' and
            // then replace the tokens as per the 'tokens' dictionary to create the content (subject and body only)
            return new MailMessage();
        }
    }
}