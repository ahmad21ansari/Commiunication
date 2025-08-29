using Services.Models;
using Services.ProviderServices.EmailServices;

namespace Common.ProviderServices.EmailServices
{
    public class GMailService : IGMailService
    {
        public Task<Response> SendAsync(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
