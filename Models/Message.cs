using SendMessage.Models.Enums;

namespace SendMessage.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Messages { get; set; }
        public DateTime SendDate { get; set; }
        public MessageStatus Status { get; set; }
    }
}
