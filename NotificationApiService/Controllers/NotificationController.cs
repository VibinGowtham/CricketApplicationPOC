using System;
using Microsoft.AspNetCore.Mvc;
using NotificationApiService.Dto;
using NotificationApiService.Services;

namespace NotificationApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationService _notificationService;

        public NotificationController(ILogger<NotificationController> logger, INotificationService notificationService)
        {
            this._logger = logger;
            this._notificationService = notificationService;
        }


        [HttpPost("receive")]
        public async Task<string> receiveNotifcation(NotificationDto notificationDto)
        {
            try
            {
                _logger.LogInformation("Entor sendNotification API");
                return await _notificationService.receiveNotification(notificationDto);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error in sendNotification API");
                return e.Message;
            }
        }
    }
}

