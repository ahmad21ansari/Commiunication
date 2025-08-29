using Services.Models;
using System.Text;
using System.Text.Json;

namespace Services.ProviderServices.SmsProviders
{
    public class PlivoService : IPlivoService
    {
        const string authId = "YOUR_AUTH_ID";
        const string authToken = "YOUR_AUTH_TOKEN";
        const string url = "URL";

        public async Task<Response> SendAsync(Request request)
        {
            using (var client = new HttpClient())
            {
                var twilioRequest = request;
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
                httpRequest.Headers.Add("Authorization", authToken);
                var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                httpRequest.Content = jsonContent;
                var res = await client.SendAsync(httpRequest);

                return new Response()
                {
                    StatusCode = (int)res.StatusCode,
                    IsSuccess = res.IsSuccessStatusCode
                };
            }
        }
    }
}
