using System.Text.RegularExpressions;

namespace Common.Recipients
{
    public class EmailRecipient : IRecipient
    {
        private readonly Regex _regex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        private readonly string _value;

        public string Value => _value;

        public EmailRecipient( string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Email address not entered!");
            }

            if (!_regex.IsMatch(email))
            {
                throw new Exception("Email address is invalid!");
            }

            _value = email;
        }
    }
}
