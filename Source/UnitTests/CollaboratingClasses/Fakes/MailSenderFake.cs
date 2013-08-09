using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using UnitTests.CollaboratingClasses.Implementation;

namespace UnitTests.CollaboratingClasses.Fakes
{
    public class MailSenderFake : MailSender
    {
        private readonly Queue<MailMessage> messageQueue = new Queue<MailMessage>();

        public override void SendMail(MailMessage message)
        {
            messageQueue.Enqueue(message);
        }

        // helpers

        public Queue<MailMessage> MessageQueue
        {
            get { return messageQueue; }
        }


        public IList<MailMessage> GetMessagesSentToAddress(string email)
        {
            return MessageQueue.Where(msg => msg.To.Any(to => to.Address == email)).ToList();
        }
    }
}