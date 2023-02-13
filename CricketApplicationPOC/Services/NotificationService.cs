using System;
using CricketApplicationPOC.Controllers;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Models;

namespace CricketApplicationPOC.Services
{
	public class NotificationService : INotificationService
	{
        private readonly ILogger<NotificationService> _logger;
        private readonly AppDbContext _dbContext;

        public NotificationService(AppDbContext dbContext, ILogger<NotificationService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<String> sendNotification(NotificationDto notificationDto)
        {
            try
            {
                Notification notification = new Notification();
                RabbitMQService rabbitMQService = new RabbitMQService();
                string queueName = "CricApp";
                string exchangeName = "CricExchange";
                string routingKey = "circk_key";

                rabbitMQService.PublishMessage(notificationDto, exchangeName, routingKey, queueName);
                
                //notification.notification = notificationDto.message;

                //await _dbContext.AddAsync<Notification>(notification);

                //await _dbContext.SaveChangesAsync();

                return "Notification Sent";

            }
            catch
            {
                throw;
            }
        }

    }

}

