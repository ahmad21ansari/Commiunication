using Domain.Enums;
using System.Text.RegularExpressions;

namespace Common.Recipients
{
    public class MobileRecipient : IRecipient
    {
        private readonly Regex _regex = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
        private readonly string _value;
        private readonly SmsAggregatorType _smsProvider;


        public string Value => _value;
        public SmsAggregatorType Provider => _smsProvider;

        public MobileRecipient(string mobileNumber, SmsAggregatorType provider)
        {
            if (string.IsNullOrEmpty(mobileNumber))
            {
                throw new Exception("Mobile number not entered!");
            }

            if (!_regex.IsMatch(mobileNumber))
            {
                throw new Exception("Mobile number is invalid!");
            }

            _value = mobileNumber;
            _smsProvider = provider;
        }
    }
}
