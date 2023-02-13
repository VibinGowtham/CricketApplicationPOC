using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CricketApplicationPOC.Controllers
{
    [ApiController]
    [Route("notification")]
    public class NotificationController
	{
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationService _notificationService;

        public NotificationController(ILogger<NotificationController> logger, INotificationService notificationService)
        {
            this._logger = logger;
            this._notificationService = notificationService;
        }

        [HttpPost("send")]
        public async Task<string> sendNotification(NotificationDto notificationDto)
        {
            try
            {
                _logger.LogInformation("Entor sendNotification API");
                return await _notificationService.sendNotification(notificationDto);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error in sendNotification API");
                return e.Message;
            }
        }
    }
}

