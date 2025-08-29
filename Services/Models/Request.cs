using Common.Recipients;
using Domain.Enums;

namespace Services.Models
{
    public class Request
    {
        public IRecipient To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public Channel Channel { get; set; }

    }
}
