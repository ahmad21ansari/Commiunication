namespace Common.Recipients
{
    public class TelegramRecipient : IRecipient
    {
        private readonly string _value;


        public string Value => _value;

        public TelegramRecipient(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                throw new Exception("Telegram id not entered!");
            }

            _value = id;
        }
    }
}
