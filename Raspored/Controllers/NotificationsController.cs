using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raspored.CustomExceptions;
using Raspored.Interfaces;
using Raspored.Models;
using System;

namespace Raspored.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;


        public NotificationsController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }


        [HttpGet]
        [Route("/notifications")]
        public IActionResult GetNotifications()
        {
            return Ok(_notificationRepository.GetAllNotifications());
        }


        [HttpGet]
        [Route("/notifications/{id}")]
        public IActionResult GetNotification(int id)
        {
            var notification = _notificationRepository.GetNotification(id);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        [HttpPost]
        [Route("/notifications")]
        public IActionResult PostNotification([FromBody] Notification notification)
        {
            try
            {
                if (_notificationRepository.IsConflictDetected(notification.Id))
                {
                    throw new DataConflictException("A notification with the same ID already exists.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _notificationRepository.AddNotification(notification);

                return CreatedAtAction("GetNotification", new { id = notification.Id }, notification);
            }
            catch (DataConflictException ex)
            {
                return Conflict(new { ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request." });
            }
        }

        [HttpPut]
        [Route("/notifications/{id}")]
        public IActionResult PutNotification(int id, Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notification.Id)
            {
                return BadRequest();
            }

            try
            {
                _notificationRepository.UpdateNotification(notification);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(notification);
        }

        [HttpDelete]
        [Route("/notifications/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var notification = _notificationRepository.GetNotification(id);
            if (notification == null)
            {
                return NotFound();
            }

            _notificationRepository.DeleteNotification(notification);
            return NoContent();
        }
    }
}
