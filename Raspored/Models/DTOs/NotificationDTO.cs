namespace Raspored.Models.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Receiver { get; set; }
        public string ReceiverId { get; set; }
        public string Sender { get; set; }
        public string SenderId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Unread { get; set; }
    }
}
