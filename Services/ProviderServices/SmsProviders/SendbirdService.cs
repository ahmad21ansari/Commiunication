using Common.ProviderServices;
using Services.Models;

namespace Services.ProviderServices.SmsProviders
{
    public class SendbirdService : IMessageProvider
    {
        public Task<Response> SendAsync(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
