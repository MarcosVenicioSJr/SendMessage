using Microsoft.EntityFrameworkCore;
using SendMessage.Interfaces;
using SendMessage.Models;

namespace SendMessage.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public async Task<List<Message>> GetAllMessage()
        {
            List<Message> messageList = new List<Message>();

            using (var transaction = new SendMessage.Context.Context())
            {
               messageList = await transaction.Messages.ToListAsync();
            }

            return messageList;
        }

        public void UpdateMessage(Message message)
        {
            using (var transaction = new SendMessage.Context.Context())
            {
                message.SendDate = DateTime.Now;
                transaction.Update(message);
            }
        }
    }
}
