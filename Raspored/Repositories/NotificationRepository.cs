using Microsoft.EntityFrameworkCore;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using Raspored.Models.Login;
using System;
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

        public void AddNotification(NotificationDTO notification)
        {
            if (IsConflictDetected(notification.Id))
            {
                throw new DataConflictException("A notification with the same ID already exists.");
            }

            var notificationModel = new Notification()
            {
                Title = notification.Title,
                Content = notification.Content,
                Unread = notification.Unread
            };

            var userNotificationMapping = new NotificationMapping()
            {
                SenderId = GetUserIdFromFullName(notification.Sender),
                ReceiverId = GetUserIdFromFullName(notification.Receiver),
                NotificationId = notification.Id,
            };

            _context.Notifications.Add(notificationModel);
            _context.NotificationMappings.Add(userNotificationMapping);
            _context.SaveChanges();
        }


        public void DeleteNotification(NotificationDTO notification)
        {
            var notificationModel = _context.Notifications.FirstOrDefault(x => x.Id == notification.Id);

            var userNotificationMapping = _context.NotificationMappings.FirstOrDefault(x => x.NotificationId == notification.Id);

            if (notificationModel == null)
            {
                throw new Exception("Notification cannot be found in database");
            }

            if (userNotificationMapping == null)
            {
                throw new Exception("Notification Mapping cannot be found in database");
            }


            _context.NotificationMappings.Remove(userNotificationMapping);
            _context.Notifications.Remove(notificationModel);
            _context.SaveChanges();
        }

        public IQueryable<NotificationDTO> GetAllNotifications()
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

        private string GetUserIdFromFullName(string name)
        {
            string[] nameArray = name.Split();
            string firstName = nameArray[0];
            string lastName = nameArray[1];

            var user = _context.Users
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (user == null)
            {
                throw new Exception($"User not found for sender: {name}");
            }

            return user.Id;
        }

        public bool IsConflictDetected(int notificationId)
        {
            return _context.Notifications.Any(ct => ct.Id == notificationId);
        }
    }
}
