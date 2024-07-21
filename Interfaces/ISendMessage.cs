using SendMessage.Models;

namespace SendMessage.Interfaces
{
    public interface ISendMessage
    {
        void Send(TwilioConfiguration config);
    }
}
