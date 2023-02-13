using System;
using NotificationApiService.Controllers;
using NotificationApiService.Dto;
using NotificationApiService.Models;
using NotificationApiService.Services;

namespace NotificationApiService.Services
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

        public async Task<String> receiveNotification(NotificationDto notificationDto)
        {
            try
            {
                Notification notification = new Notification();
                //RabbitMQService rabbitMQService = new RabbitMQService();
                //string queueName = "CricApp";
                //string exchangeName = "CricExchange";
                //string routingKey = "circk_key";

                //rabbitMQService.PublishMessage(notificationDto, exchangeName, routingKey, queueName);

                notification.notification = notificationDto.message;

                await _dbContext.AddAsync<Notification>(notification);

                await _dbContext.SaveChangesAsync();

                return "Notification Sent";

            }
            catch
            {
                throw;
            }
        }

    }

}

