using Common.Recipients;
using Domain.Enums;
using Services.Models;
using Services.ProviderServices;
using Services.ProviderServices.EmailServices;
using Services.ProviderServices.SmsProviders;
using Services.ProviderServices.SocialServices;

namespace Common.ProviderServices
{
    public class MessageSender : IMessageSender
    {
        private Request _request;

        private readonly ITelegramService _telegramService;
        private readonly IGMailService _gMailService;
        private readonly IPlivoService _plivoService;
        private readonly ITwilioService _courierService;


        public MessageSender(ITelegramService telegramService,
            IGMailService gMailService,
            IPlivoService sendbirdService,
            ITwilioService courierService)
        {
            _telegramService = telegramService;
            _gMailService = gMailService;
            _plivoService = sendbirdService;
            _courierService = courierService;
        }


        public async Task<Response> SendAsync(Request request)
        {
            _request = request;

            var providerService = await SelectChannelProviderAsync();
            var response = await providerService.SendAsync(request);
            return response;
        }

        private async Task<IMessageProvider> SelectChannelProviderAsync()
        {

            switch (_request.Channel)
            {
                case Channel.Sms:
                    return await SelectSmsService();

                case Channel.Email:
                    return _gMailService;

                case Channel.Telegram:
                    return _telegramService;

                default:
                    throw new NotImplementedException();

            }
        }

        private async Task<IMessageProvider> SelectSmsService()
        {
            var recipient = _request.To as MobileRecipient;
            switch (recipient!.Provider)
            {
                case SmsAggregatorType.Twilio:
                    return _plivoService;
                case SmsAggregatorType.Courier:
                    return _courierService;
                default:
                    return _plivoService;
            }
        }
    }
}
