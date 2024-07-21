using SendMessage.Interfaces;
using SendMessage.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SendMessage.Services.SendMessage
{
    public class SendMessageService : ISendMessage
    {
        private readonly IMessageRepository _messageRepository;

        public SendMessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async void Send(TwilioConfiguration config)
        {
            TwilioClient.Init(config.AccountSid, config.AuthToken);

            List<Message> listMessage = await _messageRepository.GetAllMessage();

            if (listMessage.Count == 0)
                return;

            foreach (Message message in listMessage)
            {
                try
                {
                    MessageResource sendMessage = await MessageResource.CreateAsync(
                        body: message.Messages,
                        from: new Twilio.Types.PhoneNumber(message.From),
                        to: new Twilio.Types.PhoneNumber(message.To)
                    );

                    if (sendMessage.Status == MessageResource.StatusEnum.Queued)
                    {
                        message.Status = Models.Enums.MessageStatus.Send;
                        _messageRepository.UpdateMessage(message);
                    }
                    else
                    {
                        message.Status = Models.Enums.MessageStatus.Error;
                        _messageRepository.UpdateMessage(message);
                    }
                }
                catch (Exception ex)
                {
                    message.Status = Models.Enums.MessageStatus.Error;
                    message.Messages = ex.Message;
                    _messageRepository.UpdateMessage(message);
                }
            }
        }
    }
}
