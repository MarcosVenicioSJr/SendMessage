using SendMessage.Models;

namespace SendMessage.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllMessage();
        void UpdateMessage(Message message);
    }
}
