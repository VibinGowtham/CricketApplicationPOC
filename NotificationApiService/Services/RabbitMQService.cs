using System;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using NotificationApiService.Dto;
using Microsoft.EntityFrameworkCore;
using NotificationApiService.Models;

namespace NotificationApiService.Services
{
	public static class RabbitMQService
	{

        public static async Task StartConsumer(string queueName, string connectionString)
        {
            try
            {

                var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseMySql(connectionString, serverVersion, options => options.EnableRetryOnFailure());
                var _context = new AppDbContext(optionsBuilder.Options);
                string UserName;
                string Password;
                string HostName;
                int Port;
                ConnectionFactory connectionFactory;
                IConnection connection;
                IModel model;

                UserName = "RabbitMQPratap";
                Password = "RabbitMQPratap1012";
                Port = 5671;
                HostName = "b-ebbdd5f0-3ed6-4339-ba33-845043c615f7.mq.us-east-1.amazonaws.com";

                //Main entry point to the RabbitMQ .NET AMQP client
                connectionFactory = new RabbitMQ.Client.ConnectionFactory()
                {
                    UserName = UserName,
                    Password = Password,
                    HostName = HostName,
                    Port = Port,
                    Ssl = {
                    Enabled = true,
                    ServerName = HostName
                }

                };
                connection = connectionFactory.CreateConnection();
                model = connection.CreateModel();
                
                var consumer = new EventingBasicConsumer(model);
                Console.WriteLine("Consumer");
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body;
                    var messageJSON = Encoding.UTF8.GetString(body.ToArray());

                    var message = JsonConvert.DeserializeObject<NotificationDto>(messageJSON);
                    if (message != null)
                    {
                        Notification notification = new Notification();

                        notification.notification = message.message;

                        await _context.AddAsync<Notification>(notification);

                        await _context.SaveChangesAsync();
                        Console.WriteLine($" [x] Received {0} ${message.message}");
                    }

                };
                model.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
        }

    }
}

