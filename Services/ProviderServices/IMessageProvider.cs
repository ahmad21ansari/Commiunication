using Services.Models;

namespace Common.ProviderServices
{
    public interface IMessageProvider
    {
        Task<Response> SendAsync(Request request);
    }
}