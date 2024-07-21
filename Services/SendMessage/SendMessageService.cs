using SendMessage.Models;
using SendMessage.Models.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SendMessage.Services.SendMessage
{
    public class SendMessageService : ISendMessage
    {
        public async void Send(TwilioConfiguration config, Message message)
        {
            TwilioClient.Init(config.AccountSid, config.AuthToken);

            var sendMessage = await MessageResource.CreateAsync(
                body: message.Messages,
                from: new Twilio.Types.PhoneNumber(message.From),
                to: new Twilio.Types.PhoneNumber(message.To)
            );
        }
    }
}
