using Raspored.Models;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface INotificationRepository
    {
        IQueryable<Notification> GetAllNotifications();
        Notification GetNotification(int notificationId);
        void AddNotification(Notification notification);
        void UpdateNotification(Notification notification);
        void DeleteNotification(Notification notification);
        bool IsConflictDetected(int notificationId);
    }
}
