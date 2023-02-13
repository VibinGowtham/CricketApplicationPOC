using System;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using CricketApplicationPOC.Dto;


namespace CricketApplicationPOC.Services
{
	public class RabbitMQService
	{
        string UserName;
        string Password;
        string HostName;
        int Port;
        ConnectionFactory connectionFactory;
        IConnection connection;
        IModel model;

        public RabbitMQService()
        {
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
        }

        public void createDirectExchange(string exchangeName)
        {
            try
            {
                Console.WriteLine("Creating Exchange");
                // Create Exchange
                model.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw err;
            }
        }

        public void QueueDeclare(string queueName)
        {
            try
            {
                // Create Queue
                model.QueueDeclare(queueName, true, false, false, null);
                Console.WriteLine("Creating Queue");
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
        }

        public void QueueBind(string queueName, string exchange, string routingKey)
        {
            try
            {
                // Bind Queue to Exchange
                model.QueueBind(queueName, exchange, routingKey);
                Console.WriteLine("Creating Binding");
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
        }

        public void PublishMessage(NotificationDto message, string exchangeName, string routingKey, string queueName)
        {
            try
            {

                var properties = model.CreateBasicProperties();

                this.createDirectExchange(exchangeName);
                this.QueueDeclare(queueName);
                this.QueueBind(queueName, exchangeName, routingKey);

                properties.Persistent = false;

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                Console.WriteLine(JsonConvert.SerializeObject(message));
                Console.WriteLine("Body");
                model.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: properties, body: body);
                Console.WriteLine("Message Sent");
                return;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                throw;
            }
        }

        public void StartConsumer(string queueName, Func<object, object> executeFunction)
        {
            try
            {
                var connectionFactory = new RabbitMQ.Client.ConnectionFactory()
                {
                    UserName = UserName,
                    Password = Password,
                    HostName = HostName
                };
                var connection = connectionFactory.CreateConnection();
                var model = connection.CreateModel();
                var consumer = new EventingBasicConsumer(model);
                Console.WriteLine("Consumer");
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var messageJSON = Encoding.UTF8.GetString(body.ToArray());

                    var message = JsonConvert.DeserializeObject<NotificationDto>(messageJSON);
                    if (message != null)
                    {
                        executeFunction(message);
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

