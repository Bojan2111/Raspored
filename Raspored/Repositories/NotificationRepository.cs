using Microsoft.EntityFrameworkCore;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using System.Linq;

namespace Raspored.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;
        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddNotification(Notification notification)
        {
            if (IsConflictDetected(notification.Id))
            {
                throw new DataConflictException("A notification with the same ID already exists.");
            }
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public void DeleteNotification(Notification notification)
        {
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
        }

        public IQueryable<Notification> GetAllNotifications()
        {
            return _context.Notifications.AsQueryable();
        }

        public Notification GetNotification(int notificationId)
        {
            return _context.Notifications.FirstOrDefault(x => x.Id == notificationId);
        }

        public void UpdateNotification(Notification notification)
        {
            _context.Entry(notification).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public bool IsConflictDetected(int notificationId)
        {
            return _context.Notifications.Any(ct => ct.Id == notificationId);
        }
    }
}
