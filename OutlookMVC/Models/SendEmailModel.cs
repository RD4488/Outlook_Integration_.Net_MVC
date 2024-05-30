namespace OutlookMVC.Models
{
    public class SendEmailModel
    {
        public Message message { get; set; }
    }
    public class EmailAddress
    {
        public string address { get; set; }
    }

    public class ToRecipient
    {
        public EmailAddress emailAddress { get; set; }
    }

    public class Body
    {
        public string contentType { get; set; }
        public string content { get; set; }
    }

    public class Message
    {
        public string subject { get; set; }
        public Body body { get; set; }
        public List<ToRecipient> toRecipients { get; set; }
    }
}
