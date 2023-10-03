using Raspored.Models.Login;

namespace Raspored.Models
{
    public class NotificationMapping
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
    }
}
