using System.Collections.Generic;
using System.Net.Mail;

namespace CollaboratingClasses
{
    public class MailSenderFake : MailSender
    {
        private readonly Queue<MailMessage> messageQueue = new Queue<MailMessage>();

        public Queue<MailMessage> MessageQueue
        {
            get { return messageQueue; }
        }

        public override void SendMail(MailMessage message)
        {
            messageQueue.Enqueue(message);
        }
    }
}