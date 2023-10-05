using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using Raspored.Models.DTOs;
using Raspored.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raspored.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public NotificationRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddNotification(NotificationDTO notification)
        {
            var notificationModel = new Notification()
            {
                Title = notification.Title,
                Content = notification.Content,
                Unread = notification.Unread
            };

            _context.Notifications.Add(notificationModel);
            _context.SaveChanges();

            var userNotificationMapping = new NotificationMapping()
            {
                SenderId = notification.SenderId,
                ReceiverId = notification.ReceiverId,
                NotificationId = notificationModel.Id
            };

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

        public NotificationDTO GetNotification(int notificationId)
        {
            var notification = _context.NotificationMappings
                .Include(nm => nm.Notification)
                .Include(nm => nm.Sender)
                .Include(nm => nm.Receiver)
                .FirstOrDefault(n => n.Id == notificationId);

            if (notification == null)
            {
                throw new Exception($"Notification with ID {notificationId} cannot be found!");
            }

            return _mapper.Map<NotificationDTO>(notification);
        }

        public IQueryable<NotificationDTO> GetNotifications()
        {
            var notifications = _context.NotificationMappings
                .Include(nm => nm.Notification)
                .Include(nm => nm.Sender)
                .Include(nm => nm.Receiver);

            return _mapper.Map<IEnumerable<NotificationDTO>>(notifications).AsQueryable();
        }

        public void UpdateNotification(NotificationDTO notification)
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

            _context.Entry(notificationModel).State = EntityState.Modified;
            _context.Entry(userNotificationMapping).State = EntityState.Modified;

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
