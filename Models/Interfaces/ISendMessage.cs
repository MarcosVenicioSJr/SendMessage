namespace SendMessage.Models.Interfaces
{
    public interface ISendMessage
    {
        void Send(TwilioConfiguration config, Message message);
    }
}
