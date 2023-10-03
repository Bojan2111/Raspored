using Raspored.Models.Login;

namespace Raspored.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Unread { get; set; }
    }
}