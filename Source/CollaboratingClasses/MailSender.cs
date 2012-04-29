using System;
using System.Net.Mail;

namespace CollaboratingClasses
{
    /// <summary>
    /// Smtp Client Adapter.
    /// </summary>
    /// <remarks>
    /// Made it f
    /// </remarks>
    public class MailSender
    {
        // make this method virtual so we can mock it out
        // alternatively create an IMailSender and use that everywhere
        public virtual void SendMail(MailMessage message)
        {
            if (message == null) throw new ArgumentNullException("message");

            var smtpClient = new SmtpClient();
            smtpClient.Send(message);
        }

        // need this constructor if have no other parameterless constructor
        // and want to mock
        protected MailSender()
        {
        }
    }
}