using Raspored.Models.DTOs;
using System.Linq;

namespace Raspored.Interfaces
{
    public interface INotificationRepository
    {
        IQueryable<NotificationDTO> GetAllNotifications();
        NotificationDTO GetNotification(int notificationId);
        void AddNotification(NotificationDTO notification);
        void UpdateNotification(NotificationDTO notification);
        void DeleteNotification(NotificationDTO notification);
        bool IsConflictDetected(int notificationId);
    }
}
