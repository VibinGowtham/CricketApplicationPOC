using System;
using NotificationApiService.Dto;

namespace NotificationApiService.Services
{
	public interface INotificationService
	{
		public Task<String> receiveNotification(NotificationDto notificationDto);
	}
}

