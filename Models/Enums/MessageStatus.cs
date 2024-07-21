using System.ComponentModel;

namespace SendMessage.Models.Enums
{
    public enum MessageStatus
    {
        [Description("Enviado")]
        Send = 0,
        [Description("Error")]
        Error = 1,
    }
}
