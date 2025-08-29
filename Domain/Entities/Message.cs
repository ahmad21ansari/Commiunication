using Domain.Enums;

namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid Id { get; private set; }
        public string Body { get; private set; }
        public string Recipient { get; private set; }
        public string Originator { get; private set; }
        public Channel Channel { get; private set; }
        public State State { get; private set; }


        private Message()
        {
            
        }

        public Message(string body, string recipient, string originator, Channel channel)
        {
            Body = body;
            Recipient = recipient;
            Originator = originator;
            Channel = channel;
            State = State.Initiat;
        }

        public Message NeedRetry()
        {
            State = State.NeedToRetry;
            ModifyDateTime = DateTime.Now;
            return this;
        }

        public Message Send()
        {
            State = State.Send;
            ModifyDateTime = DateTime.Now;
            return this;
        }

        public Message Failed()
        {
            State = State.Failed;
            ModifyDateTime = DateTime.Now;
            return this;
        }
    }
}
