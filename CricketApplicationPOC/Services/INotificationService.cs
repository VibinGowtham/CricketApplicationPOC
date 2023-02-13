using System;
using CricketApplicationPOC.Dto;

namespace CricketApplicationPOC.Services
{
	public interface INotificationService
	{
		public Task<String> sendNotification(NotificationDto notificationDto);
	}
}

